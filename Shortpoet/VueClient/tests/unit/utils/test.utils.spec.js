import {propMocker, propFinder, propsMocker, propsFinder, factory, createWrapper} from '../test.utils.js'
import { createLocalVue } from '@vue/test-utils'
import {cloneDeep} from 'lodash'
import hardResume from '@/assets/resume.js'
import Start from '@/views/Start'
import Vue from 'vue'
import {mount} from '@vue/test-utils'

describe('test.utils', () => {

  // jest.mock('vue-test-utils', () => {
    //   mount = jest.fn()
    // })
    // const mountShallow = jest.fn()
    // const Vue = fest.fn()
    // const component = Start
    // const component = new Vue({name: 'Test'})
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
  // const mount = jest.fn(() => {
  //   return {
  //     component,
  //     mountOptions
  //   }
  // })

  // const mount = jest.fn()

  describe('propMocker', () => {
    it("returns a propsData object mocked in the format prop: sample prop", () => {
      const testProp = 'testProp'
      const output = propMocker(testProp)
      const propsData = {
        propsData: {
          testProp: 'sample testProp'
        }
      }
      expect(output).toMatchObject(propsData)
    })
  })

  describe('propFinder', () => {
    it("returns a propsData object retrieved from hardResume", () => {
      const testProp = 'name'
      const output = propFinder(testProp)
      const propsData = {
        propsData: {
          [`${testProp}`]: hardResume[`${testProp}`]
        }
      }
      expect(output).toMatchObject(propsData)
    })
  })
  describe('propsMocker', () => {
    it("returns multiple propsData object mocked in the format prop: sample prop from array input", () => {
      const testProps = ['testProp', 'sampleProp']
      const output = propsMocker(testProps)
      const propsData = {
        propsData: {
          testProp: 'sample testProp',
          sampleProp: 'sample sampleProp'
        }
      }
      expect(output).toMatchObject(propsData)
    })
    it("returns multiple propsData object mocked in the format prop: sample prop from object input", () => {
      const testProps = ['testProp', 'sampleProp']
      const output = propsMocker(testProps)
      const propsData = {
        propsData: {
          testProp: 'sample testProp',
          sampleProp: 'sample sampleProp'
        }
      }
      expect(output).toMatchObject(propsData)
    })
  })

  describe('propsFinder', () => {
    it("returns multiple propsData object retrieved from hardResume from array input", () => {
      const testProps = ['name', 'surname']
      const output = propsFinder(testProps)
      const propsData = {
        propsData: {
          [`${testProps[0]}`]: hardResume[`${testProps[0]}`],
          [`${testProps[1]}`]: hardResume[`${testProps[1]}`]
        }
      }
      expect(output).toMatchObject(propsData)
    })
  })

  describe('factory', () => {
    it("calls vue-test-utils mount with a component and options object", () => {
      console.log('factory test')
      const _mountOptions = cloneDeep(mountOptions)
      // const localVue = createLocalVue()
      // _mountOptions.localVue = localVue
      // throws  mount.context can only be used when mounting a functional component
      // unless
      // delete _mountOptions.context
      // console.log(localVue)
      
      console.log(mount)
      factory(component, _mountOptions)
      expect(mount).toHaveBeenCalledWith(component, _mountOptions)
    })
  })

  describe('createWrapper', () => {
    it("calls factory with a component, and options, resumeStoreOptions objects and isShallow boolean", () => {
      // console.log('createWrapper test')
      // createWrapper(component, mountOptions)
      // const _mountOptions = cloneDeep(mountOptions)
      // const localVue = createLocalVue()
      // console.log(localVue)
      // _mountOptions.localVue = localVue
      // expect(mount).toHaveBeenCalledWith(component, _mountOptions)
    })
  })

})
