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
        :awards="getResume.spokenLanguages"
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

      <!-- <portal-target class="start target" name="pdf-button-float" />
      <div v-if="rippleExpanded" class="ripple-closer" v-on:click.capture="toggleVisibility(false)">
        <StartButtonFloat :target="'pdf-button-float'" :icon="'pdf'" :href="'/pdf'" :isExpanded="rippleExpanded" />
      </div>
      <StartButtonFloat v-else :target="'pdf-button-float'" :icon="'pdf'" :href="'/pdf'" :isExpanded="rippleExpanded" @ripple="toggleVisibility(true)"/>      
 -->
      <portal-target class="start target" name="pdf-button-float"/>
      <StartButtonFloat :target="'pdf-button-float'" :icon="'pdf'" :href="'/pdf'" :isExpanded="rippleExpanded"  @ripple-open="toggleVisibility(true)" @ripple-close="toggleVisibility(false)" />      


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
// import '@/assets/scss/resume.scss'

// const yaml = require('js-yaml')
// import * as fs from 'fs'

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
    resume () {
      return this.getResume.skills.forEach(skill => {
        console.log(skill)
        skill.details = skill.details.split(',')
        console.log(skill)
      })
    }
  },
  methods: {
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
    console.log('mounted from start')
    console.log(this.rippleExpanded)
    const $ = this.jquery
    this.$nextTick(() => {
      // possibly move this into utils?  check if global vue jquery $ variable is still needed in that case.  or at all for that matter.
      // our custom jQuery code goes here
      $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
          var target = $(this.hash)
          target = target.length ? target : $('[name=' + this.hash.slice(1) + ']')
          if (target.length) {
            $('html, body').animate({
              scrollTop: (target.offset().top)
            }, 1000, 'easeInOutExpo')
            return false
          }
        }
      })
      // Closes responsive menu when a scroll trigger link is clicked
      $('.js-scroll-trigger').click(function () {
        $('.navbar-collapse').collapse('hide')
      })
      // Activate scrollspy to add active class to navbar items on scroll
      $('body').scrollspy({
        target: '#sideNav'
      })
      this.loadResume()
    })
  }
}
</script>

<style lang="scss">
// why i can't get this font thing to work with the plugin is beyond me for now :shrug
// @import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900');
// @import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i');

// using @ for import doesn't seem to work only relative path
@import './../assets/scss/start.scss';
</style>
