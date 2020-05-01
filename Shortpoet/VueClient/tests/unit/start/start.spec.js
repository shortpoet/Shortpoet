import { factoryShallow } from '../test.utils'
import { mount, shallowMount, createLocalVue } from '@vue/test-utils'

import Start from '@/views/Start'
import createStore from '@/store'

import Vuex from 'vuex'
import PortalVue from 'portal-vue'

const localVue = createLocalVue()
localVue.use(Vuex)
localVue.use(PortalVue)

describe('Start.vue', () => {
  it('matches snapshot', () => {
    const getResumeLoaded = true

    // const propsData = { 
    //   interests: sampleInterests 
    // }

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
      dispatch: jest.fn(),

      // getResumeLoaded: jest.fn(() => getResumeLoaded)
    }

    // const wrapper = factoryShallow(Start, {mocks: mocks})
    // const wrapper = factoryShallow(Start, {})
    // const wrapper = mount(Start, {mocks: mocks})
    // jest.mock('$')

    const mockStoreResume = createStore.createMocks().createStoreResumeMocks({ mutations: { 'SET_RESUME_RAW': jest.fn() } })
    console.log(mockStoreResume.mutations['SET_RESUME_RAW']())
    const storeConfig = createStore.createMocks({modules: {resume: mockStoreResume}})
    const store = new Vuex.Store(storeConfig)
    const wrapper = shallowMount(Start, {localVue, mocks, store, computed})
    expect(wrapper.html()).toMatchSnapshot()
  })
})
