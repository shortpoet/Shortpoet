<template>
  <div class="" v-if="getResumeLoaded" id="pdf-anchor">
    <div class="p-10">
      <PDFAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
      />
      <PDFBorder class="my-2" :size=".25"/>
      <PDFSkills
        :skills="getResume.skills"
      />

      <!-- objective rows -->
      <!-- ml-3 to match pic -->
      <div class="resume-section ml-3">
        <PDFObjective :aboutMe="getResume.aboutMe" />
      </div>

      <PDFExperience
        :experiences="getResume.experiences"      
      />
      <PDFEducation
        :educations="getResume.educations"
      />
      <div id="interests-container" class="d-flex flex-column ml-5">
        <div id="poem-awards-row" class="d-flex flex-row">
          <div id="poem-container" class="mt-5 mr-1">
            <img class="img-fluid img-profile rounded" :src="pic" alt="poem" :style="{height: '16rem', width: '16rem'}">
          </div>
          <div id="awards-container" class="mt-5 ml-5">
            <PDFAwards :awards="getResume.spokenLanguages"/>
          </div>
        </div>
        <div id="interests-row" class="mt-4 mr-5">
          <PDFInterests
            :interests="getResume.interests"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PDFAbout from '@/components/Resume/PDF/Skilz/PDFAbout'
import PDFBorder from '@/components/Resume/PDF/Skilz/PDFBorder'
import PDFSkills from '@/components/Resume/PDF/Skilz/PDFSkills'
import PDFAwards from '@/components/Resume/PDF/Skilz/PDFAwards'
import PDFObjective from '@/components/Resume/PDF/Skilz/PDFObjective'
import PDFExperience from '@/components/Resume/PDF/Skilz/PDFExperience'
import PDFEducation from '@/components/Resume/PDF/Skilz/PDFEducation'
import PDFInterests from '@/components/Resume/PDF/Skilz/PDFInterests'

import { mapGetters, mapActions } from 'vuex'

// const yaml = require('js-yaml')
// import * as fs from 'fs'

export default {
  name: 'Resume',
  components: {
    PDFAbout ,
    PDFBorder,
    PDFSkills,
    PDFAwards,
    PDFObjective,
    PDFExperience,
    PDFEducation,
    PDFInterests
  },
  data () {
    return {
      pic: require('@/assets/poem.jpg'),
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
@import './../assets/scss/pdf-skilz.scss';

// // A4 page dimensions supposedly
// #pdf-anchor {
//   height: 842px;
//   width: 595px;
// }

</style>
