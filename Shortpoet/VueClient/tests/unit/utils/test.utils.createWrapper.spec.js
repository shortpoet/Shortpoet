import {createWrapper} from '@/utils/myTest/test.utils.createWrapper'
import { createLocalVue } from '@vue/test-utils'
import {cloneDeep} from 'lodash'
import Vuex from 'vuex'
import PortalVue from 'portal-vue'
import createStore from '@/store'

import factory from '@/utils/myTest/test.utils.factory'

jest.mock('@/utils/myTest/test.utils.factory')


describe('test.utils.createWrapper', () => {
  // let factory
  beforeEach(() => {
    // factory = require('../../../src/utils/myTest/__mocks__/test.utils.factory').default
  })

  const component = {}
  const mountOptions = {
    propsData: {},
    localVue: {},
    mocks: {},
    store: {},
    // context: {}, // only for functional components
    router: {},
    computed: {},
    stubs: {},
    slots: {},
    scopedSlots: {},
    attrs: {},
    attachToDocument: false,
    attachTo: null, //HTML Element or String
    listeners: {},
    parentComponent: {},
    provide: {}
  }
  const resumeStoreOptions = { 
    state: {}, 
    getters: {}, 
    mutations: {}, 
    actions: {} 
  }

  // calling jest -t factory calls this test as well
  // didn't know that it matches it/test blocks as well
  it("calls createWrapper factory with a component, and options, resumeStoreOptions objects and isShallow boolean", () => {

    const _mountOptions = cloneDeep(mountOptions)

    const localVue = createLocalVue()
    localVue.use(Vuex)
    localVue.use(PortalVue)

    const mockStoreResume = createStore.createMocks().createStoreResumeMocks(resumeStoreOptions)
    const storeConfig = createStore.createMocks({modules: {resume: mockStoreResume}})
    _mountOptions.localVue = localVue

    const store = new Vuex.Store(storeConfig)
    _mountOptions.store = store

    createWrapper(component, _mountOptions)

    expect(factory).toHaveBeenCalledWith(component, _mountOptions)
  })
})


