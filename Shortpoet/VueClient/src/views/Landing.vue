<template>
  <div class="main-wrapper" v-if="getResumeLoaded" id="resume-anchor">
    <LandingNav />
    <div class="container-fluid p-0">
      <LandingAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
      />
      <LandingSocials 
        :socials="getResume.socials"
      />

    </div>

  </div>
</template>

<script>
import LandingNav from '@/components/Landing/LandingNav.vue'
import LandingAbout from '@/components/Landing/LandingAbout'
import LandingSocials from '@/components/Landing/LandingSocials'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'Start',
  components: {
    LandingNav,
    LandingAbout,
    LandingSocials,
  },
  data () {
    return {
      rippleExpanded: false
    }
  },
  computed: {
    ...mapGetters('resume', ['getResume', 'getResumeLoaded']),
  },
  methods: {
    ...mapActions(['loadEnv']),
    ...mapActions('resume', ['loadResume']),
    toggleVisibility (args) {
      if (args) {
        this.rippleExpanded = !this.rippleExpanded
      } else {
        this.rippleExpanded = args
      }
    },
  },
  mounted () {
    const env = process.env.NODE_ENV
    this.loadEnv(env)
    this.$nextTick(() => {
      // Activate scrollspy to add active class to navbar items on scroll
      this.$('body').scrollspy({
        target: '#sideNav'
      })
      this.loadResume()
    })
  }

}
</script>

<style lang="scss">
// using @ for import doesn't seem to work only relative path
@import './../assets/scss/start.scss';
</style>
