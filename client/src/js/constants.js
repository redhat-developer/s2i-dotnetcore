// Paths
export const HOME_PATHNAME = 'home';
export const BUSES_PATHNAME = 'school-buses';
export const OWNERS_PATHNAME = 'owners';
export const CCWNOTIFICATIONS_PATHNAME = 'ccwnotifications';
export const USERS_PATHNAME = 'users';
export const ROLES_PATHNAME = 'roles';
export const VERSION_PATHNAME = 'version';
export const INSPECTION_PATHNAME = 'inspection';
export const CONTACT_PATHNAME = 'contact';

// Status
export const STATUS_ACTIVE = 'Active';
export const STATUS_ARCHIVED = 'Archived';

// Inspections
export const INSPECTION_TYPE_ANNUAL = 'Annual';
export const INSPECTION_TYPE_REINSPECTION = 'Re-Inspection';

export const INSPECTION_RESULT_PASSED = 'Passed';
export const INSPECTION_RESULT_FAILED = 'Failed';
export const INSPECTION_RESULT_OUT_OF_SERVICE = 'Out of Service';

export const INSPECTION_EDIT_GRACE_PERIOD_HOURS = 24;
export const INSPECTION_DELETE_GRACE_PERIOD_HOURS = 24;
export const INSPECTION_DAYS_DUE_WARNING = 30;

// Owners
export const OWNER_DELETE_GRACE_PERIOD_HOURS = 24;

// School Bus Queries
export const SCHOOL_BUS_OWNER_QUERY = 'ownerId';
export const SCHOOL_BUS_OVERDUE_QUERY = 'overdue';
export const SCHOOL_BUS_REINSPECTIONS_QUERY = 'reinspections';
export const SCHOOL_BUS_WITHIN_30_DAYS_QUERY = 'within30days';

// CCW Notification Queries
export const CCWNOTIRICATION_INSPECTORS_QUERY = 'inspectors';

// Date Formats
export const DATE_FULL_MONTH_DAY_YEAR = 'MMMM D, YYYY';
export const DATE_SHORT_MONTH_DAY_YEAR = 'MMM D, YYYY';
export const DATE_YEAR_SHORT_MONTH_DAY = 'YYYY-MMM-DD';
export const DATE_ISO_8601 = 'YYYY-MM-DD';

export const DATE_ZULU = 'YYYY-MM-DDThh:mm:ss[Z]';

export const DATE_TIME_ISO_8601 = 'YYYY-MM-DDTHH:mm:ss';
export const DATE_TIME_READABLE = 'MMMM D, YYYY [at] h:mm:ss A';
export const DATE_TIME_LOG = 'MMM D, YYYY h:mm:ss A';

// CCW Search Fields
export const CCW_REGISTRATION = 'regi';
export const CCW_PLATE = 'plate';
export const CCW_VIN = 'vin';

// Contact roles
export const CONTACT_ROLE_DRIVER = 'Driver';
export const CONTACT_ROLE_ASSISTANT = 'Assistant';
export const CONTACT_ROLE_MECHANIC = 'Mechanic';
export const CONTACT_ROLE_OWNER = 'Owner';
export const CONTACT_ROLE_SUPERVISOR = 'Supervisor';

// Permission Codes
export const PERMISSION_HOME = 'HOME';
export const PERMISSION_OWNER_R = 'OWNER-R';
export const PERMISSION_OWNER_W = 'OWNER-W';
export const PERMISSION_SB_R = 'SB-R';
export const PERMISSION_SB_W = 'SB-W';
export const PERMISSION_USER_R = 'USER-R';
export const PERMISSION_USER_W = 'USER-W';
export const PERMISSION_ROLE_R = 'ROLE-R';
export const PERMISSION_ROLE_W = 'ROLE-W';
export const PERMISSION_CODE_R = 'CODE-R';
export const PERMISSION_CODE_W = 'CODE-W';

// Max Field Lenghts
export const MAX_LENGTH_NOTE_TEXT = 2048;
