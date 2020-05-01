import { mount, shallowMount, createLocalVue } from '@vue/test-utils'
// import VueRouter from 'vue-router'
import Vuex from 'vuex'
import createStore from '@/store'
import PortalVue from 'portal-vue'
import hardResume from '@/assets/resume.js'

export const textMatcherFactory = (component, propDicts) => {
  const props = propDicts.map(d => d.prop)
  console.log(props)
  propDicts.forEach(dict => {
    it(`renders interests ${dict.element} that matches ${dict.prop} prop`, () => {
      console.log(dict.prop)
      console.log(dict.element)
      textMatcher(component, props, dict.prop, dict.element)
  
    })  
  })
}

export const textMatcher = (component, props, prop, element, mock = true) => {
  let wrapper
  if (mock) {
    console.log(prop)
    console.log(element)
    console.log(propMocker(`${prop}`).propsData[`${prop}`])
    wrapper = createWrapper(component, propsMocker(props))
    expect(wrapper.find(`${element}`).text()).toMatch(propMocker(`${prop}`).propsData[`${prop}`])
  } else {
    wrapper = createWrapper(component, propsFinder(props))
    expect(wrapper.find(`${element}`).text()).toMatch(propFinder(`${prop}`).propsData[`${prop}`])
  }
}

export const propFinder = (prop) => {
  return {
    propsData: {
      [`${prop}`]: hardResume[`${prop}`]
    }
  }
}
export const propMocker = (prop) => {
  return {
    propsData: {
      [`${prop}`]: `sample ${prop}`
    }
  }
}

export const propsFinder = (props) => {
  let propsData = {}
  props.map(prop => {
    propsData[`${prop}`] = hardResume[`${prop}`]
  })
  return {
    propsData
  }
}
export const propsMocker = (props) => {
  let propsData = {}
  props.map(prop => {
    propsData[`${prop}`] = `sample ${prop}`
  })
  return {
    propsData
  }
}


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
