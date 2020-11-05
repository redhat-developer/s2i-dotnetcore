import PropTypes from 'prop-types';
import React from 'react';
import classNames from 'classnames';
import FileSaver from 'file-saver';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

import TooltipButton from './TooltipButton.jsx';

const ExportButton = ({
  id,
  getExportData,
  filename,
  className,
  disabled,
  disabledTooltip,
  enabledTooltip,
  children,
}) => {
  return (
    <TooltipButton
      id={id}
      className={classNames('tooltip-button', 'hidden-export', className)}
      onClick={() => saveData(getExportData, filename)}
      disabled={disabled}
      disabledTooltip={disabledTooltip}
      enabledTooltip={enabledTooltip}
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
  enabledTooltip: PropTypes.node,
  children: PropTypes.node,
};

ExportButton.defaultProps = {
  disabledTooltip: 'No data to export. Please search first.',
  enabledTooltip: 'Export search results to spreadsheet',
};

export default ExportButton;
