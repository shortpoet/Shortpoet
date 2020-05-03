import { createLocalVue } from '@vue/test-utils'
import factory from './test.utils.factory'
import factoryShallow from './test.utils.factoryShallow'

// import VueRouter from 'vue-router'
import Vuex from 'vuex'
import createStore from '@/store'
import PortalVue from 'portal-vue'


export const createWrapper  = (
  component,
  options = {},
  resumeStoreOptions = {},
  isShallow = false,
  ) => {
    const localVue = createLocalVue()
    // localVue.use(VueRouter)
    localVue.use(Vuex)
    localVue.use(PortalVue)
    const mockStoreResume = createStore.createMocks().createStoreResumeMocks(resumeStoreOptions)
    const storeConfig = createStore.createMocks({modules: {resume: mockStoreResume}})
    const store = new Vuex.Store(storeConfig)
    return isShallow? factoryShallow(component, {localVue, store, ...options}) : factory(component, {localVue, store, ...options})
}

module.exports = createWrapper