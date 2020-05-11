// TODO organize rest of tests' imports like this

// test utils
import * as myTest from '@/utils/myTest'
const { createWrapper } = myTest.default
import { createLocalVue } from '@vue/test-utils'

// utils
import { cloneDeep } from 'lodash'
import Vue from 'vue'
import { log } from '@/utils/colorLog'

// plugins
import PortalVue from 'portal-vue'
import { FontAwesomeIcon, FontAwesomeLayers } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core'
import { faCircle, faFilePdf, faSave, faTimes, faRocket} from '@fortawesome/free-solid-svg-icons'

// SUT
import PDFButtonFloat from '@/components/Resume/PDF/PDFButtonFloat'
import PDF from '@/views/PDF'
import hardResume from '@/assets/resume.js'

// mocks
// the first way wasn't being 'called'
// it was loggin as a mock function but not the one being used in 
// wrapper
// import jspdf from '@/__mocks__/jspdf'
import jspdf, {addImage} from 'jspdf'
jest.mock('jspdf')
// similar to mocking @vue/testutils
// folders had to be nested just like source module for mock to work

import html2canvas from '@trainiac/html2canvas'
// import html2canvas from '@/__mocks__/@trainiac/html2canvas'
import fontfaceobserver from 'fontfaceobserver'
// import fontfaceobserver from '@/__mocks__/fontfaceobserver'

jest.useFakeTimers()

let wrapper

