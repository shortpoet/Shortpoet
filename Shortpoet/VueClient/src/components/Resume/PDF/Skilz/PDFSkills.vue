<template>
  <section class="resume-section mt-3 ml-3" id="skills">
    <div class="my-auto">
      <div class="d-flex flex-row justify-content-between mx-5 my-3">
      <h4>Skills</h4>
      <h5 class="subheading mb-3">
        Programming Languages &amp; Tools
      </h5>
      <div id="skill-grid-container" class="d-flex flex-row mt-4">
        <div id="skills-container" class="d-flex flex-column mr-5">
            <div
              v-for="(item, i) in iconMap"
              :key="i"
              class="list-devicons d-flex flex-column justify-content-between"
            >
              <div>
                <div class="d-flex flex-column justify-content-between align-items-center">
                  <PDFDevIcon :source="item.icon"/>
                  <!-- <font-awesome-icon id="font-awesome-icon" v-if="!item.icon.includes('devicons')" :icon="['fab', item.icon]"></font-awesome-icon>
                  <i v-else :class="['devicons', item.icon]"></i> -->
                  <!-- <span class="devicon-name">{{ item.name }}</span> -->
                </div>
              </div>
            </div>
          </div>
          <div
            v-for="(type, i) in skills"
            :key="i"
            class="skill-grid"
          >
            <div class="skill-type d-flex flex-row">
              {{ type.type }}
            </div>
            <div class="skill-list-container d-flex flex-column ">
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
      </div>
    </div>
  </section>
</template>

<script>
import PDFDevIcon from '@/components/Resume/PDF/Skilz/PDFDevIcon'
export default {
  name: 'PDFSkills',
  props: {
    skills: {
      type: Array,
      default: () => []
    }
  },
  components: {
    PDFDevIcon
  },
  data () {
    return {
      iconMap: [
        {
          icon: 'devicons-html5',
          name: 'HTML5'
        },
        {
          icon: 'devicons-css3',
          name: 'CSS3'
        },
        {
          icon: 'devicons-bootstrap',
          name: 'Bootstrap'
        },
        {
          icon: 'devicons-sass',
          name: 'SASS'
        },
        {
          icon: 'devicons-javascript',
          name: 'Javascript'
        },
        {
          icon: require('@/assets/vue_devicon_forest_green.svg'),
          name: 'VueJs'
        },
        {
          icon: 'devicons-linux',
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
