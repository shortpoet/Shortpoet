<template>
  <div class="main-wrapper" v-if="getResumeLoaded" id="resume-anchor">
    <StartNav />
    <div class="container-fluid p-0">
      <StartAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
      />
      <StartSocials />
      <StartSkills
        :skills="getResume.skills"
      />
      <StartAwards
        :spokenLanguages="getResume.spokenLanguages"
      />
      <StartObjective
        :aboutMe="getResume.aboutMe"
      />
      <StartExperience
        :experiences="getResume.experiences"      
      />
      <StartEducation
        :educations="getResume.educations"
      />
      <StartInterests
        :interests="getResume.interests"
      />

      <portal-target class="start target" name="pdf-button-float"/>
      <StartButtonFloat :target="'pdf-button-float'" :href="'/pdf'" :isExpanded="rippleExpanded"  @ripple-open="toggleVisibility(true)" @ripple-close="toggleVisibility(false)" />      

    </div>

  </div>
</template>

<script>
import StartNav from '@/components/Resume/Start/StartNav.vue'
import StartAbout from '@/components/Resume/Start/StartAbout'
import StartSocials from '@/components/Resume/Start/StartSocials'
import StartSkills from '@/components/Resume/Start/StartSkills'
import StartObjective from '@/components/Resume/Start/StartObjective'
import StartExperience from '@/components/Resume/Start/StartExperience'
import StartEducation from '@/components/Resume/Start/StartEducation'
import StartInterests from '@/components/Resume/Start/StartInterests'
import StartAwards from '@/components/Resume/Start/StartAwards'
import StartButtonFloat from '@/components/Resume/Start/StartButtonFloat'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'Start',
  components: {
    StartNav,
    StartAbout,
    StartSocials,
    StartSkills,
    StartObjective,
    StartExperience,
    StartEducation,
    StartInterests,
    StartAwards,
    StartButtonFloat
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
    }
  },
  mounted () {
    // const $ = this.jquery
    const env = process.env.NODE_ENV
    this.loadEnv(env)
    this.$nextTick(() => {
      // possibly move this into utils?  check if global vue jquery $ variable is still needed in that case.  or at all for that matter.
      // our custom jQuery code goes here
      this.$('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
          var target = this.$(this.hash)
          target = target.length ? target : this.$('[name=' + this.hash.slice(1) + ']')
          if (target.length) {
            this.$('html, body').animate({
              scrollTop: (target.offset().top)
            }, 1000, 'easeInOutExpo')
            return false
          }
        }
      })
      // Closes responsive menu when a scroll trigger link is clicked
      this.$('.js-scroll-trigger').click(function () {
        this.$('.navbar-collapse').collapse('hide')
      })
      // Activate scrollspy to add active class to navbar items on scroll
      this.$('body').scrollspy({
        target: '#sideNav'
      })
      this.loadResume()
      // console.log(this)
    })
  }
}
</script>

<style lang="scss">
// using @ for import doesn't seem to work only relative path
@import './../assets/scss/start.scss';
</style>
