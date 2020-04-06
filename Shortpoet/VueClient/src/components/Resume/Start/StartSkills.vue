<template>
  <section class="resume-section pl-3 p-lg-5 d-flex flex-column" id="skills">
    <div class="my-auto">
      <h2 class="mb-5">Skills</h2>
      <div class="subheading mb-3">
        Programming Languages &amp; Tools
      </div>
      <ul class="list-inline list-icons">
        <li class="list-inline-item">
          <i class="devicons devicons-html5"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-css3"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-bootstrap"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-sass"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-javascript"></i>
        </li>
        <li class="list-inline-item">
          <img class="vue-devicon" src="@/assets/vue_devicon.svg"/>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-git"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-linux"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-database"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-msql_server"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-dotnet"></i>
        </li>
        <li class="list-inline-item">
          <i class="devicons devicons-visualstudio"></i>
        </li>
      </ul>
      <div class="subheading mb-3">
        Workflow
      </div>
      <ul class="fa-ul mb-3 skill-list">
      <li>
          <i class="fa fa-check"></i>
          Mobile-First, Responsive Design</li>
      <li>
          <i class="fa fa-check"></i>
          Cross Browser Testing &amp; Debugging</li>
      <li>
          <i class="fa fa-check"></i>
          CI/CD</li>
      <li>
          <i class="fa fa-check"></i>
          Agile Development &amp; Scrum</li>
      </ul>
      <div
        v-for="(type, i) in skills"
        :key="i"
        class="skill-grid"
      >
        <div class="subheading mb-3">
          {{ type.type }}
        </div>
        <ul class="fa-ul mb-3 skill-list">
            <li
              v-for="(skill, i) in listSkills(type.details)"
              :key="i"
            >          
              <span class="skill">
                <i class="fa fa-check"></i>
                {{ skill }}
              </span>
            </li>
        </ul>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'StartSkills',
  props: {
    skills: {
      type: Array,
      default: () => []
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

<style lang="scss" scoped>
.vue-devicon {
  /* height: 48px;
  width: 48px;
  line-height: 1;
  padding: 4px;
  margin-bottom: 12px; */
  height: 3rem;
  width: 3rem;
  line-height: 1;
  padding: .25rem;
  margin-bottom: .8rem;
  color: red;
  
}
.vue-devicon:hover {
    color: red;
  }
.skill-grid {
  /* display: flex; */
  /* flex-wrap: wrap; */
}
.skill-list li {
  /* adding inline-block instead of inline allowed the icon and text to stay on same line */
  display: inline-block;
  margin: 0rem .5rem 0rem 0rem;
}

/*
  in case one would want to implement the below
  https://stackoverflow.com/questions/50310201/make-elements-wrap-in-groups-not-one-by-one
 */

.skill {
  /* flex: 0 0 33%; */
  /* display: inline-block; */
}

/* @media ( max-width: 800px) {
  .skill-grid {
    width: 50%;
  }
}

@media ( max-width: 600px) {
  .skill-grid {
    width: 33%;
  }
}

@media ( max-width: 400px) {
  .skill-grid {
    width: 15%;
  }
}

* {
  box-sizing: border-box;
} */
</style>
