<template>
  <div class="" v-if="getResumeLoaded" id="resume-anchor">
    <div class="p-10">
      <PDFAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :aboutMe="getResume.aboutMe"
        :address="getResume.address"
      />
      <PDFExperience
        :experiences="getResume.experiences"      
      />
      <PDFEducation
        :educations="getResume.educations"
      />
      <PDFSkills
        :skills="getResume.skills"
      />
      <PDFInterests
        :awards="getResume.spokenLanguages"
      />
      <PDFAwards
        :interests="getResume.interests"
      />
    </div>
  </div>
</template>

<script>
import PDFAbout from '@/components/Resume/PDF/PDFAbout'
import PDFExperience from '@/components/Resume/PDF/PDFExperience'
import PDFEducation from '@/components/Resume/PDF/PDFEducation'
import PDFSkills from '@/components/Resume/PDF/PDFSkills'
import PDFInterests from '@/components/Resume/PDF/PDFInterests'
import PDFAwards from '@/components/Resume/PDF/PDFAwards'
import { mapGetters, mapActions } from 'vuex'

// const yaml = require('js-yaml')
// import * as fs from 'fs'

export default {
  name: 'Resume',
  components: {
    PDFAbout ,
    PDFExperience,
    PDFEducation,
    PDFSkills,
    PDFInterests,
    PDFAwards
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

@import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900');
@import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i');
@import './../assets/scss/pdf.scss';

</style>
