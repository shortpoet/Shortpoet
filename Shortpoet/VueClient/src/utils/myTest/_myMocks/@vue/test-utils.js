// export default {
//   mount: jest.fn(() => {
//     console.log("mount mock")
//   })
// }
import {createLocalVue} from '@vue/test-utils'

console.log('hello from test-utils mocks')

const test = jest.genMockFromModule('@vue/test-utils')
const component = {}
const localVue = {
  use: jest.fn()
}
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

// test.createLocalVue = jest.fn(() => {
//   return localVue
// })
test.createLocalVue = createLocalVue
module.exports = test

// export default test