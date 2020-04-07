<template>
  <section class="mb-3" id="pdf-objective">
    <div class="d-flex align-items-center" id="objective">
      <h4 class="">
        Objective
      </h4>
    </div>

    <div class="d-flex align-items-center" id="objective">
      <div class="resume-item d-flex flex-column justify-content-between">
        <div
          v-for="(text, i) in aboutMe.split('\\n\\r')"
          :key="i"
          class="aboutme-paragraph mb-2 mb-md-1"
        >
        <!-- if text contains markup -->
        <p v-if="!text.match(/\<.+\/\>|\<\/.+\>/g)">
          {{ text }}
        </p>
        <p v-else v-html="text"></p>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
    name: 'PDFObjective',
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
