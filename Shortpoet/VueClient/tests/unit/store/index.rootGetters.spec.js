import { getters } from '@/store/index'

describe('Index Store Root Getters', () => {
  let state

  beforeEach(() => {
    state = {
      urlPrefix: "https://www.sample-test.alakazam"
    }
    jest.resetModules()
    jest.clearAllMocks()
  })

  describe('getUrlPrefix', () => {
    it('gets the urlPrefix from root state', () => {
      expect(getters.getUrlPrefix(state)).toEqual("https://www.sample-test.alakazam")
    })    
  })

})
