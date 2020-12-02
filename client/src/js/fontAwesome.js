import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faTrash,
  faEnvelope,
  faEnvelopeOpen,
  faTrashAlt,
  faDownload,
} from '@fortawesome/free-solid-svg-icons';

const addIconsToLibrary = () => {
  library.add(faTrash);
  library.add(faEnvelope);
  library.add(faEnvelopeOpen);
  library.add(faTrashAlt);
  library.add(faDownload);
};

export default addIconsToLibrary;
