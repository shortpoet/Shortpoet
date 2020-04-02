<template>
  <!-- <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
    <div class="my-auto">
      <h2 class="mb-5">Experience</h2>
      <div class="resume-item d-flex flex-column flex-md-row mb-5" v-for="type in experience" :key="type.type">
        <h2 class="mb-0">{{ type.type }}</h2>
        <div class="resume-item d-flex flex-column flex-md-row mb-5" v-for="job in type.jobs" :key="job.description">
          <div class="resume-content mr-auto">
            <h3 class="mb-0">{{ job.position }}</h3>
            <div class="subheading mb-3">{{ job.company }}</div>
            <p>{{ job.description }}</p>
          </div>
          <div class="resume-date text-md-right">
            <span class="text-primary">{{ job.startDate }} - {{ job.endDate }}</span>
          </div>
        </div>
      </div>
    </div>
  </section> -->
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="experience">
    <div class="my-auto">
      <h2 class="mb-5">Experience</h2>
      <div class="bg-purple text-white sm:bg-green md:bg-blue md:text-yellow lg:bg-red xl:bg-orange ...">
  Test
</div>
      <div class="resume-item d-flex flex-column mb-5" v-for="type in experiences" :key="type.type">
        <h2 class="mb-3">{{ type.type }}</h2>
        <div class="resume-item d-flex flex-column flex-md-row mb-5" v-for="job in type.jobs" :key="job.description">
          <div class="resume-content mr-auto">
            <h3 class="mb-0">{{ job.position }}</h3>
            <div class="subheading mb-3">{{ job.company }}</div>
            <p>{{ job.description }}</p>
          </div>
          <div class="resume-date text-md-right">
            <span class="text-primary">{{ job.startDate }} - {{ job.endDate }}</span>
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
