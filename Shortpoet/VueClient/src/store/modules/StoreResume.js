import axios from 'axios'
// import resume from '@/assets/resume.js'
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
      const resPoint = rootGetters.getEnv === 'production' ? endpoints.resume.RESUME_FETCH_API : endpoints.resume.RESUME_GET_API
      const url = rootGetters.getUrlPrefix + resPoint
      // console.log(url)
      const response = await axios.get(url)
      
      // console.log(response)
      commit(SET_RESUME, response.data)
      // commit(SET_RESUME, resume)

      commit(SET_RESUME_LOADED, true)
      // return response
      // console.info('resume loaded')
      // console.log(state.tableaux)
    } catch (err) {
      // console.error(err)
      commit(SET_RESUME_LOADED, false)
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
