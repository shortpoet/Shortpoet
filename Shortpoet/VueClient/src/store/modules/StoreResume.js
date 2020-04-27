import axios from 'axios'
import hardResume from '@/assets/resume.js'

import {
  SET_RESUME,
  SET_RESUME_LOADED
} from '@/store/mutation-types'

import {
  endpoints
} from '@/store/api-endpoints'

export const state = {
  resume: {},
  resumeLoaded: false
}

export const getters = {
  getResume: (state) => state.resume,
  getResumeLoaded: (state) => state.resumeLoaded
}

export const mutations = {
  [SET_RESUME] (state, newResume) { state.resume = newResume },
  [SET_RESUME_LOADED] (state, newState) { state.resumeLoaded = newState }
}


export const actions = {
  async loadResume ({ commit, rootGetters }) {
    try {
      const resPoint = rootGetters.getEnv === 'production' ? endpoints.resume.RESUME_FETCH_LATEST_API : endpoints.resume.RESUME_FETCH_LATEST_API
      const url = rootGetters.getUrlPrefix + resPoint
      // const url2 = "https://shortpoet-test.azurewebsites.net/api/Resume/FetchLatest"
      // console.log(url)
      const response = await axios.get(url)
      // console.log(response)
      // const experienceTypes = response.data.resumeJobs.map(j => j.job.experienceType).filter((v, i, a) => a.indexOf(v) === i && v !== null)
      const experienceTypes = ['software', 'language', 'sales', 'hospitality']
      const resume = {
        aboutMe: response.data.aboutMe,
        address: response.data.address,
        brief: response.data.brief,
        email: response.data.email,
        flags: response.data.flags,
        interests: response.data.interests,
        name: response.data.name,
        surname: response.data.surname,
        title: response.data.title,
        visas: response.data.visas,
        educations: response.data.resumeEducations.map(re => re.education),
        jobs: response.data.resumeJobs.map(re => re.job),
        skills: response.data.resumeSkills.map(re => re.skill),
        socials: response.data.resumeSocials.map(re => re.social),
        spokenLanguages: response.data.resumeSpokenLanguages.map(re => re.spokenLanguages),
        experiences: []
      }
      experienceTypes.forEach(et => {
        resume.experiences.push({
          type: et,
          jobs: resume.jobs.filter(j => j.experienceType === et)
        })
      })

      // TODO move this copy function to server-side when updating to update hardResume
      // copy(JSON.parse(JSON.stringify(resume)))
      // console.log(resume)

      commit(SET_RESUME, resume)

      commit(SET_RESUME_LOADED, true)
      // return response
      // console.info('resume loaded')
      // console.log(state.tableaux)
    } catch (err) {
      // console.error(err)
      // adding hardcoded resume in case server call fails on static served version
      commit(SET_RESUME, hardResume)
      // commit(SET_RESUME_LOADED, false)
    }
  }
}

export default {
  namespaced: true,
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
}
