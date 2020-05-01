import { factoryShallow } from '../test.utils'
import { mount, shallowMount, createLocalVue } from '@vue/test-utils'

import Start from '@/views/Start'
import createStore from '@/store'

import Vue from 'vue'
import Vuex from 'vuex'
import PortalVue from 'portal-vue'

const localVue = createLocalVue()

describe('Start.vue', () => {
  let wrapper
  beforeEach(async () => {
    localVue.use(Vuex)
    localVue.use(PortalVue)
    const getResumeLoaded = true

    const propsData = { 
      // name: 'test name' 
    }

    const computed = {
      // getResumeLoaded: () => true
    }

    const mocks = {
      $: jest.fn(() => {
        return {
          click: jest.fn(),
          scrollspy: jest.fn()
        }
      }),
      dispatch: jest.fn()

    }

    // const wrapper = factoryShallow(Start, {mocks: mocks})
    // const wrapper = factoryShallow(Start, {})
    // const wrapper = mount(Start, {mocks: mocks})
    // jest.mock('$')

    const mockStoreResume = createStore.createMocks().createStoreResumeMocks({ 
      getters: { getResumeLoaded: jest.fn(), getResume: jest.fn() }, 
      mutations: { 'SET_RESUME_RAW': jest.fn() } 
    })

    // console.log(mockStoreResume.mutations['SET_RESUME_RAW']())

    const storeConfig = createStore.createMocks({modules: {resume: mockStoreResume}})
    const store = new Vuex.Store(storeConfig)
    await Vue.nextTick()
    wrapper = shallowMount(Start, {localVue, propsData, mocks, store, computed})

  })

  it('matches snapshot', () => {

    expect(wrapper.html()).toMatchSnapshot()
  })
})
