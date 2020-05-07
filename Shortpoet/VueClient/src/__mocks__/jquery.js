const $ = {
  click: jest.fn((...params) => {
    console.log('hello from jquery mock')
    // console.log(params)
    return this
  })
}

export default $