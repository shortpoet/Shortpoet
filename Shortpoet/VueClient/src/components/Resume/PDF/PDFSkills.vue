<template>
  <section class="resume-section mt-3 ml-0 ml-md-0" id="skills">
    <div class="my-auto">
      <h4 class="subheading mb-4 mb-md-3 ml-3 ml-md-0">
        Programming Languages &amp; Tools
      </h4>
      <div id="skill-grid-container" class="d-flex flex-column flex-md-row justify-content-between mt-4 mr-0 mr-md-3">
        <div
          v-for="(type, i) in skills"
          :key="i"
          class="skill-grid"
        >
          <div class="list-devicons devicon-row d-flex justify-content-around">
            <PDFDevIcon
              v-for="(icon, i) in mapIcons(type.type)"
              :key="i"
              :source="icon"
            />
          </div>
          <div class="skill-type d-flex flex-row align-items-center justify-content-around my-2 my-md-0">
            <div>
                <div>{{ type.type }}</div>
            </div>
          </div>
          <PDFBorder class="d-none d-md-block my-3 my-md-2" :size=".25"/>
          <div class="skill-list-container d-flex flex-column mb-4 mb-md-2">
              <div
                v-for="(skill, i) in listSkills(type.details)"
                :key="i"
                class="skill-list d-flex flex-column mx-2 mb-2"
              >
                <div class="skill-pill-container d-flex justify-content-around">
                  <!-- adding extra spans to create grid -->
                  <span></span>
                  <span class="skill badge badge-pill">
                    {{ skill }}
                  </span>
                  <span></span>
                </div>          
              </div>
          </div>
          <PDFBorder v-if="i !== (skills.length - 1)" class="d-md-none d-block my-3 my-md-2" :marginX="25" :size=".25"/>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import PDFDevIcon from '@/components/Resume/PDF/PDFDevIcon'
import PDFBorder from '@/components/Resume/PDF/PDFBorder'

export default {
  name: 'PDFSkills',
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
      iconMap: [
        {
          skill: 'Workflow',
          icons: ['visualstudio', 'git', 'cogs']
        },
        {
          skill: 'Dotnet',
          icons: ['dotnet']
        },
        {
          skill: 'Javascript',
          icons: ['js', 'vue']
        },
        {
          skill: 'Python',
          icons: ['python']
        },
        {
          skill: 'Relational Db',
          icons: ['mssql', 'mysql', 'sqlite']
        },
        {
          skill: 'Document Db',
          icons: ['mongo']
        },
        {
          skill: 'Markdown',
          icons: ['html', 'css', 'bootstrap', 'sass']
        },
        {
          skill: 'Data Vizualization',
          icons: ['d3', 'magic']
        },
        {
          skill: 'Miscelaneous',
          icons: ['beer']
        },
        {
          skill: 'Translation',
          icons: ['beer']
        }
      ],
      icons: [
        {
          icon: 'devicons devicons-html5',
          name: 'html',
          displayName: 'HTML5'
        },
        {
          icon: 'devicons devicons-css3',
          name: 'css',
          displayName: 'CSS3'
        },
        {
          icon: 'devicons devicons-bootstrap',
          name: 'bootstrap',
          displayName: 'Bootstrap'
        },
        {
          icon: 'devicons devicons-sass',
          name: 'sass',
          displayName: 'SASS'
        },
        {
          icon: 'devicons devicons-javascript',
          name: 'js',
          displayName: 'Javascript'
        },
        {
          icon: require('@/assets/vue_devicon_forest_green.svg'),
          name: 'vue',
          displayName: 'VueJs'
        },
        {
          icon: require('@/assets/d3_devicon_forest_green.svg'),
          name: 'd3',
          displayName: 'D3'
        },
        // TODO fix this icon
        {
          icon: require('@/assets/tableau_logo.svg'),
          name: 'vue',
          displayName: 'VueJs'
        },
        {
          icon: 'devicons devicons-linux',
          name: 'linux',
          displayName: 'Linux'
        },
        {
          icon: 'devicons devicons-database',
          name: 'database',
          displayName: 'Database'
        },
        {
          icon: 'devicons devicons-msql_server',
          name: 'mssql',
          displayName: 'Micorsoft SQL Server'
        },
        {
          icon: 'devicons devicons-sqlite',
          name: 'sqlite',
          displayName: 'SQLite'
        },
        {
          icon: 'devicons devicons-mysql',
          name: 'mysql',
          displayName: 'mySQL'
        },
        {
          icon: 'devicons devicons-dotnet',
          name: 'dotnet',
          displayName: 'Dotnet'
        },
        {
          icon: 'devicons devicons-mongodb',
          name: 'mongo',
          displayName: 'Mongo'
        },
        {
          icon: 'devicons devicons-visualstudio',
          name: 'visualstudio',
          displayName: 'Visual Studio'
        },
        {
          icon: 'devicons devicons-git',
          name: 'git',
          displayName: 'Git'
        },
        {
          icon: 'devicons devicons-python',
          name: 'python',
          displayName: 'Python'
        },
        {
          icon: 'devicons devicons-python',
          name: 'python',
          displayName: 'Python'
        },
        {
          icon: 'fa fa-cogs',
          name: 'cogs',
          displayName: 'CI/CD'
        },
        {
          icon: 'fa fa-magic',
          name: 'magic',
          displayName: 'Tableau'
        },
        {
          icon: 'fa fa-user-ninja',
          name: 'ninja',
          displayName: 'ninja'
        },
        {
          icon: 'fa fa-beer',
          name: 'beer',
          displayName: 'Miscellaneous'
        }
      ]
    }
  },
  computed: {
  },
  methods: {
    listSkills(skills) {
      return skills.split(',')
    },
    mapIcons(skill) {
      let iconKeys = this.iconMap.filter(im => im.skill === skill)[0]['icons']
      return iconKeys.map(ik => {
        return this.icons.filter(i => i.name === ik)[0]['icon']
      }) 
    }
  },
  mounted () {
  }
}
</script>
<style lang="scss">
.fa-user-ninja:before {
  font-family: 'Font Awesome 5 Free';
  content: "\f504"; 
  }
</style>