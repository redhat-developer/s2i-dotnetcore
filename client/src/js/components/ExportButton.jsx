import PropTypes from 'prop-types';
import React from 'react';
import classNames from 'classnames';
import FileSaver from 'file-saver';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import TooltipButton from './TooltipButton.jsx';

const ExportButton = ({ id, getExportData, filename, className, disabled, disabledTooltip, children }) => {
  return (
    <TooltipButton
      id={id}
      className={classNames('export-button', 'hidden-export', className)}
      onClick={() => saveData(getExportData, filename)}
      disabled={disabled}
      disabledTooltip={disabledTooltip}
    >
      <FontAwesomeIcon icon="download" />
      <span>{children}</span>
    </TooltipButton>
  );
};

const saveData = (getExportData, filename) => {
  const data = getExportData();
  FileSaver.saveAs(new Blob(data), filename + '.csv');
};

ExportButton.propTypes = {
  id: PropTypes.string,
  getExportData: PropTypes.func,
  filename: PropTypes.string,
  className: PropTypes.string,
  title: PropTypes.string,
  disabled: PropTypes.bool,
  disabledTooltip: PropTypes.node,
  children: PropTypes.node,
};

ExportButton.defaultProps = {
  disabledTooltip: 'No data to export. Please search first.',
};

export default ExportButton;
