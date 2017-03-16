// This should be replaced at some point by a History screen with searching/filtering.
// This would allow an admin to view history by user, etc. Also, it would eliminate the
// convoluted way we get to linked content.

import React from 'react';

import { connect } from 'react-redux';

import { Alert, Button } from 'react-bootstrap';

import _ from 'lodash';

import * as Action from '../../actionTypes';
import * as Constant from '../../constants';
import * as History from '../../history';
import store from '../../store';

import ModalDialog from '../../components/ModalDialog.jsx';
import SortTable from '../../components/SortTable.jsx';
import Spinner from '../../components/Spinner.jsx';

import { formatDateTime } from '../../utils/date';


// API limit: how many to fetch first time
const API_LIMIT = 10;

var HistoryListDialog = React.createClass({
  propTypes: {
    historyEntity: React.PropTypes.object.isRequired,
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
    history: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,

      canShowMore: false,

      ui : {
        sortField: this.props.ui.sortField || 'timestampSort',
        sortDesc: this.props.ui.sortDesc !== false,
      },
    };
  },

  componentDidMount() {
    this.fetch(true);
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_HISTORY_UI, history: this.state.ui });
      if (callback) { callback(); }
    });
  },

  fetch(first) {
    // Easy mode: show 10 the first time and let the user load all of them with the
    // "Show More" button. Can adapt for paginated / offset&limit calls if necessary.
    this.setState({ loading: true });
    return History.get(this.props.historyEntity, 0, first ? API_LIMIT : null).finally(() => {
      this.setState({
        loading: false,
        canShowMore: first && Object.keys(this.props.history).length >= API_LIMIT,
      });
    });
  },

  showMore() {
    this.fetch();
  },

  render() {
    return <ModalDialog id="history-dialog" backdrop="static" bsSize="lg" show={ this.props.show } onClose={ this.props.onClose }
      title={ <strong>History for { this.props.historyEntity.type } { this.props.historyEntity.description }</strong> }
      footer={
          <span>
            <Button title="Close" onClick={ this.props.onClose }>Close</Button>
            <Button title="Show More" onClick={ this.showMore } disabled={ !this.state.canShowMore }>Show More</Button>
          </span>
      }
    >
      {(() => {
        return <div>
          {(() => {
            if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

            if (Object.keys(this.props.history).length === 0) { return <Alert bsStyle="success">No history</Alert>; }

            var history = _.sortBy(this.props.history, this.state.ui.sortField);
            if (this.state.ui.sortDesc) {
              _.reverse(history);
            }

            var headers = [
              { field: 'timestampSort',       title: 'Timestamp' },
              { field: 'lastUpdateUserid',    title: 'User'      },
              { field: 'event', noSort: true, title: 'Event'     },
            ];

            return <SortTable id="history-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
              {
                _.map(history, (history) => {
                  return <tr key={ history.id }>
                    <td>{ formatDateTime(history.lastUpdateTimestamp, Constant.DATE_TIME_LOG) }</td>
                    <td>{ history.lastUpdateUserid }</td>
                    <td className="history-event">{ History.renderEvent(history.historyText, this.props.onClose) }</td>
                  </tr>;
                })
              }
            </SortTable>;
          })()}
        </div>;
      })()}
    </ModalDialog>;
  },
});

function mapStateToProps(state) {
  return {
    history: state.models.history,
    ui: state.ui.history,
  };
}

export default connect(mapStateToProps)(HistoryListDialog);
