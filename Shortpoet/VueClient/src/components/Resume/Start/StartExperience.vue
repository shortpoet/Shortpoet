<template>
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
    <div class="my-auto">
      <h2 class="mb-4 mb-md-3">Experience</h2>
      <div class="resume-item d-flex flex-column mb-2" v-for="type in experiences" :key="type.type">
        <h2 class="mb-3">{{ type.type }}</h2>
        <div class="resume-item d-flex flex-column flex-md-row mb-5" v-for="job in type.jobs" :key="job.description">
          <div class="resume-content mr-auto">
            <h3 class="mb-0">{{ job.position }}</h3>
            <div class="subheading mb-3">{{ job.company }}</div>
            <p v-html="job.description"></p>
          </div>
          <div class="resume-date text-md-right mt-1">
            <span class="text-primary">{{ job.startDate }} - {{ job.endDate }}</span>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
export default {
    name: 'StartExperience',
    props: {
      experiences: {
        type: Array
      }
    }
}
</script>
