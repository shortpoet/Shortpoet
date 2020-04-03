<template>
  <section class="resume-section mt-3 ml-3" id="skills">
    <div class="my-auto">
      <div class="d-flex flex-row justify-content-between mx-5 my-3">
        <div
          v-for="(item, i) in iconMap"
          :key="i"
          class="list-devicons d-flex flex-row justify-content-between"        
        >
          <div>
            <div class="d-flex flex-column justify-content-between align-items-center">
              <font-awesome-icon v-if="!item.icon.includes('devicons')" :icon="['fab', item.icon]"></font-awesome-icon>
              <i v-else :class="['devicons', item.icon]"></i>
              <span class="devicon-name">{{ item.name }}</span>
            </div>
          </div>
        </div>
      </div>
      <div id="skill-grid-container" class="d-flex flex-row mt-4">
        <div id="skills-container" class="d-flex flex-column mr-5">
          <h4>Skills</h4>
          <h5 class="subheading mb-3">
            Programming Languages &amp; Tools
          </h5>
          <div
            v-for="(type, i) in skills"
            :key="i"
            class="skill-grid"
          >
            <div class="skill-type d-flex flex-row">
              {{ type.type }}
            </div>
            <div class="skill-list-container d-flex flex-row ">
                <div
                  v-for="(skill, i) in listSkills(type.details)"
                  :key="i"
                  class="skill-list d-flex flex-column mx-2 mb-2"
                >          
                  <span class="skill badge badge-pill">
                    <!-- <i class="skill-icon fa fa-check"></i> -->
                    {{ skill }}
                  </span>
                </div>
            </div>
          </div>
        </div>
        <div id="interests-container" class="d-flex flex-column ml-5">
          <div id="poem-awards-row" class="d-flex flex-row">
            <div id="poem-container" class="mt-5 mr-1">
              <img class="img-fluid img-profile rounded" :src="pic" alt="poem" :style="{height: '16rem', width: '16rem'}">
            </div>
            <div id="awards-container" class="mt-5 ml-5">
              <PDFAwards :awards="awards"/>
            </div>
          </div>
          <div id="interests-row" class="mt-4 mr-5">
            <PDFInterests
              :interests="interests"
            />
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import PDFAwards from '@/components/Resume/PDF/PDFAwards'
import PDFInterests from '@/components/Resume/PDF/PDFInterests'

export default {
  name: 'PDFSkills',
  props: {
    skills: {
      type: Array,
      default: () => []
    },
    awards: {
      type: Array,
      default: () => []
    },
    interests: {
      type: String
    }
  },
  components: {
    PDFAwards,
    PDFInterests
  },
  data () {
    return {
      pic: require('@/assets/poem.jpg'),
      iconMap: [
        {
          icon: 'html5',
          name: 'HTML5'
        },
        {
          icon: 'css3',
          name: 'CSS3'
        },
        {
          icon: 'bootstrap',
          name: 'Bootstrap'
        },
        {
          icon: 'sass',
          name: 'SASS'
        },
        {
          icon: 'js',
          name: 'Javascript'
        },
        {
          icon: 'vuejs',
          name: 'VueJs'
        },
        {
          icon: 'linux',
          name: 'Linux'
        },
        {
          icon: 'devicons-database',
          name: 'database'
        },
        {
          icon: 'devicons-msql_server',
          name: 'msql_server'
        },
        {
          icon: 'devicons-dotnet',
          name: 'dotnet'
        },
        {
          icon: 'devicons-visualstudio',
          name: 'visualstudio'
        }
      ]
    }
  },
  methods: {
    listSkills(skills) {
      return skills.split(',')
    }
  },
  mounted () {
  }
}
</script>
