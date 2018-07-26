import React from 'react';
import { connect } from 'react-redux';

import EditDialog from '../../components/EditDialog.jsx';
import FormInputControl from '../../components/FormInputControl.jsx';
import Spinner from '../../components/Spinner.jsx';
import { Form, FormGroup, Grid, Well, Row, Col, ControlLabel, HelpBlock } from 'react-bootstrap';
import { formatDateTime } from '../../utils/date';
import { isBlank } from '../../utils/string';

import * as Constant from '../../constants';
import * as Api from '../../api';
import _ from 'lodash';
import Moment from 'moment';

var SchoolBusesEmailDialog = React.createClass({
  propTypes:{
    currentUser: React.PropTypes.object.isRequired,
    schoolBuses: React.PropTypes.object.isRequired,
    show: React.PropTypes.bool,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    email: React.PropTypes.object,

    owner: React.PropTypes.object.isRequired,
    ui: React.PropTypes.object,
  },

  getInitialState(){
    return {
      loadData: true,

      mailFrom: this.props.currentUser && this.props.currentUser.email ? this.props.currentUser.email : '',
      mailTo: '',
      mailCc: '',
      subject: '',
      body: 'Initial Message',

      mailToError: false,
      mailCcError: false,
      subjectError: false,

      ui : {
        sortField: this.props.ui.sortField,
        sortDesc: this.props.ui.sortDesc,
      },
    };
  },

  componentDidMount(){
    this.setState({ loadData: true });

    //if user retry sending email
    if(!_.isEmpty(this.props.email)){
      var email = _.omit(this.props.email, ['errorInfo','mailSent']);
      return this.setState({
        mailTo: email.mailTo,
        mailCc: email.mailCc,
        subject: email.subject,
        body: email.body,
        loadData: false,
      });
    }
    
    this.fetchEmailAddress();

    this.populateBody();
  },

  fetchEmailAddress(){
    this.setState({ loadData: true });
    var primaryContactIds = [];//Array store all primary contact id of owners who related to search result of school buses
    var emailAddresses = [];
    var count = 0;
    _.map(this.props.schoolBuses, (bus) => {
      if(bus.schoolBusOwner && bus.schoolBusOwner.primaryContactId){primaryContactIds.push(bus.schoolBusOwner.primaryContactId);}
    });
    primaryContactIds = _.uniq(primaryContactIds);//remove duplicated id

    //get primary contacts
    _.map(primaryContactIds, (id) =>{
      Api.getContact(id).then(response => {
        emailAddresses.push(response.emailAddress);
        count++;
        if(count == primaryContactIds.length){
          this.setState({
            subject: 'Request School Bus Inspection ',
            mailTo: emailAddresses.join('; '),
            loadData: false,
          });
        }
      });
    });
  },

  populateBody(){
    this.setState({ loadData: true });
    var schoolBuses = _.sortBy(this.props.schoolBuses, this.state.ui.sortField);
    if (this.state.ui.sortDesc) {
      _.reverse(schoolBuses);
    }
    var body = 'Hi' + ',\n\nI am writing to you to require preparation for school bus inspection, please have following buses on hand.';
    body += '\n\nThe buses I need are:\n';
    _.map(schoolBuses, (bus) => {
      body += '\n' + '*Owner: ' + bus.ownerName;
      body += '\n' + '- Inspection Date: ' + formatDateTime(bus.nextInspectionDate, Constant.DATE_SHORT_MONTH_DAY_YEAR);
      body += '\n' + '- Registration: ' + bus.icbcRegistrationNumber;
      body += '\n' + '- Plate Number: ' + bus.licencePlateNumber;
      body += '\n' + '- Unit Number: ' + bus.unitNumber;
      body += '\n' + '- Permit: ' + bus.permitNumber;
      body += '\n' + '- District: ' + bus.districtName;
      body += '\n' + '- Home Terminal: ' + bus.homeTerminalCityPostal;
      return body += '\n';
    });
    body += '\n\nThank you for your cooperation.';
    body += '\n\nBest Regards,';
    body += '\n\n' + this.props.currentUser.fullName;
    body += '\n' + Moment().format('MMMM Do YYYY');
    this.setState({ body: body });
  },

  updateState(state, callback){
    this.setState(state, callback);
  },

  onSave(){
    var email = {
      userName: this.props.currentUser.name,
      mailFrom: this.state.mailFrom,
      mailTo: this.state.mailTo,
      mailCc: this.state.mailCc,
      subject: this.state.subject,
      body: this.state.body,
    };
    this.props.onSave(email);
  },

  didChange(){
    return true;
  },

  isValid(){
    var isValid = true;
    var re =  RegExp(/^[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/);

    this.setState({
      mailToError: false,
      mailCcError: false,
      subjectError: false,
    });

    if(isBlank(this.state.mailTo)){
      this.setState({ mailToError: 'Email address is required.' });
      isValid = false;
    } else {
      var mailTos = this.state.mailTo.split(/[;, ]/);
      var invalidMailTo = [];
      //remove empty string and find out invalid email
      for(var a in mailTos){
        if(mailTos[a] != '' && !re.test(mailTos[a])){
          invalidMailTo.push(mailTos[a]);
        }
      }
      //check if invalid email exist
      if(invalidMailTo.length > 0){
        this.setState({ mailToError: 'Email address in invalid format: ' + invalidMailTo.join(', ') });
        isValid = false;
      }
    }

    if(!isBlank(this.state.mailCc)){
      var mailCcs = this.state.mailCc.split(/[;, ]/);
      var invalidMailCc = [];
      //remove empty string and find out invalid email
      for(var b in mailCcs){
        if(mailCcs[b] != '' && !re.test(mailCcs[b])){
          invalidMailCc.push(mailCcs[b]);
        }
      }
      //check if invalid email exist
      if(invalidMailCc.length > 0){
        this.setState({ mailCcError: 'Email address in invalid format: ' + invalidMailCc.join(', ') });
        isValid = false;
      }
    }

    if(isBlank(this.state.subject)){
      this.setState({ subjectError: 'Email subject is required.' });
      isValid = false;
    }

    return isValid;
  },

  render(){ 
    return <div>
      <EditDialog title={<strong>Email to School Bus Owner</strong>} didChange={ this.didChange } isValid={ this.isValid } 
      onSave={ this.onSave } onClose={ this.props.onClose } show={ this.props.show } saveText={ 'Send' }>
      {(() => {
        if(this.state.loadData){ return <div style={ {textAlign: 'center'} }><Spinner/></div>; }

        return <Form>
          <Grid fluid>
          <Well>
            <Row>
              <Col md={12}>
								<FormGroup controlId="mailTo" validationState={ this.state.mailToError ? 'error' : null }>
									<ControlLabel>Email <sup>*</sup></ControlLabel><span style={{fontSize: '12px' }}> (Use ; to separate addresses)</span>
                  <FormInputControl type="text" defaultValue={ this.state.mailTo } placeholder="example@email.com;" updateState={ this.updateState }/>
                  <HelpBlock>{ this.state.mailToError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
            <Row>
              <Col md={12}>
								<FormGroup controlId="mailCc" validationState={ this.state.mailCcError ? 'error' : null }>
									<ControlLabel>CC </ControlLabel><span style={{fontSize: '12px' }}> (Use ; to separate addresses)</span>
                  <FormInputControl type="text" defaultValue={ this.state.mailCc } placeholder="example@email.com;" updateState={ this.updateState }/>
                  <HelpBlock>{ this.state.mailCcError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
            <Row>
							<Col md={12}>
								<FormGroup controlId="subject" validationState={ this.state.subjectError ? 'error' : null }>
									<ControlLabel>Subject <sup>*</sup></ControlLabel>
									<FormInputControl type="text" defaultValue={ this.state.subject } placeholder="Subject" updateState={ this.updateState }/>
                  <HelpBlock>{ this.state.subjectError }</HelpBlock>
                </FormGroup>
              </Col>
            </Row>
						<Row>
              <Col md={12}>
                <FormGroup controlId="body">
                  <ControlLabel>Body</ControlLabel>
                  <FormInputControl style={{height: '350px', overflow: 'auto' }} componentClass="textarea" value={ this.state.body } updateState={ this.updateState }/>
                </FormGroup>
              </Col>
            </Row>
          </Well>
          </Grid>
        </Form>;
      })()}
      </EditDialog>
    </div>;
  },
});

function mapStateToProps(state){
  return {
    owner: state.models.owner,
    currentUser: state.user,
    ui: state.ui.schoolBuses,
  };
}

export default connect(mapStateToProps)(SchoolBusesEmailDialog);
