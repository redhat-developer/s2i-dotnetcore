import React from 'react';

import { connect } from 'react-redux';

import { Alert } from 'react-bootstrap';

import _ from 'lodash';

import * as Action from '../../actionTypes';
import * as Api from '../../api';
import * as Constant from '../../constants';
import store from '../../store';

import ModalDialog from '../../components/ModalDialog.jsx';
import SortTable from '../../components/SortTable.jsx';
import Spinner from '../../components/Spinner.jsx';

import { formatDateTime } from '../../utils/date';


var HistoryListDialog = React.createClass({
  propTypes: {
    onClose: React.PropTypes.func.isRequired,
    show: React.PropTypes.bool,
    histories: React.PropTypes.object,
    ui: React.PropTypes.object,
  },

  getInitialState() {
    return {
      loading: false,

      ui : {
        sortField: this.props.ui.sortField || 'timestamp',
        sortDesc: this.props.ui.sortDesc === true,
      },
    };
  },

  updateUIState(state, callback) {
    this.setState({ ui: { ...this.state.ui, ...state }}, () =>{
      store.dispatch({ type: Action.UPDATE_HISTORIES_UI, histories: this.state.ui });
      if (callback) { callback(); }
    });
  },

  fetch() {
    this.setState({ loading: true });
    Api.getSchoolBusHistories(1).finally(() => {
      this.setState({ loading: false });
    });
  },

  render() {
    return <ModalDialog id="history-dialog" backdrop="static" show={ this.props.show } onClose={ this.props.onClose } title={ <strong>History</strong> }>
      {(() => {
        return <div>
          {(() => {
            if (this.state.loading) { return <div style={{ textAlign: 'center' }}><Spinner/></div>; }

            if (Object.keys(this.props.histories).length === 0) { return <Alert bsStyle="success">No history</Alert>; }

            var histories = _.sortBy(this.props.histories, this.state.ui.sortField);
            if (this.state.ui.sortDesc) {
              _.reverse(histories);
            }

            var headers = [
              { field: 'timestampSort',       title: 'Timestamp' },
              { field: 'userId',              title: 'User Id'   },
              { field: 'event', noSort: true, title: 'Event'     },
            ];

            return <SortTable id="history-list" sortField={ this.state.ui.sortField } sortDesc={ this.state.ui.sortDesc } onSort={ this.updateUIState } headers={ headers }>
              {
                _.map(histories, (history) => {
                  return <tr key={ history.id }>
                    <td>{ formatDateTime(history.timestamp, Constant.DATE_TIME_ISO_8601) }</td>
                    <td>{ history.userId }</td>
                    <td>{ History.renderEvent(history) }</td>
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
    histories: state.models.histories,
    ui: state.ui.histories,
  };
}

export default connect(mapStateToProps)(HistoryListDialog);
