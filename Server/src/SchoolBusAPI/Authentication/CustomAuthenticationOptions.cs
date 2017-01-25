using Microsoft.AspNetCore.Builder;

namespace SchoolBusAPI.Authentication
{
    public class CustomAuthenticationOptions : AuthenticationOptions
    {
        public CustomAuthenticationOptions()
        {
            // This needs to be true for the handler to be called.
            this.AutomaticAuthenticate = true;

            // This needs to be true for the handler process challenges when authentication or authorization fail.
            this.AutomaticChallenge = true;
        }
    }
}
