import { shallowMount, mount } from '@vue/test-utils'


export const factory = (component, propsData = {}, mocks = {}) => {
  return mount(component, {
    propsData: {
      ...propsData
    },
    mocks: {
      ...mocks
    }
  })
}

export const factoryShallow = (component, options) => {
  const _options = {
    propsData: options.propsData ? options.propsData : {},
    mocks: options.mocks ? options.mocks : {}
  }  
  console.log(_options.propsData)
  console.log(_options.mocks)
  return shallowMount(component, {
    propsData: {
      ..._options.propsData
    },
    mocks: {
      ..._options.mocks
    }
  })
}
