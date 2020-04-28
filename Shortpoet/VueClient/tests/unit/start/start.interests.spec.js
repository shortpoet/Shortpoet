import { factoryShallow } from '../test.utils'
import StartInterests from '@/components/Resume/Start/StartInterests'
console.log(factoryShallow)
describe('StartInterests.vue', () => {
  it('renders interests h2', () => {

    const wrapper = factoryShallow(StartInterests)
    
    // hard coded header
    expect(wrapper.find("h2").text()).toMatch("Interests")

  })
  it('renders interests p that matches prop value', () => {

    const sampleInterests = "sample interests"
    const propsData = { 
      interests: sampleInterests 
    }
    const wrapper = factoryShallow(StartInterests, propsData)

    // p set by prop
    expect(wrapper.find("p").text()).toMatch(sampleInterests)

  })
  it('renders photo', () => {

    const wrapper = factoryShallow(StartInterests)

    expect(wrapper.find("img").exists()).toBe(true)

  })
})
