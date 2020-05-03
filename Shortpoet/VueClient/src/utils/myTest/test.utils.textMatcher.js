import createWrapper from './test.utils.createWrapper'
import propMocker from './test.utils.propMocker'
import propsMocker from './test.utils.propsMocker'
import propFinder from './test.utils.propFinder'
import propsFinder from './test.utils.propsFinder'

export const textMatcher = (component, props, prop, selector, mock = true, isShallow = false) => {
  let wrapper
  if (mock) {
    wrapper = createWrapper(component, propsMocker(props))
    expect(wrapper.find(`${selector}`).text()).toMatch(propMocker(`${prop}`).propsData[`${prop}`])
  } else {
    wrapper = createWrapper(component, propsFinder(props))
    expect(wrapper.find(`${selector}`).text()).toMatch(propFinder(`${prop}`).propsData[`${prop}`])
  }
}

module.exports = textMatcher