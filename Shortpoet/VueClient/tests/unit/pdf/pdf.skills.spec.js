import * as myTest from '@/utils/myTest'
const { createWrapper, propsFinder } = myTest.default
import PDFSkills from '@/components/Resume/PDF/PDFSkills'
import { cloneDeep } from 'lodash'
// import icons from '@/assets/icons.js'

describe('PDFSkills.vue', () => {

  const component = PDFSkills
  // const mountOptions = {
  //   propsData: {
  //     skills: [],
  //   }
  // }

  let wrapper
  const mountOptions = propsFinder(['skills'])
  let expected

  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
    expected = ``
  })

  describe('element and class checks', () => {

    // const _mountOptions = cloneDeep(mountOptions)
    // _mountOptions.propsData.source += ``
    // expected += ``

    it('renders .pdf-skill-type div for each type of skill', () => {
      
      expected += `pdf-skill-type`
      wrapper = createWrapper(component, mountOptions)

      expect(wrapper.find('.pdf-skill-type').attributes().class).toContain(expected)
  
    })

    it('matches snapshot', () => {

      // wrapper = createWrapper(component, _mountOptions)
  
      // expect(wrapper.html()).toMatchSnapshot()
  
    })

  })

  
  // icons.forEach(icon => {
  //   // describe('icons')
  // })

})
