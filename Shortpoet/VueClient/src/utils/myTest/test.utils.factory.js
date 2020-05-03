import { mount } from '@vue/test-utils'


export const factory = (
  component, 
  options = {
    propsData: {},
    localVue: {},
    mocks: {},
    store: {},
    context: {}, // only for functional components
    router: {},
    computed: {},
    stubs: {},
    slots: {},
    scopedSlots: {},
    attrs: {},
    attachToDocument: false,
    attachTo: null, //HTML Element or String
    listeners: {},
    parentComponent: {},
    provide: {}
  }) => {
    // console.log(options)
    // console.log(options.localVue)
    // console.log(options.propsData.experiences[0].jobs)
    console.log(mount)
    return mount(component, options)
  }

module.exports = factory

// export default factory