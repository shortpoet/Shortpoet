export const index = {
  // ROOT STORE @/store/index.js
  // TODO
  // let clientRoot = window.location.protocol + '//' + window.location.host
  // BACKEND_PREFIX_PROD: 'https://' + window.location.hostname,
  // hardcode prod url for github pages
  // TODO set env var to detect this 
  // maybe also env var to detect git branch

  BACKEND_PREFIX_PROD: process.env.VUE_APP_BACKEND_PREFIX_PROD,

  // BACKEND_PREFIX_PROD: window.location.protocol + '//' + window.location.host,
  // BACKEND_PREFIX_PROD: 'https://localhost:5001',
  BACKEND_PREFIX_DEV: process.env.VUE_APP_BACKEND_PREFIX_LOCAL
}
export const resume = {
  // RESUME @/store/modules/StoreResume.js
  RESUME_GET_API: '/api/Resume/Get',
  RESUME_FETCH_API: '/api/Resume/Fetch/1',
  RESUME_FETCH_LATEST_API: '/api/Resume/FetchLatest'
}
export const auth = {
  // AUTH @/store/modules/StoreAuth.js
  ROLES_API: '/api/Roles',
  HEADERS_API: '/api/Idy/Get'
}
export const endpoints = {
  index: index,
  resume: resume,
  auth: auth
}

export default endpoints
