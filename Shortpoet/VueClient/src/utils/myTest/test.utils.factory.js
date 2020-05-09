import { mount } from '@vue/test-utils'

export const factory = (
  component, 
  /* istanbul ignore next */
  options = {
    propsData: {},
    localVue: {},
    mocks: {},
    store: {},
    // context: {}, // only for functional components
    // this only breaks when testing
    // probably should comment out of real func (which this is (now) hehe)
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
    // console.log(options.mocks)
    // console.log(options.localVue)
    // console.log(options.propsData.experiences[0].jobs)
    // console.log(mount)
    return mount(component, options)
  }

module.exports = factory

// export default factory