<template>
  <div class="pdf-container" v-if="getResumeLoaded"  :style="styleObject">
    <div class="p-10" id="pdf-anchor">
      <portal-target name="save-button-float" />
      <PDFAbout
        :name="getResume.name"
        :surname="getResume.surname"
        :email="getResume.email"
        :address="getResume.address"
        :visas="getResume.visas"
        :flags="getResume.flags"
        :renderPDF="renderPDF"
      />
      <PDFBorder class="my-2" :size=".25"/>
      
      <div class="skills-awards-container">

        <!-- this is regular -->
        <div v-if="!renderPDF" class="row">
          <div class="awards-col col-12 col-lg-2">
            <PDFAwards
              :awards="getResume.spokenLanguages"
              :renderPDF="renderPDF"
            />
          </div>
          <div class="skills-col col-12 col-lg-10">
            <component
              :is="skillComp"
              :skills="getResume.skills"
            />
          </div>
        </div>
        
        <!-- this is RENDER -->
        <div v-else class="skills-awards-container">
          <PDFAwards
            :renderPDF="renderPDF"
            :awards="getResume.spokenLanguages"
          />
          <component
            :is="skillComp"
            :skills="getResume.skills"
          />
        </div>

      </div>

      <!-- objective rows -->
      <!-- ml-3 to match pic -->
      <div class="resume-section ml-3">
        <PDFObjective
          :renderPDF="renderPDF"
          :aboutMe="getResume.brief" 
        />
      </div>

      <PDFExperience
        :renderPDF="renderPDF"
        :experiences="getResume.experiences"      
      />
      <PDFEducation
        :renderPDF="renderPDF"
        :educations="getResume.educations"
      />
      <div id="interests-poem-container" class="row mb-5">
        <div id="interests-container" class="col-12 col-md-8">
          <PDFInterests
            :interests="getResume.interests"
            :renderPDF="renderPDF"
          />
        </div>
        <div id="poem-container" class="col-12 col-md-4 mt-3 mt-md-0 mr-0 text-center">
          <img class="img-fluid img-profile rounded" :src="pic" alt="poem" :style="poemStyle">
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
import PDFSkillsRender from '@/components/Resume/PDF/PDFSkillsRender'
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
    PDFSkillsRender,
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
      target: 'pdf-anchor',
      renderPDF: true
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
    },
    styleObject () {
      return this.renderPDF ?
      {
        fontFamily: 'Saira Extra Condensed, Open Sans',
        height: '842px',
        width: '595px',
        /* to centre page on screen*/
        marginLeft: 'auto',
        marginRight: 'auto'

      }
      :
      {
        fontFamily: 'Saira Extra Condensed, Open Sans',
      }
    },
    poemStyle () {
      return this.renderPDF ?
      {
        height: '10rem',
        width: '10rem',
      }
      :
      {
        height: '16rem',
        width: '16rem',
      }
    },
    skillComp () {
      return this.renderPDF ? 'PDFSkillsRender' : 'PDFSkills'
    },
  },
  methods: {
    ...mapActions('resume', ['loadResume']),
    onToPDF () {
      this.renderPDF = true
    }
  },
  mounted () {
    this.loadResume()
  }
}
</script>

<style lang="scss">

@import url('https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,600,700');
@import url('https://fonts.googleapis.com/css?family=Open+Sans:400,400i');
@import './../assets/scss/pdf.scss';

// page {
//   size: A4 
// }

// // A4 page dimensions supposedly
// #pdf-anchor {
//   height: 842px;
//   width: 595px;
//   /* to centre page on screen*/
//   margin-left: auto;
//   margin-right: auto;
// }

</style>
