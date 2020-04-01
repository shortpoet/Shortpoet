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
import StartNav from '@/components/Resume/StartBootstrap/StartNav.vue'
import StartAbout from '@/components/Resume/StartBootstrap/StartAbout'
import StartExperience from '@/components/Resume/StartBootstrap/StartExperience'
import StartEducation from '@/components/Resume/StartBootstrap/StartEducation'
import StartSkills from '@/components/Resume/StartBootstrap/StartSkills'
import StartInterests from '@/components/Resume/StartBootstrap/StartInterests'
import StartAwards from '@/components/Resume/StartBootstrap/StartAwards'
import { mapGetters, mapActions } from 'vuex'

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

<style >

@import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900');
@import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i');

body {
  font-family: 'Open Sans', serif;
  padding-top: 54px;
  color: #868e96;
}
@media (min-width: 992px) {
  body {
    padding-top: 0;
    padding-left: 17rem;
  }
}
h1,
h2,
h3,
h4,
h5,
h6 {
  font-family: 'Saira Extra Condensed', serif;
  font-weight: 700;
  text-transform: uppercase;
  color: #343a40;
}
h1 {
  font-size: 6rem;
  line-height: 5.5rem;
}
h2 {
  font-size: 3.5rem;
}
.subheading {
  text-transform: uppercase;
  font-weight: 500;
  font-family: 'Saira Extra Condensed', serif;
  font-size: 1.35rem;
}
.list-social-icons a {
  color: #495057;
}
.list-social-icons a:hover {
  color: #BD5D38;
}
.list-social-icons a .fa-lg {
  font-size: 1.75rem;
}
.list-icons {
  font-size: 3rem;
}
.list-icons .list-inline-item i:hover {
  color: #BD5D38;
}
#sideNav .navbar-nav .nav-item .nav-link {
  font-weight: 600;
  text-transform: uppercase;
}
@media (min-width: 992px) {
  #sideNav {
    text-align: center;
    position: fixed;
    top: 0;
    left: 0;
    display: flex;
    flex-direction: column;
    width: 17rem;
    height: 100vh;
  }
  #sideNav .navbar-brand {
    display: flex;
    margin: auto auto 0;
    padding: 0.5rem;
  }
  #sideNav .navbar-brand .img-profile {
    max-width: 10rem;
    max-height: 10rem;
    border: 0.5rem solid rgba(255, 255, 255, 0.2);
  }
  #sideNav .navbar-collapse {
    display: flex;
    align-items: flex-start;
    flex-grow: 0;
    width: 100%;
    margin-bottom: auto;
  }
  #sideNav .navbar-collapse .navbar-nav {
    flex-direction: column;
    width: 100%;
  }
  #sideNav .navbar-collapse .navbar-nav .nav-item {
    display: block;
  }
  #sideNav .navbar-collapse .navbar-nav .nav-item .nav-link {
    display: block;
  }
}
section.resume-section {
  border-bottom: 1px solid #dee2e6;
  padding-top: 5rem !important;
  padding-bottom: 5rem !important;
}
section.resume-section .resume-item .resume-date {
  min-width: none;
}
@media (min-width: 768px) {
  section.resume-section {
    min-height: 100vh;
  }
  section.resume-section .resume-item .resume-date {
    min-width: 18rem;
  }
}
@media (min-width: 992px) {
  section.resume-section {
    padding-top: 3rem !important;
    padding-bottom: 3rem !important;
  }
}
.bg-primary {
  background-color: #BD5D38 !important;
}
.text-primary {
  color: #BD5D38 !important;
}
a {
  color: #BD5D38;
}
a:hover, a:focus, a:active {
  color: #824027;
}
</style>