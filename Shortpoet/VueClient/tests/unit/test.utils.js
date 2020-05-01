import { mount, shallowMount, createLocalVue } from '@vue/test-utils'
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

export const factory = (
  component, 
  options = {
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
  }) => {
    // console.log(options.store)
    return mount(component, options)
  }
export const factoryShallow = (
  component, 
  options = {
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
  }) => {
    return shallowMount(component, options)
  }
