import { mutations } from '@/store/modules/StoreResume'

const { SET_RESUME, SET_RESUME_LOADED } = mutations

describe('Resume Store Mutations', () => {
  let state

  beforeEach(() => {
    state = {
      resume: null,
      resumeLoaded: false
    }
  })
  describe('SET_RESUME', () => {
    it('sets state resume to newResume', () => {
      const newResume = {
        resume: {
          title: "Test Resume"
        },
        resumeLoaded: true
      }
      SET_RESUME(state, newResume)
      expect(state.resume).toEqual(newResume)
    })    
  })
  describe('SET_RESUME_LOADED', () => {
    it('sets resume loaded state after resume is loaded', () => {
      const newResume = {
        resume: {
          title: "Test Resume"
        },
        resumeLoaded: true
      }
      SET_RESUME_LOADED(state, true)
      expect(state.resumeLoaded).toBe(true)
    })    
  })
})
