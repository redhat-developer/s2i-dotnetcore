import React from 'react';
import { Alert, Dropdown, ButtonToolbar, Button } from 'react-bootstrap';
import { Form, FormGroup, HelpBlock, ControlLabel } from 'react-bootstrap';
import { Col, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

import * as Api from '../api';

import CheckboxControl from '../components/CheckboxControl.jsx';
import Confirm from '../components/Confirm.jsx';
import EditDialog from '../components/EditDialog.jsx';
import FormInputControl from '../components/FormInputControl.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import RootCloseMenu from './RootCloseMenu.jsx';

import { isBlank } from '../utils/string';


var EditFavouritesDialog = React.createClass({
  propTypes: {
    favourite: React.PropTypes.object.isRequired,
    onSave: React.PropTypes.func.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      name: this.props.favourite.name || '',
      isDefault: this.props.favourite.isDefault || false,
      nameError: '',
    };
  },

  componentDidMount() {
    this.input.focus();
  },

  updateState(state, callback) {
    this.setState(state, callback);
  },

  didChange() {
    if (this.state.name !== this.props.favourite.name) { return true; }
    if (this.state.isDefault !== this.props.favourite.isDefault) { return true; }

    return false;
  },

  isValid() {
    if (isBlank(this.state.name)) {
      this.setState({ nameError: 'Name is required' });
      return false;
    }
    return true;
  },

  onSave() {
    this.props.onSave({ ...this.props.favourite, ...{
      name: this.state.name,
      isDefault: this.state.isDefault,
    }});
  },

  render() {
    return <EditDialog id="edit-favourite" show={ this.props.show } bsSize="small"
      onClose={ this.props.onClose } onSave={ this.onSave } didChange={ this.didChange } isValid={ this.isValid }
      title= {
        <strong>Favourite</strong>
      }>
      <Form>
        <FormGroup controlId="name" validationState={ this.state.nameError ? 'error' : null }>
          <ControlLabel>Name <sup>*</sup></ControlLabel>
          <FormInputControl type="text" defaultValue={ this.state.name } updateState={ this.updateState } inputRef={ ref => { this.input = ref; }} />
          <HelpBlock>{ this.state.nameError }</HelpBlock>
        </FormGroup>
        <CheckboxControl id="isDefault" checked={ this.state.isDefault } updateState={ this.updateState }>
          Default
        </CheckboxControl>
      </Form>
    </EditDialog>;
  },
});


var Favourites = React.createClass({
  propTypes: {
    id: React.PropTypes.string,
    className: React.PropTypes.string,
    title: React.PropTypes.string,
    type: React.PropTypes.string.isRequired,
    favourites: React.PropTypes.object.isRequired,
    data: React.PropTypes.object.isRequired,
    onSelect: React.PropTypes.func.isRequired,
    pullRight: React.PropTypes.bool,
  },

  getInitialState() {
    return {
      favourites: this.props.favourites,
      favouriteToEdit: {},
      showEditDialog: false,
    };
  },

  componentWillReceiveProps(nextProps) {
    if (!_.isEqual(nextProps.favourites, this.props.favourites)) {
      this.setState({ favourites: nextProps.favourites });
    }
  },

  addFavourite() {
    this.editFavourite({
      type: this.props.type,
      name: '',
      value: '',
      isDefault: false,
    });
  },

  editFavourite(favourite) {
    this.setState({ favouriteToEdit: favourite });
    this.openDialog();
  },

  saveFavourite(favourite) {
    // Make sure there's only one default
    if (favourite.isDefault) {
      var oldDefault = _.find(this.state.favourites, (fave) => { return fave.isDefault; });
      if (oldDefault && (favourite.id !== oldDefault.id)) {
        oldDefault.isDefault = false;
        Api.updateFavourite(oldDefault);
      }
    }

    if (favourite.id) {
      Api.updateFavourite(favourite);
    } else {
      favourite.value = JSON.stringify(this.props.data);
      Api.addFavourite(favourite);
    }

    this.closeDialog();
  },

  deleteFavourite(favourite) {
    Api.deleteFavourite(favourite);
  },

  selectFavourite(favourite) {
    this.props.onSelect(favourite);
  },

  openDialog() {
    this.setState({ showEditDialog: true });
  },

  closeDialog() {
    this.setState({ showEditDialog: false });
  },

  render() {
    var title = this.props.title || 'Faves';
    return <Dropdown id={ this.props.id } className={ `favourites ${ this.props.className || '' }` } title={ title }  pullRight={ this.props.pullRight }>
      <Dropdown.Toggle>{ title }</Dropdown.Toggle>
      <RootCloseMenu bsRole="menu">
        <div className="favourites-button-bar">
          <Button onClick={ this.addFavourite }>Favourite Current Selection</Button>
        </div>
        {(() => {
          if (Object.keys(this.state.favourites).length === 0) { return <Alert bsStyle="success" style={{ marginBottom: 0 }}>No favourites</Alert>; }

          return <ul>
            {
              _.map(this.state.favourites, (favourite) => {
                return <li key={ favourite.id }>
                  <Col md={1}>
                    { favourite.isDefault ? <Glyphicon glyph="star" /> : '' }
                  </Col>
                  <Col md={8}>
                    <a onClick={ this.selectFavourite.bind(this, favourite) }>{ favourite.name }</a>
                  </Col>
                  <Col md={3}>
                    <ButtonToolbar>
                      <Button bsSize="xsmall" onClick={ this.editFavourite.bind(this, favourite) }><Glyphicon glyph="edit" /></Button>
                      <OverlayTrigger trigger="click" placement="top" rootClose overlay={ <Confirm onConfirm={ this.deleteFavourite.bind(this, favourite) }/> }>
                        <Button bsSize="xsmall"><Glyphicon glyph="remove" /></Button>
                      </OverlayTrigger>
                    </ButtonToolbar>
                  </Col>
                </li>;
              })
            }
          </ul>;
        })()}
      </RootCloseMenu>
      { this.state.showEditDialog ?
        <EditFavouritesDialog show={ this.state.showEditDialog } favourite={ this.state.favouriteToEdit } onSave={ this.saveFavourite } onClose= { this.closeDialog } /> : null
      }
    </Dropdown>;
  },
});


export default Favourites;
