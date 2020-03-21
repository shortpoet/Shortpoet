import Vue from 'vue'
import Vuex from 'vuex'
// import VueCookies from 'vue-cookies'

import StoreResume from '@/store/modules/StoreResume'
// import StoreAuth from '@/store/modules/StoreAuth'

import {
} from '@/store/mutation-types'

import {
  endpoints
} from '@/store/api-endpoints'

Vue.use(Vuex)

export const rootGetters = {
  getUrlPrefix (state) {
    return state.environment === 'production' ? endpoints.index.BACKEND_PREFIX_PROD : endpoints.index.BACKEND_PREFIX_DEV
  },
  getEnv (state) {
    return state.environment
  }
}

export default new Vuex.Store({
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
})
