import * as myTest from '@/utils/myTest'
const { createWrapper } = myTest.default
import Start from '@/views/Start'
import { cloneDeep } from 'lodash'
// import icons from '@/assets/icons.js'
import { createLocalVue } from '@vue/test-utils'
import PortalVue from 'portal-vue'
import { FontAwesomeIcon, FontAwesomeLayers } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCircle, faFilePdf, faSave, faTimes, faRocket} from '@fortawesome/free-solid-svg-icons'


describe('####noop####', () => {

  const component = Start
  const LocalVue = createLocalVue()
  LocalVue.use(PortalVue)
  let wrapper

  let propsData

  let computed

  let resumeStoreOptions

  let mountOptions = {
    propsData: {
      target: 'pdf-button-float',
      href: '/pdf',
      isExpanded: false
    },
    localVue: LocalVue
  }

  // mountOptions.attachToDocument = true
  let expected


  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
    expected = ``

    library.add(
      faCircle, faFilePdf, faSave, faTimes, faRocket
      )

    propsData = {}

    computed = {}

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
    
    resumeStoreOptions = { 
      getters: { getResumeLoaded: jest.fn(() => true), getResume: jest.fn(() => hardResume) }, 
      mutations: { 'SET_RESUME_RAW': jest.fn() } 
    }

    // wrapper = createWrapper(component, mountOptions, resumeStoreOptions)

  })

  describe('element and class checks', () => {

    it('renders correct icon - rocket when isExpanded is false', () => {
      // wrapper = createWrapper(component, mountOptions)

      // expect(wrapper.find('.button-float-icon').attributes().class).toContain('rocket')
    })
    it('renders correct icon - pdf when isExpanded is true', () => {
      // const _mountOptions = cloneDeep(mountOptions)
      // _mountOptions.isExpanded = true
      // wrapper = createWrapper(component, mountOptions)

      // expect(wrapper.find('.button-float-icon').attributes().class).toContain('pdf')
    })

    it('matches snapshot', () => {

      // wrapper = createWrapper(component, mountOptions)
  
      // expect(wrapper.html()).toMatchSnapshot()
  
    })

  })

  describe('screen check', () => {

  })
  
})
