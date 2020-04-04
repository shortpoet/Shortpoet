export const index = {
  // ROOT STORE @/store/index.js
  // TODO
  // let clientRoot = window.location.protocol + '//' + window.location.host
  // BACKEND_PREFIX_PROD: 'https://' + window.location.hostname,
  BACKEND_PREFIX_PROD: window.location.href,
  BACKEND_PREFIX_DEV: 'https://localhost:5001/'
}
export const resume = {
  // RESUME @/store/modules/StoreResume.js
  RESUME_GET_API: 'api/Resume/Get',
  RESUME_FETCH_API: 'api/Resume/Fetch/1'
}
export const auth = {
  // AUTH @/store/modules/StoreAuth.js
  ROLES_API: 'api/Roles',
  HEADERS_API: 'api/Idy/Get'
}
export const endpoints = {
  index: index,
  resume: resume,
  auth: auth
}

export default endpoints
