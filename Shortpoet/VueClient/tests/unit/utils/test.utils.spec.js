import {propMocker} from '../test.utils.js'

describe('propMocker', () => {
  it("returns a propsData object mocked in the format prop: sample prop", () => {
    const testProp = 'testProp'
    const output = propMocker(testProp)
    const propsData = {
      propsData: {
        testProp: 'sample testProp'
      }
    }
    expect(output).toMatchObject(propsData)
  })
})