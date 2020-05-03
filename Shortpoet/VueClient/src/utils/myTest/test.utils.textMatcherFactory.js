import textMatcher from './test.utils.textMatcher'

export const textMatcherFactory = (component, propDicts) => {
  const props = propDicts.map(d => d.prop)
  propDicts.forEach(dict => {
    it(`renders interests ${dict.selector} that matches ${dict.prop} prop`, () => {
      textMatcher(component, props, dict.prop, dict.selector)
    })  
  })
}

module.exports = textMatcherFactory