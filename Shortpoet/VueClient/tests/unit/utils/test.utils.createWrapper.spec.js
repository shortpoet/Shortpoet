import {createWrapper} from '../../../src/utils/myTest/test.utils.createWrapper'
// console.log(createWrapper)
// const _createWrapper = createWrapper

import { createLocalVue } from '../../../src/utils/myTest/__mocks__/@vue/test-utils'
// import { createLocalVue } from '@vue/test-utils'

import {cloneDeep} from 'lodash'

import Vuex from 'vuex'
import PortalVue from 'portal-vue'
import createStore from '@/store'

import factory from '@/utils/myTest/test.utils.factory'

jest.mock('@/utils/myTest/test.utils.factory')

// const factory = jest.fn('factory', () => {
//   console.log("hello from factory mock")
// })

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

  // calls createWrapper from factory a component and options object

  // calling jest -t factory calls this test as well
  // didn't know that it matches it/test blocks as well
  it("calls createWrapper f@ctory with a component, and options, resumeStoreOptions objects and isShallow boolean", () => {
    const _mountOptions = cloneDeep(mountOptions)
    // console.log(createLocalVue)
    const localVue = createLocalVue()
    // console.log(localVue)
    // console.log(localVue.use)
    localVue.use(Vuex)
    localVue.use(PortalVue)
    const mockStoreResume = createStore.createMocks().createStoreResumeMocks(resumeStoreOptions)
    const storeConfig = createStore.createMocks({modules: {resume: mockStoreResume}})
    const store = new Vuex.Store(storeConfig)
    _mountOptions.localVue = localVue
    _mountOptions.store = store

    console.log(factory)
    createWrapper(component, _mountOptions)

    expect(factory).toHaveBeenCalledWith(component, _mountOptions)
  })
})


