<template>
  <section class="resume-section mt-2 ml-3" id="experience">
    <div class="my-auto">
      <h4>Work Experience</h4>
      <div class="d-flex flex-column justify-content-between" v-for="type in experiences" :key="type.type">
        <!-- <h4 class="pdf-subheading mt-2 mb-0">{{ type.type }} Experience</h4> -->
        <div v-for="job in type.jobs" :key="job.description">
          <div class="d-flex flex-column justify-content-between">
            <div class="d-flex flex-row">
              <div class="mr-auto">
                <h5 class="mb-0">{{ job.position }}</h5>
              </div>
              <div class="resume-date text-md-right mr-4">
                <h6 class="text-primary">{{ job.startDate }} - {{ job.endDate }}</h6>
              </div>
            </div>
            <div class="d-flex flex-column">
              <h6 class="">{{ job.company }}</h6>
              <p class="mb-2">{{ job.description }}</p>
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
