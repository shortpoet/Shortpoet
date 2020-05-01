import { textMatcher, propMocker, createWrapper } from '../test.utils'
import StartInterests from '@/components/Resume/Start/StartInterests'

describe('StartInterests.vue', () => {

  const component = StartInterests
  let prop
  let element
  let mockProp = true

  beforeEach(() => {

  })

  it('renders interests h2', () => {

    const wrapper = createWrapper(component)
    
    // hard coded header
    expect(wrapper.find("h2").text()).toMatch("Interests")

  })
  it('renders interests p that matches interests prop', () => {

    prop = 'interests'
    element = 'p'
    textMatcher(component, prop, element)

  })
  it('renders photo', () => {

    const wrapper = createWrapper(component, {})

    expect(wrapper.find("img").exists()).toBe(true)

  })
  it('matches snapshot', () => {

    prop = 'interests'
    const wrapper = createWrapper(component, propMocker(prop))
    
    expect(wrapper.html()).toMatchSnapshot()
  })
})
