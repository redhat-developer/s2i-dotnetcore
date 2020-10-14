import PropTypes from 'prop-types';
import React from 'react';
import classNames from 'classnames';
import { Glyphicon } from 'react-bootstrap';
import FileSaver from 'file-saver';

import TooltipButton from './TooltipButton.jsx';

const ExportButton = ({ id, data, filename, className, disabled, disabledTooltip, children }) => {
  return (
    <TooltipButton
      id={id}
      className={classNames('export-button', 'hidden-export', className)}
      onClick={() => saveData(data, filename)}
      disabled={disabled}
      disabledTooltip={disabledTooltip}
    >
      <Glyphicon glyph="download-alt" title="Export" />
      <span>{children}</span>
    </TooltipButton>
  );
};

const saveData = (data, filename) => {
  FileSaver.saveAs(new Blob(data), filename + '.csv');
};

ExportButton.propTypes = {
  id: PropTypes.string,
  data: PropTypes.array,
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