describe('pdf.pdfButtonFloat', () => {

  const component = PDFButtonFloat

  let methods = component.methods

  const LocalVue = createLocalVue()
  LocalVue.use(PortalVue)

  let propsData

  let computed

  let stubs

  let mocks

  let ignoredElements

  let resumeStoreOptions

  let mountOptions

  let expected

  const events =  ['click', 'touchstart', 'touchcancel', 'touchmove', 'touchend']

  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
    
    jspdf.mockClear()
    addImage.mockClear()

    jest.useFakeTimers()

    expected = ``

    library.add(
      faCircle, faFilePdf, faSave, faTimes, faRocket
    )

    stubs = {
      FontAwesomeIcon,
      FontAwesomeLayers
    }
  
    propsData = {
      target: 'save-button-float',
      icon: 'save',
      pdfTarget: 'pdf-anchor'
    }
  
    computed = {}


    ignoredElements = [
      // 'portal'
    ]

    mocks = {
    }
    
    mountOptions = {
      propsData: propsData,
      stubs: stubs
    }

    // mountOptions.attachToDocument = true

    const getResumeLoaded = true

    resumeStoreOptions = { 
      getters: { getResumeLoaded: jest.fn(() => getResumeLoaded), getResume: jest.fn(() => hardResume) }, 
      mutations: { 'SET_RESUME_RAW': jest.fn() } 
    }

    // wrapper = createWrapper(component, mountOptions, resumeStoreOptions)

  })

  describe('pdf.pdfButtonFloat.toPDF', () => {

    it('modal should already be closed by bubbled emit event and by default', () => {
      
      // methods.toPDF()
      // expect(wrapper.vm.isModalVisible).toBe(false)
    })

    it('canvas context should match snapshot', async () => {
      /**
       * In order to see which functions and properties were used for the test, you can use `__getEvents`
       * to gather this information.
       */
      // const events = ctx.__getEvents()
      
      // expect(events).toMatchSnapshot()
      // const canvas = await methods.toPDF()
      // console.log(canvas)
      // expect(html2canvas).toHaveBeenCalled()
    })
  })

  describe('pdf.pdfButtonFloat.showModal', () => {
    it('should show modal by changing isModalVisible to true', () => {
      wrapper = createWrapper(component, mountOptions, resumeStoreOptions)
      expect(wrapper.vm.isModalVisible).toBe(false)
      // 1st error being thrown seemed to be from test thinking this.isModalVisible was a function assignment
      // fixed by changing to .call()
      // then error bec no this context in test to added wrapper.vm
      // https://medium.com/@lachlanmiller_52885/data-and-interaction-testing-in-vue-e7914a9179d7
      methods.showModal.call(wrapper.vm)
      expect(wrapper.vm.isModalVisible).toBe(true)
    })
  })

  describe('pdf.pdfButtonFloat.closeModal', () => {
    it('should close modal by changing isModalVisible to false', async () => {
      const data = () => {
        return {
          isModalVisible: true
        }
      }
      mountOptions = {
        propsData: propsData,
        data: data
      }
  
      wrapper = createWrapper(component, mountOptions, resumeStoreOptions)

      expect(wrapper.vm.isModalVisible).toBe(true)
      methods.closeModal.call(wrapper.vm)
      expect(wrapper.vm.isModalVisible).toBe(false)
    })
  })

  describe('pdf.pdfButtonFloat.checkFonts', () => {
    it('should call fontfaceobserver', async () => {
      wrapper = createWrapper(component, mountOptions, resumeStoreOptions)
      await methods.checkFonts.call(wrapper.vm)
      expect(fontfaceobserver).toHaveBeenCalled()
    })
  })

  describe('pdf.pdfButtonFloat.getCanvas', () => {
    it('should call html2canvas with options', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      // had to create wrapper from parent component because using vue portal
      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      // this wasy doesn't load the context needed for method to run correctly
      // await methods.getCanvas(options)

      await wrapper.find(PDFButtonFloat).vm.getCanvas(options)
      
      const target = document.getElementById(wrapper.find(PDFButtonFloat).vm.pdfTarget)
      
      expect(html2canvas).toHaveBeenCalledWith(target, options)
    
    })
  })

  describe('pdf.pdfButtonFloat.createDoc', () => {
    it('should return doc with dimensions', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      
      wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL})

      const canvas = await wrapper.find(PDFButtonFloat).vm.getCanvas(options)

      const createDoc = await wrapper.find(PDFButtonFloat).vm.createDoc(canvas)
      const doc = new jspdf('p', 'mm', 'a4');

      expect(createDoc).toMatchObject({
        doc: doc,
        marginX: 0,
        marginY: 0,
        canvasWidth: 888,
        canvasHeight: 888
      })

    })

  })

  describe('pdf.pdfButtonFloat.toPDF', () => {
    it('should call jsPDF with options', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL})

      const doc = new jspdf('p', 'mm', 'a4');

      expect(jspdf).toHaveBeenCalledTimes(1)

      const canvas = await wrapper.find(PDFButtonFloat).vm.getCanvas(options)

      const toPDF = await wrapper.find(PDFButtonFloat).vm.toPDF(canvas)

      expect(toPDF).toMatchObject(doc)
    
    })
  })
  describe('pdf.pdfButtonFloat.setCanvas', () => {
    it('calls getCanvas assigning returned value to component data after 250s timeout', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL})

      const callback = jest.fn()

      await wrapper.find(PDFButtonFloat).vm.setCanvas(options, callback)

      const canvas = { width: 888, height: 888 }

      expect(wrapper.find(PDFButtonFloat).vm.canvas).toBeNull()

      jest.advanceTimersByTime(250)
      await Promise.resolve()

      expect(wrapper.find(PDFButtonFloat).vm.canvas).toMatchObject(canvas)

    })
  })
  describe('pdf.pdfButtonFloat.savePDF', () => {
    it('should call jsPDF with options', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      // had to create wrapper from parent component because using vue portal
      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      // this wasy doesn't load the context needed for method to run correctly
      // await methods.getCanvas(options)

      // const getCanvas = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      

      
      wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL})

      // let savePDF = await wrapper.find(PDFButtonFloat).vm.savePDF()
      // console.log(savePDF)
      // const doc = new jspdf('p', 'mm', 'a4');
      // expect(savePDF).toBeUndefined()

      // expect(jspdf).toHaveBeenCalledTimes(1)
      
      // // jest.advanceTimersByTime(250)
      // // await Promise.resolve()
      
      // console.log(savePDF)
      
      // const fileName = `Carlos_Soriano_${Date.now()}.pdf`
      
      // expect(savePDF).toMatchObject({doc, fileName})


      // jest.advanceTimersByTime(250)

      return wrapper.find(PDFButtonFloat).vm.savePDF().then( async (first) => {
        jest.advanceTimersByTime(250)
        await Promise.resolve()
        console.log(first)
      }).then(async (next) => {
        jest.advanceTimersByTime(250)
        await Promise.resolve()
        // this gets called right after timeout
        // and before callback
        console.log(next)
      }).then(async (next2) => {
        jest.advanceTimersByTime(250)
        await Promise.resolve()
        // by now doc has been logged from callback
        console.log(next2)
      }).then(async (next3) => {
        jest.advanceTimersByTime(250)
        await Promise.resolve()
        console.log(next3)
      })



    })
  })
  describe('pdf.pdfButtonFloat.toPage', () => {

    it('rerenders the page after emitting to-render-pdf', async () => {

      mocks = {
        dispatch: jest.fn()
      }

      mountOptions = {
        propsData: propsData,
        mocks: mocks,
        stubs: stubs,
        attachToDocument: true
      }

      // had to create wrapper from parent component because using vue portal
      wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)

      const options = {
        width: 810,
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }

      const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')

      const setCanvas = jest.fn()

      const paginate = jest.fn()
            
      wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL, setCanvas: setCanvas, paginate: paginate})

      await wrapper.find(PDFButtonFloat).vm.toPage()

      expect(wrapper.find(PDFButtonFloat).emitted()).toMatchObject({'to-render-pdf': [[true]]})

      expect(setCanvas).toHaveBeenCalledWith(options, paginate)

    })

  })


  describe('pdf.pdfButtonFloat.paginate', () => {
    it('divides up the page into chunks that fit an a4', async () => {

      //   mocks = {
      //     dispatch: jest.fn()
      //   }
  
      //   mountOptions = {
      //     propsData: propsData,
      //     mocks: mocks,
      //     stubs: stubs,
      //     attachToDocument: true
      //   }
  
      //   // had to create wrapper from parent component because using vue portal
      //   wrapper = createWrapper(PDF, mountOptions, resumeStoreOptions)
  
      //   const options = {
      //     scale: 5,
      //     useCORS: true,
      //     allowTaint: true,
      //   }
  
      //   // this wasy doesn't load the context needed for method to run correctly
      //   // await methods.getCanvas(options)
  
      //   // const getCanvas = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
      //   const getDataURL = jest.fn(() => 'data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==')
        
  
        
      //   wrapper.find(PDFButtonFloat).setMethods({getDataURL: getDataURL})
  
      //   // let savePDF = await wrapper.find(PDFButtonFloat).vm.savePDF()
      //   // console.log(savePDF)
      //   // const doc = new jspdf('p', 'mm', 'a4');
      //   // expect(savePDF).toBeUndefined()
  
      //   // expect(jspdf).toHaveBeenCalledTimes(1)
        
      //   // // jest.advanceTimersByTime(250)
      //   // // await Promise.resolve()
        
      //   // console.log(savePDF)
        
      //   // const fileName = `Carlos_Soriano_${Date.now()}.pdf`
        
      //   // expect(savePDF).toMatchObject({doc, fileName})
  
  
      //   // jest.advanceTimersByTime(250)
  
      //   return wrapper.find(PDFButtonFloat).vm.savePDF().then( async (first) => {
      //     jest.advanceTimersByTime(250)
      //     await Promise.resolve()
      //     console.log(first)
      //   }).then(async (next) => {
      //     jest.advanceTimersByTime(250)
      //     await Promise.resolve()
      //     // this gets called right after timeout
      //     // and before callback
      //     console.log(next)
      //   }).then(async (next2) => {
      //     jest.advanceTimersByTime(250)
      //     await Promise.resolve()
      //     // by now doc has been logged from callback
      //     console.log(next2)
      //   }).then(async (next3) => {
      //     jest.advanceTimersByTime(250)
      //     await Promise.resolve()
      //     console.log(next3)
      //   })
  
  
  
      })
    })

  describe('pdf.pdfButtonFloat.snapshot', () => {
    it('should match snapshot', () => {
      wrapper = createWrapper(component, mountOptions, resumeStoreOptions)

      expect(wrapper.html()).toMatchSnapshot()
    })
  })

})
