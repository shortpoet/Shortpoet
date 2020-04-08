<template>
  <div class="" v-if="getResumeLoaded" id="pdf-anchor">
    <div class="p-10">
      <portal-target name="save-button-float" />
      <PDFAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
      />
      <PDFBorder class="my-2" :size=".25"/>
      <div class="skills-awards-container row ml-3">
        <div class="awards-col col-12 col-lg-2">
          <PDFAwards :awards="getResume.spokenLanguages"/>
        </div>
        <div class="skills-col col-12 col-lg-10">
          <PDFSkills
            :skills="getResume.skills"
          />
        </div>
      </div>

      <!-- objective rows -->
      <!-- ml-3 to match pic -->
      <div class="resume-section ml-3">
        <PDFObjective :aboutMe="getResume.brief" />
      </div>

      <PDFExperience
        :experiences="getResume.experiences"      
      />
      <PDFEducation
        :educations="getResume.educations"
      />
      <div id="interests-poem-container" class="row">
        <div id="interests-container" class="col-12 col-md-8">
          <PDFInterests
            :interests="getResume.interests"
          />
        </div>
        <div id="poem-container" class="col-12 col-md-4 mt-3 mt-md-0 mr-0 text-center">
          <img class="img-fluid img-profile rounded" :src="pic" alt="poem" :style="{height: '16rem', width: '16rem'}">
        </div>
      </div>

      <!-- for some reason adding this handler makes the function run on load -->
      <!-- <ButtonFloat :target="'save-button-float'" :icon="'save'" :handler="toPDF(target)"/> -->
      <ButtonFloat :target="'save-button-float'" :icon="'save'" :pdf-target="'pdf-anchor'">
      </ButtonFloat>


    </div>
  </div>
</template>

<script>
import PDFAbout from '@/components/Resume/PDF/PDFAbout'
import PDFBorder from '@/components/Resume/PDF/PDFBorder'
import PDFSkills from '@/components/Resume/PDF/PDFSkills'
import PDFAwards from '@/components/Resume/PDF/PDFAwards'
import PDFObjective from '@/components/Resume/PDF/PDFObjective'
import PDFExperience from '@/components/Resume/PDF/PDFExperience'
import PDFEducation from '@/components/Resume/PDF/PDFEducation'
import PDFInterests from '@/components/Resume/PDF/PDFInterests'
import ButtonFloat from '@/components/Utils/ButtonFloat'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'PDF',
  components: {
    PDFAbout ,
    PDFBorder,
    PDFSkills,
    PDFAwards,
    PDFObjective,
    PDFExperience,
    PDFEducation,
    PDFInterests,
    ButtonFloat
  },
  data () {
    return {
      pic: require('@/assets/poem.jpg'),
      target: 'pdf-anchor'
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
    ...mapActions('resume', ['loadResume'])
  },
  mounted () {
    this.loadResume()
  }
}
</script>

<style lang="scss">

// @import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:100,200,300,400,500,600,700,800,900');
// @import url('https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i');
@import './../assets/scss/pdf.scss';

// // A4 page dimensions supposedly
// #pdf-anchor {
//   height: 842px;
//   width: 595px;
// }

</style>
