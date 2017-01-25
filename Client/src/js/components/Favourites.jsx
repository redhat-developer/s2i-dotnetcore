import React from 'react';
import { Alert, Dropdown, ButtonToolbar, Button, Modal } from 'react-bootstrap';
import { Form, FormGroup, FormControl, HelpBlock, ControlLabel, Checkbox } from 'react-bootstrap';
import { Col, Glyphicon } from 'react-bootstrap';

import _ from 'lodash';

import * as Api from '../api';

import Confirm from '../components/Confirm.jsx';
import OverlayTrigger from '../components/OverlayTrigger.jsx';
import RootCloseMenu from './RootCloseMenu.jsx';

import { isBlank } from '../utils/string';


var EditDialog = React.createClass({
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

  nameChanged(e) {
    this.setState({ name: e.target.value });
  },

  defaultChanged(e) {
    this.setState({ isDefault: e.target.checked });
  },

  save() {
    if (isBlank(this.state.name)) {
      this.setState({ nameError: 'Name is required' });
    } else {
      this.props.onSave({ ...this.props.favourite, ...{
        name: this.state.name,
        isDefault: this.state.isDefault,
      }});
    }
  },

  render() {
    return <Modal id="edit-favourite" show={ this.props.show } bsSize="small" onHide={ this.props.onClose }>
      <Modal.Header closeButton>
        <Modal.Title>
          <strong>Favourite</strong>
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form>
          <FormGroup controlId="name" validationState={ this.state.nameError ? 'error' : null }>
            <ControlLabel>Name <sup>*</sup></ControlLabel>
            <FormControl type="text" defaultValue={ this.state.name } onChange={ this.nameChanged } inputRef={ ref => { this.input = ref; }} />
            <HelpBlock>{ this.state.nameError }</HelpBlock>
          </FormGroup>
          <Checkbox checked={ this.state.isDefault } onChange={ this.defaultChanged }>
            Default
          </Checkbox>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={ this.props.onClose }>Close</Button>
        <Button bsStyle="primary" onClick={ this.save }>Save</Button>
      </Modal.Footer>
    </Modal>;
  },
});


var Favourites = React.createClass({
  propTypes: {
    id: React.PropTypes.string,
    className: React.PropTypes.string,
    title: React.PropTypes.string,
    type: React.PropTypes.string.isRequired,
    favourites: React.PropTypes.object.isRequired,
    onSelect: React.PropTypes.func.isRequired,
    onAdd: React.PropTypes.func.isRequired,
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
      this.props.onAdd(favourite);
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
        <EditDialog show={ this.state.showEditDialog } favourite={ this.state.favouriteToEdit } onSave={ this.saveFavourite } onClose= { this.closeDialog } /> : null
      }
    </Dropdown>;
  },
});


export default Favourites;
