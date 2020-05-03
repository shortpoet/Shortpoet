// import {propMocker, propFinder, propsMocker, propsFinder, factory, createWrapper} from '../test.utils.js'
import {createWrapper} from '../test.utils.js'

import { mount, createLocalVue } from '@vue/test-utils'
import {cloneDeep} from 'lodash'
import hardResume from '@/assets/resume.js'
import Start from '@/views/Start'
import Vue from 'vue'
import Vuex from 'vuex'
import PortalVue from 'portal-vue'
import createStore from '@/store'
const utilsMock = jest.mock('../test.utils')
// console.log(utilsMock)

describe('createWrapper', () => {

  beforeEach(() => {
    require('../test.utils')
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

  it("calls factory with a component, and options, resumeStoreOptions objects and isShallow boolean", () => {
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
    createWrapper(component, mountOptions)

    expect(factory).toHaveBeenCalledWith(component, _mountOptions)
  })
})


