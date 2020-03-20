<template>
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="skills">
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
      <ul class="fa-ul mb-0">
      <li>
          <i class="fa-li fa fa-check"></i>
          Mobile-First, Responsive Design</li>
      <li>
          <i class="fa-li fa fa-check"></i>
          Cross Browser Testing &amp; Debugging</li>
      <li>
          <i class="fa-li fa fa-check"></i>
          Cross Functional Teams</li>
      <li>
          <i class="fa-li fa fa-check"></i>
          Agile Development &amp; Scrum</li>
      </ul>
      <div class="subheading mb-3">Other</div>
      <ul class="fa-ul mb-0">
        <li>
            <i class="fa-li fa fa-check"></i>
            Mobile-First, Responsive Design
        </li>
      </ul>
    </div>
  </section>
</template>

<script>
export default {
    name: 'StartSkills',
}
</script>

<style scoped>
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
}
</style>