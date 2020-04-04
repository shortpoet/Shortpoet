<template>
  <div class="main-wrapper" v-if="getResumeLoaded" id="resume-anchor">
    <StartNav />
    <div class="container-fluid p-0">
      <StartAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :aboutMe="getResume.aboutMe"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
      />
      <StartExperience
        :experiences="getResume.experiences"      
      />
      <StartEducation
        :educations="getResume.educations"
      />
      <StartSkills
        :skills="getResume.skills"
      />
      <StartAwards
        :awards="getResume.spokenLanguages"
      />
      <StartInterests
        :interests="getResume.interests"
      />
    </div>
  </div>
</template>

<script>
import StartNav from '@/components/Resume/Start/Skilz/StartNav.vue'
import StartAbout from '@/components/Resume/Start/Skilz/StartAbout'
import StartExperience from '@/components/Resume/Start/Skilz/StartExperience'
import StartEducation from '@/components/Resume/Start/Skilz/StartEducation'
import StartSkills from '@/components/Resume/Start/Skilz/StartSkills'
import StartInterests from '@/components/Resume/Start/Skilz/StartInterests'
import StartAwards from '@/components/Resume/Start/Skilz/StartAwards'
import { mapGetters, mapActions } from 'vuex'
// import '@/assets/scss/resume.scss'

// const yaml = require('js-yaml')
// import * as fs from 'fs'

export default {
  name: 'Start',
  components: {
    StartNav,
    StartAbout ,
    StartExperience,
    StartEducation,
    StartSkills,
    StartInterests,
    StartAwards
  },
  data () {
    return {
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
  },
  mounted () {
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
@import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900');
@import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i');

// using @ for import doesn't seem to work only relative path
@import './../assets/scss/resume.scss';
</style>
