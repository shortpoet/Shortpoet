
// import * as myTest from '@/utils/myTest'
// const { propMocker, propsMocker, propFinder, propsFinder, createWrapper } = myTest.default


import createWrapper from './test.utils.createWrapper'
import propMocker from './test.utils.propMocker'
import propsMocker from './test.utils.propsMocker'
import propFinder from './test.utils.propFinder'
import propsFinder from './test.utils.propsFinder'

// made this to try and isolate the doMatch logic for testing but still 
// throws cannot call text() on empty wrapper
const funcs = {
  propMocker: propMocker,
  propFinder: propFinder
}

console.log(createWrapper)

export const textMatcher = (component, props, prop, selector, mock = true, isShallow = false) => {
  let wrapper
  const doMatch = (funcName) => {
    const func = funcs[`${funcName}`]
    expect(wrapper.find(`${selector}`).text()).toMatch(func(`${prop}`).propsData[`${prop}`])
  } 
  if (mock) {
    wrapper = createWrapper(component, propsMocker(props))
    doMatch('propMocker')
    // expect(wrapper.find(`${selector}`).text()).toMatch(propMocker(`${prop}`).propsData[`${prop}`])
  } else {
    // console.log(propsFinder)
    wrapper = createWrapper(component, propsFinder(props))
    doMatch('propFinder')
    // expect(wrapper.find(`${selector}`).text()).toMatch(propFinder(`${prop}`).propsData[`${prop}`])
  }
}

module.exports = textMatcher