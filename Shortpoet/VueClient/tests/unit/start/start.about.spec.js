import { createWrapper } from '../test.utils'
import StartAbout from '@/components/Resume/Start/StartAbout'
describe('StartInterests.vue', () => {
  it('renders interests h2', () => {

    // const wrapper = createWrapper(StartAbout)
    
    // // hard coded header
    // expect(wrapper.find("h2").text()).toMatch("Interests")

  })
  it('renders interests p that matches prop value', () => {

    // const sampleInterests = "sample interests"
    // const propsData = { 
    //   interests: sampleInterests 
    // }
    // const wrapper = factoryShallow(StartAbout, {propsData: propsData})

    // // p set by prop
    // expect(wrapper.find("p").text()).toMatch(sampleInterests)

  })
  it('renders photo', () => {

    // const wrapper = factoryShallow(StartAbout, {})

    // expect(wrapper.find("img").exists()).toBe(true)

  })
  it('matches snapshot', () => {
    // const sampleInterests = "sample interests"
    // const propsData = { 
    //   interests: sampleInterests 
    // }
    // const wrapper = factoryShallow(StartAbout, {propsData: propsData})
    // expect(wrapper.html()).toMatchSnapshot()
  })
})
