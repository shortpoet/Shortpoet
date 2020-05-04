// import VueCookies from 'vue-cookies'

import StoreResume from '@/store/modules/StoreResume'

import {
} from '@/store/mutation-types'

import {
  endpoints
} from '@/store/api-endpoints'

const state = {
  environment: process.env.NODE_ENV === 'development' ? 'development' : 'production'
}

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

const mutations = {}
const actions = {}

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
