import { createWrapper } from '../test.utils'
import Start from '@/views/Start'
import hardResume from '@/assets/resume.js'

describe('Start.vue', () => {
  let wrapper
  beforeEach(async () => {

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

    const resumeStoreOptions = { 
      getters: { getResumeLoaded: jest.fn(() => true), getResume: jest.fn(() => hardResume) }, 
      mutations: { 'SET_RESUME_RAW': jest.fn() } 
    }

    const wrapperOptions = { propsData, mocks, computed }

    wrapper = createWrapper(Start, wrapperOptions, resumeStoreOptions)
    jest.resetModules()
    jest.clearAllMocks()
  })

  // TODO somehow test for latest resume
  // perhaps that's a backend test
  // would like to match hardresume file to 
  // chosen 'latest' version 
  it('matches hard resume snapshot', () => {
    expect(wrapper.html()).toMatchSnapshot()
  })
})
