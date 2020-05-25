import groovy.json.*

class OnGhEvent extends Script {

static Map exec(List args, File workingDirectory=null, Appendable stdout=null, Appendable stderr=null, Closure stdin=null){
    ProcessBuilder builder = new ProcessBuilder(args as String[])
    if (stderr ==null){
        builder.redirectErrorStream(true)
    }
    if (workingDirectory!=null){
        builder.directory(workingDirectory)
    }
    def proc = builder.start()

    if (stdin!=null) {
        OutputStream out = proc.getOutputStream();
        stdin(out)
        out.flush();
        out.close();
    }

    if (stdout == null ){
        stdout = new StringBuffer()
    }

    proc.waitForProcessOutput(stdout, stderr)
    int exitValue= proc.exitValue()

    Map ret = ['out': stdout, 'err': stderr, 'status':exitValue, 'cmd':args]

    return ret
}

    def run() {
        String ghPayload = build.buildVariableResolver.resolve("payload")
        String ghEventType = build.buildVariableResolver.resolve("x_github_event")
        String buildNumber = build.getNumber()
        String fullName = build.getProject().getFullName()
        
        File workDir = new File("/tmp/jenkins/on-gh-event/${fullName}/${buildNumber}")
        try{
            if ("pull_request" == ghEventType){
                def payload = new JsonSlurper().parseText(ghPayload)
                if ("closed" == payload.action){
                    File gitWorkDir = workDir
                    def ghRepo=com.cloudbees.jenkins.GitHubRepositoryName.create(payload.repository.clone_url).resolveOne()
                    boolean isFromCollaborator=ghRepo.root.retrieve().asHttpStatusCode(ghRepo.getApiTailUrl("collaborators/${payload.pull_request.user.login}")) == 204
                    String cloneUrl = payload.repository.clone_url
                    String sourceBranch = isFromCollaborator?"refs/pull/${payload.number}/head":"refs/heads/${payload.pull_request.base.ref}"
                    println "Is Collaborator:${isFromCollaborator} (${payload.pull_request.user.login})"
                    println "Clone Url:${cloneUrl}"
                    println "Checkout Branch:${sourceBranch}"

                    println exec(['mkdir', '-p', gitWorkDir.getAbsolutePath()])
                    println exec(['rm', '-rf', gitWorkDir.getAbsolutePath()])
                    println exec(['git', 'init', gitWorkDir.getAbsolutePath()])
                    println exec(['git', 'remote', 'add', 'origin', payload.repository.clone_url], gitWorkDir)
                    println exec(['git', 'fetch', '--no-tags', payload.repository.clone_url, "+${sourceBranch}:PR-${payload.number}"], gitWorkDir)
                    println exec(['git', 'checkout', "PR-${payload.number}"] , gitWorkDir)

                    File pipelineWorkDir = new File("${gitWorkDir.getAbsolutePath()}/.pipeline")
                    println exec(['./npmw', 'ci'], pipelineWorkDir)
                    println exec(['./npmw', 'run', 'clean' ,'--' ,"--pr=${payload.number}", '--env=transient'], pipelineWorkDir)
                }
            }else if ("issue_comment" == ghEventType){
                def payload = new JsonSlurper().parseText(ghPayload)
                if ("created" == payload.action && payload.issue.pull_request !=null ){
                    String comment = payload.comment.body.trim()

                    //OWNER or COLLABORATOR
                    //https://developer.github.com/v4/enum/commentauthorassociation/
                    String commentAuthorAssociation = payload.comment.author_association
                    if (comment.charAt(0) == '/'){
                        println "command: ${comment}"
                        String jobName= payload.repository.name
                        String jobPRName =  payload.repository.full_name

                        List projects = jenkins.model.Jenkins.instance.getAllItems(org.jenkinsci.plugins.workflow.multibranch.WorkflowMultiBranchProject.class).findAll {
                            def scmSource=it.getSCMSources()[0]
                            return payload.repository.owner.login.equalsIgnoreCase(scmSource.getRepoOwner()) && payload.repository.name.equalsIgnoreCase(scmSource.getRepository())
                        }
                        List branchProjects = []
                        projects.each {
                            def branchProject = it.getItem("PR-${payload.issue.number}")
                            if (branchProject!=null){
                                branchProjects.add(branchProject)
                            }
                        }

                        if (comment == '/restart' && (commentAuthorAssociation == 'OWNER' || commentAuthorAssociation == 'COLLABORATOR')){
                            //
                            branchProjects.each {
                                def targetProject=it
                                def cause = new hudson.model.Cause.RemoteCause('github.com', "Pull Request Command By '${payload.comment.user.login}'")
                                targetProject.scheduleBuild(0, cause)
                            }
                        }else if (comment == '/approve' && (commentAuthorAssociation == 'OWNER' || commentAuthorAssociation == 'COLLABORATOR')){
                            if (branchProjects.size() > 0){
                                branchProjects.each { targetJob ->
                                    if (targetJob.getLastBuild()){
                                        hudson.security.ACL.impersonate(hudson.security.ACL.SYSTEM, {
                                            for (org.jenkinsci.plugins.workflow.support.steps.input.InputAction inputAction : targetJob.getLastBuild().getActions(org.jenkinsci.plugins.workflow.support.steps.input.InputAction.class)){
                                                for (org.jenkinsci.plugins.workflow.support.steps.input.InputStepExecution inputStep:inputAction.getExecutions()){
                                                    if (!inputStep.isSettled()){
                                                        println inputStep.proceed(null)
                                                    }
                                                }
                                            }
                                        } as Runnable )
                                    }
                                }
                            }else{
                                println "There is no project or build associated with ${payload.issue.pull_request.html_url}"
                            }
                        }
                    }
                }
            }
        }finally{
            exec(['rm', '-rf', workDir.getAbsolutePath()])
        }


        return null;
    } //end run
    
    static void main(String[] args) {
        org.codehaus.groovy.runtime.InvokerHelper.runScript(OnGhEvent, args)     
    }
}