import { createWrapper } from '../test.utils'
import Start from '@/views/Start'

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
      getters: { getResumeLoaded: jest.fn(), getResume: jest.fn() }, 
      mutations: { 'SET_RESUME_RAW': jest.fn() } 
    }

    const wrapperOptions = { propsData, mocks, computed }

    wrapper = createWrapper(Start, wrapperOptions, resumeStoreOptions)

  })

  it('matches snapshot', () => {

    expect(wrapper.html()).toMatchSnapshot()
  })
})
