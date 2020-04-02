<template>
  <section class="resume-section ml-3 p-1 p-lg-2" id="experience">
    <div class="my-auto">
      <div class="resume-item d-flex flex-column" v-for="type in experiences" :key="type.type">
        <h4 class="">{{ type.type }} Experience</h4>
        <div v-for="job in type.jobs" :key="job.description">
          <div class="resume-item d-flex flex-column justify-content-between">
            <div class="d-flex flex-row">
              <div class="resume-content mr-auto">
                <h6 class="mb-0">{{ job.position }}</h6>
              </div>
              <div class="resume-date text-md-right">
                <span class="text-primary">{{ job.startDate }} - {{ job.endDate }}</span>
              </div>
            </div>
            <div class="d-flex flex-column">
              <div class="subheading mb-1">{{ job.company }}</div>
              <p>{{ job.description }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
export default {
    name: 'PDFExperience',
    props: {
      experiences: {
        type: Array
      }
    }
}
</script>
