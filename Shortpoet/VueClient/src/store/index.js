// import VueCookies from 'vue-cookies'

import StoreResume from '@/store/modules/StoreResume'

import {
  SET_ENV,
  SET_URL_PREFIX
} from '@/store/mutation-types'

import {
} from '@/store/api-endpoints'

const state = {
  environment: null,
  urlPrefix: null,
  BACKEND_PREFIX_PROD: process.env.VUE_APP_BACKEND_PREFIX_PROD,
  BACKEND_PREFIX_DEV: process.env.VUE_APP_BACKEND_PREFIX_LOCAL
}

// export const rootGetters = {
const rootGetters = {
  getUrlPrefix (state) {
    return state.urlPrefix
  },
  getEnv (state) {
    return state.environment
  }
}

const mutations = {
  [SET_ENV] (state, newEnv) { state.env = newEnv},
  [SET_URL_PREFIX] (state) { state.urlPrefix = state.environment === 'production' ? state.BACKEND_PREFIX_PROD : state.BACKEND_PREFIX_DEV }
}
const actions = {
  loadEnv ({ commit }) {
    const env = process.env.NODE_ENV
    commit('SET_ENV', env)
    commit('SET_URL_PREFIX')
  }
}

const modules =  {
  resume: StoreResume.createStoreResume()
}

const createStore = () => {
  return {
    state: state,
    getters: rootGetters,
    mutations: mutations,
    actions: actions,
    modules: modules
  }
}

const createMocks = (custom = {  state: {}, getters: {}, mutations: {}, actions: {}, modules: {} }) => {
  const mockState = Object.assign({}, state, custom.state)
  const mockGetters = Object.assign({}, rootGetters, custom.getters)
  const mockMutations = Object.assign({}, mutations, custom.mutations)
  const mockActions = Object.assign({}, actions, custom.actions)
  const mockModules = Object.assign({}, modules, custom.modules)

  /* istanbul ignore next */
  const createStoreResumeMocks = (custom = { getters: {}, mutations: {}, actions: {}, state: {} }) => {
    return StoreResume.createStoreResumeMocks(custom)
  } 

  return  {  
    state: mockState,
    getters: mockGetters,
    mutations: mockMutations,
    actions: mockActions,
    modules: mockModules,
    createStoreResumeMocks: createStoreResumeMocks
  }
}

export default {
  createStore,
  createMocks
}
