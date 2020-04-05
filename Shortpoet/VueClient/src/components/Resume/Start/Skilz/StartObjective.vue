<template>
  <section class="resume-section p-3 p-lg-5 d-flex d-column" id="start-objective">
    <div>
      <p class="mb-5">{{ aboutMe1 }}</p>
      <p class="mb-5">{{ aboutMe2 }}</p>
      <p class="mb-5">Showcasing the evolution of these skills has been a learning process on its own. 
        All of the work I have done since the bootcamp was internal corporate. This resume site is a work-in-progress to highlight some of those skills.  
        It is hosted on <a href="https://shortpoet.azurewebsites.net">Azure</a> with a linked database to dynamically populate the different resume formats.
        Please checkout the <a :href="pdfUrl">PDF-friendly</a> version below.  
        And coming soon, a guestbook that will fully illustrate the capabilites of a linked data source! 🤓</p>
    </div>
  </section>
</template>

<script>
export default {
    name: 'StartObjective',
    components: {
    },
    props: {
      aboutMe: {
        type: String
      }
    },
    data () {
      return {
        pdfUrl: window.location.protocol + '//' + window.location.host + '/pdf',
      }
    },
    computed: {
      aboutMe1 () {
        return this.aboutMe.slice(0, this.aboutMe.indexOf('Driven'))
      },
      aboutMe2 () {
        return this.aboutMe.slice(this.aboutMe.indexOf('Driven'))
      }
    }
}
</script>
