<template>
  <section class="resume-section mt-3 ml-3" id="skills">
    <div class="my-auto">
      <h4  style="font-family: 'Saira Extra Condensed';" class="subheading mb-3 ml-0">
        Programming Languages &amp; Tools
      </h4>
      <div id="skill-grid-container" class="d-flex flex-column justify-content-between mt-4 mr-3">
        <div class="skill-grid-row-1 d-flex flex-row justify-content-between">
          <div
            v-for="(type, i) in skills"
            :key="i"
            class="skill-grid-render"
          >
            <div class="list-devicons devicon-row d-flex justify-content-around">
              <PDFDevIcon
                v-for="(icon, i) in mapIcons(type.type)"
                :key="i"
                :source="icon.icon"
                :name="icon.name"
              />
            </div>
            <div class="skill-type-render d-flex flex-row align-items-center justify-content-around my-0">
              <div>
                  <div class="" style="font-family: 'Open Sans';">{{ typeFilter(type.type) }}</div>
              </div>
            </div>
            <PDFBorder class="d-block my-2" :size=".25"/>
            <div class="skill-list-container d-flex flex-column mb-2">
                <div
                  v-for="(skill, i) in listSkills(type.details)"
                  :key="i"
                  class="skill-list d-flex flex-column mx-2 mb-2"
                >
                  <div class="skill-pill-container d-flex justify-content-around">
                    <!-- adding extra spans to create grid -->
                    <span></span>
                    <span style="font-family: 'Open Sans';" class="skill-render">
                      {{ skill }}
                    </span>
                    <span></span>
                  </div>          
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import PDFDevIcon from '@/components/Resume/PDF/PDFDevIcon'
import PDFBorder from '@/components/Resume/PDF/PDFBorder'
import icons from '@/assets/icons.js'

export default {
  name: 'PDFSkillsRender',
  props: {
    skills: {
      type: Array,
      default: () => []
    }
  },
  components: {
    PDFDevIcon,
    PDFBorder
  },
  data () {
    return {
      icons: icons.icons,
      iconMap: icons.iconMap,
      windowWidth: window.innerWidth 
    }
  },
  computed: {
    mediumScreen () {
      // let skillGridWidth = document.getElementById('skill-grid-container').scrollWidth
      let windowWidth = window.innerWidth
      // for medium screens
      return 768 < windowWidth && windowWidth > 985
    }
  },
  methods: {
    listSkills(skills) {
      return skills.split(',')
    },
    mapIcons(skill) {
      let iconKeys = this.iconMap.filter(im => im.skill === skill)[0]['icons']
      return iconKeys.map(ik => {
        return this.icons.filter(i => i.name === ik)[0]
      }) 
    },
    _screenCheck () {
      let skillGridWidth = document.getElementById('skill-grid-container').scrollWidth
      let windowWidth = this.windowWidth
      console.log('checking screen')
      console.log(skillGridWidth)
      console.log(windowWidth)
      // for medium-large screens
      if(768 < windowWidth && windowWidth > 985) {
        console.log('the grid should be medium-large')
      }
    },
    typeFilter (type) {
      if (type === 'Document Db') {
        type = 'Doc Db'
      } else if (type === 'Data Vizualization') {
        type = 'Data Viz'
      }
      return type
    }
  },
  mounted () {
    this._screenCheck()
  }
}
</script>
<style lang="scss">
.fa-user-ninja:before {
  font-family: 'Font Awesome 5 Free';
  content: "\f504"; 
  }
</style>