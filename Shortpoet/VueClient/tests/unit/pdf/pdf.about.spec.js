import { textMatcherFactory, createWrapper, propsMocker, propMocker } from '../test.utils'
import PDFAbout from '@/components/Resume/PDF/PDFAbout'
import { cloneDeep } from 'lodash'

describe('PDFAbout.vue', () => {
  beforeEach(() => {
    jest.resetModules()
    jest.clearAllMocks()
  })
  const component = PDFAbout
  // const props = Object.keys(component.props)
  const propDicts = [
    {prop: 'name', selector: 'h2'},
    {prop: 'surname', selector: '#pdf-surname'},
    {prop: 'flags', selector: '#pdf-flags'},
    {prop: 'email', selector: 'a'},
    {prop: 'address', selector: '#pdf-address'},
    {prop: 'visas', selector: '#pdf-visas'},
  ]
  let mockProp = true
  
  const props = propDicts.map(d => d.prop)
  let wrapper = createWrapper(component, propsMocker(props))
  
  const propsObject = propsMocker(props)

  // this function creates an it/test:
  // 'renders interests ${dict.selector} that matches ${dict.prop} prop'
  // for each prop in prop dict
  textMatcherFactory(component, propDicts)

  it('email href matches email prop', () => {
    // interesting that althouhg snapshot includes deeply mounted child (pdfsocials)
    // the wrapper doesn't find those elements
    const prop = 'email'
    const propDict = propDicts.filter(d => d.prop === prop)[0]
    expect(wrapper.find(`${propDict.selector}`).attributes().href).toMatch(propMocker(`${prop}`).propsData[`${prop}`])
  })

  it('renders photo', () => {

    expect(wrapper.find("img").exists()).toBe(true)

  })

  it('matches snapshot', () => {

    let _propsObject = cloneDeep(propsObject)
    _propsObject.propsData.renderPDF = false

    wrapper = createWrapper(component, _propsObject)

    expect(wrapper.html()).toMatchSnapshot()
    
  })

  it('matches renderPDF snapshot', () => {

    let _propsObject = cloneDeep(propsObject)
    _propsObject.propsData.renderPDF = true

    wrapper = createWrapper(component, _propsObject)

    expect(wrapper.html()).toMatchSnapshot()
  })
})
