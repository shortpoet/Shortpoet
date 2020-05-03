// export default {
//   mount: jest.fn(() => {
//     console.log("mount mock")
//   })
// }

const test = jest.genMockFromModule('@vue/test-utils')
const component = {}
const mountOptions = {
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
}

test.mount = jest.fn(() => {
  return {
    component,
    mountOptions
  }
})

module.exports = test