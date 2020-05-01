import { textMatcher, propMocker, createWrapper } from './../test.utils'
import PDFInterests from '@/components/Resume/PDF/PDFInterests'
describe('PDFInterests.vue', () => {

  const component = PDFInterests
  const props = Object.keys(component.props)
  let prop
  let selector
  let mockProp = true

  it('renders interests h4', () => {
    const wrapper = createWrapper(component, {})

    // hard coded header
    expect(wrapper.find("h4").text()).toMatch("Interests")

  })
  it('renders interests p that matches prop value', () => {

    prop = 'interests'
    selector = 'p'
    textMatcher(component, props, prop, selector)

  })
  it('matches snapshot', () => {

    prop = 'interests'
    const wrapper = createWrapper(component, propMocker(prop))

    expect(wrapper.html()).toMatchSnapshot()
  })
})
