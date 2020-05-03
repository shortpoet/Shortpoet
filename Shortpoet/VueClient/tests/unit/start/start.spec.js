import * as myTest from '@/utils/myTest'
const { createWrapper } = myTest.default
import Start from '@/views/Start'
import hardResume from '@/assets/resume.js'
import { FontAwesomeIcon, FontAwesomeLayers } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCircle, faFilePdf, faSave, faTimes, faRocket} from '@fortawesome/free-solid-svg-icons'

describe('Start.vue', () => {
  let wrapper
  beforeEach(async () => {

    library.add(
      faCircle, faFilePdf, faSave, faTimes, faRocket
      )
    
    const getResumeLoaded = true

    const propsData = { 
      // name: 'test name' 
    }

    const computed = {
      // getResumeLoaded: () => true
    }

    const stubs = {
      FontAwesomeIcon,
      FontAwesomeLayers
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

    const wrapperOptions = { propsData, mocks, computed, stubs }

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
