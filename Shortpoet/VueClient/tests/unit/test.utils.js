import { mount, shallowMount, createLocalVue } from '@vue/test-utils'
// import VueRouter from 'vue-router'
import Vuex from 'vuex'
import createStore from '@/store'
import PortalVue from 'portal-vue'
import hardResume from '@/assets/resume.js'

export const textMatcherFactory = (component, propDicts) => {
  const props = propDicts.map(d => d.prop)
  propDicts.forEach(dict => {
    it(`renders interests ${dict.selector} that matches ${dict.prop} prop`, () => {
      textMatcher(component, props, dict.prop, dict.selector)
    })  
  })
}

export const textMatcher = (component, props, prop, selector, mock = true, isShallow = false) => {
  let wrapper
  if (mock) {
    wrapper = createWrapper(component, propsMocker(props))
    expect(wrapper.find(`${selector}`).text()).toMatch(propMocker(`${prop}`).propsData[`${prop}`])
  } else {
    wrapper = createWrapper(component, propsFinder(props))
    expect(wrapper.find(`${selector}`).text()).toMatch(propFinder(`${prop}`).propsData[`${prop}`])
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
  // console.log(propsData)
  return {
    propsData
  }
}
export const propsMocker = (props) => {
  if (Array.isArray(props)) {
    let propsData = {}
    props.map(prop => {
      propsData[`${prop}`] = `sample ${prop}`
    })
    return {
      propsData
    }
  } else if (typeof(props) === 'object') {
    let propsData = {}
    const key = Object.keys(props)[0]
    // spread to clone so the splice works on subsequent tests
    let values = [...props[`${key}`]]
    const length = parseInt(values.splice(-1, 1)[0])
    const iterator = [...Array(length).keys()]
    propsData[`${key}`] = []
    let keyDict
    for (let i of iterator) {
      keyDict = {}
      values.map(prop => {
        keyDict[`${prop}`] = `sample ${prop}`
      })
      propsData[`${key}`].push(keyDict)
    }
    return {
      propsData
    }
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
    // console.log(options)
    // console.log(options.propsData.experiences[0].jobs)
    // console.log(mount)
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
  
  // const tu = {}

  // tu.factory = factory
  // tu.factoryShallow = factoryShallow
  // tu.createWrapper = createWrapper
  // tu.propFinder = propFinder
  // tu.propMocker = propMocker
  // tu.propsFinder = propsFinder
  // tu.propsMocker = propsMocker
  // tu.textMatcher = textMatcher
  // tu.textMatcherFactory = textMatcherFactory
  
  // module.exports = tu
  

// this is incomplete
// maybe try and develop using TDD  
  
// export const _propsMocker = (props) => {

//   console.log(props)

//   let propsData = {}


//   const handleArray = (props) => {
//     propsData = {}
//     props.map(prop => {
//       propsData[`${prop}`] = `sample ${prop}`
//     })
//     return {
//       propsData
//     }
//   }


//   const handleNested = (props, propsData, previousKey, nextKey) => {
//     console.log(props, propsData)

//     let firstLevel
//     if (previousKey === null && nextKey === null) {
//       firstLevel = true
//     }

//     // spread to clone so the splice works on subsequent tests
//     let values = [...props]

//     const length = parseInt(values.splice(-1, 1)[0])
//     console.log(length)
//     const iterator = [...Array(length).keys()]

//     if (firstLevel === true) {
//       previousKey = values.splice(0, 1)[0]
//       propsData[`${previousKey}`] = []
//     } else {
//       console.log('#### not first run ####')
//       console.log(propsData)
//       console.log(previousKey)
//       nextKey = values.splice(0, 1)[0]
//       console.log(nextKey)
//       propsData[`${previousKey}`][`${nextKey}`] = []
//     }


//     let keyDict

//     for (let i of iterator) {
//       keyDict = {}
//       values.map(prop => {
//         if (Array.isArray(prop)) {
//           console.log(prop)
//           console.log('#### calling handleNested from nested ####')
//           // this would only work for one level nested
//           // TODO maybe refactor for infinite recursion
//           console.log(previousKey)
//           console.log(nextKey)
//           console.log(propsData)
//           handleNested(prop, propsData, previousKey, nextKey)
//         } else {
//           console.log(prop)
//           keyDict[`${prop}`] = `sample ${prop}`
//         }
//       })
//       if (firstLevel === true) {
//         propsData[`${previousKey}`].push(keyDict)
//         firstRun = false
//       } else {
//         console.log(propsData)
//         console.log(previousKey)
//         console.log(nextKey)
//         console.log(propsData.experiences)
//         console.log(propsData.experiences.jobs)
//         propsData[`${previousKey}`][`${nextKey}`].push(keyDict)
//       }
//     }
//     return {
//       propsData
//     }
//   }

//   const isNested = props.some(p => Array.isArray(p))
//   const previousKey = null
//   const nextKey = null

//   if (isNested) {
//     console.log('#### is nested ####')
//     handleNested(props, propsData, previousKey, nextKey)
//   } else  {
//     handleArray(props)
//   }
// }
