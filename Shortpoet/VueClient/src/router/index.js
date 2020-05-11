import Vue from 'vue'
import paths from './paths.js'
import {routeMapper} from './routeMapper'
import {scrollBehavior} from './scrollBehavior'

Vue.use(VueRouter)

export const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: routeMapper(paths),
  scrollBehavior: scrollBehavior
})

// console.log(router)
export default {
  router,
  routeMapper
}
