import { createLocalVue } from '@vue/test-utils'
import factory from './test.utils.factory'
import factoryShallow from './test.utils.factoryShallow'

// import VueRouter from 'vue-router'
import Vuex from 'vuex'
import createStore from '@/store/createStore'
import PortalVue from 'portal-vue'

export const createWrapper  = (
  component,
  /* istanbul ignore next */
  options = {},
  // but why don't i have to ignore the empty  or even unprovided resumeStoreOtions
  // might need to figure this out but setting params to ignore for now
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
    // console.log(options)
    return isShallow? factoryShallow(component, {localVue, store, ...options}) : factory(component, {localVue, store, ...options})
}

// export default createWrapper
// when this was set to export default a console log(createWrapper) that was in
// test.utils.textMatcher line 19 was being executed from every module that called createWrapper
module.exports = createWrapper