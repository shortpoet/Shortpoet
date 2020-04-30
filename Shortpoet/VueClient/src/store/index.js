// import VueCookies from 'vue-cookies'

import StoreResume from '@/store/modules/StoreResume'
// import StoreAuth from '@/store/modules/StoreAuth'

import {
} from '@/store/mutation-types'

import {
  endpoints
} from '@/store/api-endpoints'


// export const rootGetters = {
const rootGetters = {
  getUrlPrefix (state) {
    // console.log(process.env)
    return state.environment === 'production' ? endpoints.index.BACKEND_PREFIX_PROD : endpoints.index.BACKEND_PREFIX_DEV
  },
  getEnv (state) {
    return state.environment
  }
}

export default function createStore () {
  return {
    modules: {
      // auth: StoreAuth,
      resume: StoreResume
    },
    state: {
      environment: process.env.NODE_ENV === 'development' ? 'development' : 'production'
    },
    getters: rootGetters,
    mutations: {
    },
    actions: {
    }  
  }
}
