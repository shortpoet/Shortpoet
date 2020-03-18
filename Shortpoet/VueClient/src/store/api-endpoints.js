export const index = {
  // ROOT STORE @/store/index.js
  // BACKEND_PREFIX_PROD: 'https://tableau-interface.apps.pcfpre-phx.cloud.boeing.com',
  // TODO
  //     let clientRoot = window.location.protocol + '//' + window.location.host
  // FROM dbana/app/.../authservice.js

  BACKEND_PREFIX_PROD: 'https://' + window.location.hostname,
  BACKEND_PREFIX_DEV: 'https://localhost:5001'
}
export const resume = {
  // RESUME @/store/modules/StoreResume.js
  RESUME_API: '/api/Resume/Get'
}
export const auth = {
  // AUTH @/store/modules/StoreAuth.js
  ROLES_API: '/api/Roles',
  HEADERS_API: '/api/Idy/Get',
  BOEING_USER_API: 'https://insite.web.boeing.com/culture/service/boeingUserWebServiceJSON/bemsid?query='
}
export const endpoints = {
  index: index,
  resume: resume,
  auth: auth
}

export default endpoints
