const factory = jest.genMockFromModule('../test.utils.factory')

console.log('hello from factory mock module')

// const factory = jest.fn(() => {
//   console.log('mock factory')
// })

// tu.factory = factory

module.exports = factory

