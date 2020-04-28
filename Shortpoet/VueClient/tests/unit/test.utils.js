import { shallowMount, mount } from '@vue/test-utils'


export const factory = (component, propsData = {}) => {
  return mount(component, {
    propsData: {
      ...propsData
    }
  })
}

export const factoryShallow = (component, propsData = {}) => {
  return shallowMount(component, {
    propsData: {
      ...propsData
    }
  })
}
