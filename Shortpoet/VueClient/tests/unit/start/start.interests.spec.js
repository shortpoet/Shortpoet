import { textMatcher, propsMocker, createWrapper } from '../test.utils'
import StartInterests from '@/components/Resume/Start/StartInterests'

describe('StartInterests.vue', () => {

  const component = StartInterests
  const props = Object.keys(component.props)
  const wrapper = createWrapper(component, propsMocker(props))

  let prop
  let selector
  let mockProp = true

  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
  })

  it('renders interests h2', () => {

    // hard coded header
    expect(wrapper.find("h2").text()).toMatch("Interests")

  })
  it('renders interests p that matches interests prop', () => {

    prop = 'interests'
    selector = 'p'
    textMatcher(component, props, prop, selector)

  })
  it('renders photo', () => {

    expect(wrapper.find("img").exists()).toBe(true)

  })
  it('matches snapshot', () => {
    
    expect(wrapper.html()).toMatchSnapshot()

  })
})
