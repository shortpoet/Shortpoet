// import {propMocker, propFinder, propsMocker, propsFinder, factory, createWrapper} from '../test.utils.js'
import { factory } from '@/utils/myTest/test.utils.factory'
import { mount } from '@vue/test-utils'
// jest.mock('@vue/test-utils')

describe('factory', () => {

  beforeEach(() => {
    // require('../test.utils')
  })

  const component = {}
  const mountOptions = {
    propsData: {},
    localVue: {},
    mocks: {},
    store: {},
    context: {}, // only for functional components
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

  it("calls vue-test-utils mount with a component and options object", () => {
    // factory(component, mountOptions)
    // expect(mount).toHaveBeenCalledWith(component, mountOptions)
  })
})



