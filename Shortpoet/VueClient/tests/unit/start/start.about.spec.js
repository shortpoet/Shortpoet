import { textMatcher } from '../test.utils'
import StartAbout from '@/components/Resume/Start/StartAbout'

describe('StartAbout.vue', () => {

  const component = StartAbout
  const props = Object.keys(component.props)
  let prop
  let element
  let mockProp = true

  it('renders interests h1 that matches name prop', () => {

    prop = 'name'
    element = 'h1'
    textMatcher(component, props, prop, element)

  })
  it('matches snapshot', () => {
    // prop = 'interests'
    // const wrapper = createWrapper(component, propMocker(prop))
    // expect(wrapper.html()).toMatchSnapshot()
  })
})
