import { factoryShallow } from './../test.utils'
import PDFInterests from '@/components/Resume/PDF/PDFInterests'
describe('PDFInterests.vue', () => {
  it('renders interests h4', () => {
    const wrapper = factoryShallow(PDFInterests, {})
    // hard coded header
    expect(wrapper.find("h4").text()).toMatch("Interests")

  })
  it('renders interests p that matches prop value', () => {

    const sampleInterests = "sample interests"
    const propsData = { 
      interests: sampleInterests 
    }

    const wrapper = factoryShallow(PDFInterests, {propsData: propsData})

    // p set by prop
    expect(wrapper.find("p").text()).toMatch(sampleInterests)

  })
  it('matches snapshot', () => {
    const sampleInterests = "sample interests"
    const propsData = { 
      interests: sampleInterests 
    }
    
    const wrapper = factoryShallow(PDFInterests, {propsData: propsData})

    expect(wrapper.html()).toMatchSnapshot()
  })
})
