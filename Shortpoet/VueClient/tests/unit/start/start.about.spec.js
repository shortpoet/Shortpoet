import { textMatcherFactory } from '../test.utils'
import StartAbout from '@/components/Resume/Start/StartAbout'

describe('StartAbout.vue', () => {
  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
  })
  const component = StartAbout
  // const props = Object.keys(component.props)
  const propDicts = [
    {prop: 'name', element: 'h1'},
    {prop: 'surname', element: 'span'},
    {prop: 'flags', element: 'span'},
    {prop: 'email', element: 'a'},
    {prop: 'address', element: 'span'},
    {prop: 'visas', element: 'span'},
  ]
  let mockProp = true
  textMatcherFactory(component, propDicts)

  it('matches snapshot', () => {
    // prop = 'interests'
    // const wrapper = createWrapper(component, propMocker(prop))
    // expect(wrapper.html()).toMatchSnapshot()
  })
})
