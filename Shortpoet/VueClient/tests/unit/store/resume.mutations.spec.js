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
  describe('SET_RESUME_RAW', () => {
    it('parses raw resume data and sets state resume', () => {

      const data = {
        aboutMe: 'Test About',
        address: 'Test address',
        brief: 'Test About',
        email: 'Test email',
        flags: 'Test flags',
        interests: 'Test interests',
        name: 'Test name',
        surname: 'Test surname',
        title: 'Test title',
        visas: 'Test visas',
        resumeEducations: [{education: {institution: 'test education'}}],
        resumeJobs: [{job: {company: 'test job', experienceType: 'software'}}, {job: {company: 'test job', experienceType: 'language'}}, {job: {company: 'test job', experienceType: 'sales'}}, {job: {company: 'test job', experienceType: 'hospitality'}}],
        resumeSkills: [{skill: {details: 'test skill'}}],
        resumeSocials: [{social: {social: 'test skill'}}],
        resumeSpokenLanguages: [{spokenLanguages: {language: 'test skill'}}],
        experiences: []
      }
      const newResume = {
        aboutMe: 'Test About',
        address: 'Test address',
        brief: 'Test About',
        email: 'Test email',
        flags: 'Test flags',
        interests: 'Test interests',
        name: 'Test name',
        surname: 'Test surname',
        title: 'Test title',
        visas: 'Test visas',
        educations: [{education: {institution: 'test education'}}],
        jobs: [
          {job: {company: 'test job', experienceType: 'software'}},
          {job: {company: 'test job', experienceType: 'language'}},
          {job: {company: 'test job', experienceType: 'sales'}},
          {job: {company: 'test job', experienceType: 'hospitality'}}
        ],
        skills: [{skill: {details: 'test skill'}}],
        socials: [{social: {social: 'test skill'}}],
        spokenLanguages: [{spokenLanguages: {language: 'test skill'}}],
        experiences: [
          {type: 'software', jobs: [{company: 'test job', experienceType: 'software'}]},
          {type: 'language', jobs: [{company: 'test job', experienceType: 'language'}]},
          {type: 'sales', jobs: [{company: 'test job', experienceType: 'sales'}]}, 
          {type: 'hospitality', jobs: [{company: 'test job', experienceType: 'hospitality'}]}
        ]
      }
      
      SET_RESUME(state, newResume)
      expect(state.resume).toEqual(newResume)
    })    
  })
  describe('SET_RESUME', () => {
    it('sets state resume to newResume', () => {
      const newResume = {
        resume: {
          title: "Test Resume"
        }
      }
      SET_RESUME(state, newResume)
      expect(state.resume).toEqual(newResume)
    })    
  })
  describe('SET_RESUME_LOADED', () => {
    it('sets resume loaded state after resume is loaded', () => {
      SET_RESUME_LOADED(state, true)
      expect(state.resumeLoaded).toBe(true)
    })    
  })
})
