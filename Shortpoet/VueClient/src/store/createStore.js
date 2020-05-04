// import VueCookies from 'vue-cookies'
import { state, getters, mutations, actions, modules } from './index'

// import StoreResume from '@/store/modules/StoreResume'

import { createStoreResumeMocks } from '@/store/modules/resume/createStoreResume'

const createStore = () => {
  return {
    state: state,
    getters: getters,
    mutations: mutations,
    actions: actions,
    modules: modules
  }
}

const createMocks = (custom = {  state: {}, getters: {}, mutations: {}, actions: {}, modules: {} }) => {
  const mockState = Object.assign({}, state, custom.state)
  const mockGetters = Object.assign({}, getters, custom.getters)
  const mockMutations = Object.assign({}, mutations, custom.mutations)
  const mockActions = Object.assign({}, actions, custom.actions)
  const mockModules = Object.assign({}, modules, custom.modules)

  /* istanbul ignore next */
  // const createStoreResumeMocks = (custom = { getters: {}, mutations: {}, actions: {}, state: {} }) => {
  //   return StoreResume.createStoreResumeMocks(custom)
  // } 

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
