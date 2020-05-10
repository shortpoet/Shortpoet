import * as myTest from '@/utils/myTest'
const { createWrapper } = myTest.default
import PDFButtonFloat from '@/components/Resume/PDF/PDFButtonFloat'
import { cloneDeep } from 'lodash'
// import icons from '@/assets/icons.js'
import { createLocalVue } from '@vue/test-utils'
import PortalVue from 'portal-vue'
import { FontAwesomeIcon, FontAwesomeLayers } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCircle, faFilePdf, faSave, faTimes, faRocket} from '@fortawesome/free-solid-svg-icons'


describe('start.pdfButtonFloat', () => {

  const component = PDFButtonFloat

  let methods = component.methods

  const LocalVue = createLocalVue()
  LocalVue.use(PortalVue)
  let wrapper

  let propsData

  let computed

  let stubs

  let mocks

  let ignoredElements

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

  const events =  ['click', 'touchstart', 'touchcancel', 'touchmove', 'touchend']

  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
    expected = ``

    library.add(
      faCircle, faFilePdf, faSave, faTimes, faRocket
      )

    propsData = {}

    computed = {}

    stubs = {
      FontAwesomeIcon,
      FontAwesomeLayers
    }

    ignoredElements = [
      // 'portal'
    ]

    mocks = {
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

  describe()
  
})
