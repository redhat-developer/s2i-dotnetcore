import { library } from '@fortawesome/fontawesome-svg-core';
import {
  faTrash,
  faEnvelope,
  faEnvelopeOpen,
  faTrashAlt,
} from '@fortawesome/free-solid-svg-icons';

const addIconsToLibrary = () => {
  library.add(faTrash);
  library.add(faEnvelope);
  library.add(faEnvelopeOpen);
  library.add(faTrashAlt);
};

export default addIconsToLibrary;
