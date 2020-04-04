<template>
  <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
    <div class="my-auto">
      <ul class="list-inline list-social-icons mb-0 mt-0">
        <li
          class="social-item list-inline-item my-3"
          v-for="(social, i) in socials"
          :key="i"
        >
          <a :href="social.url">
            <font-awesome-layers
              class="social-icon-layer fa-lg"
              v-if="!social.social.includes('pdf')"
            >
              <font-awesome-icon size="2x" icon="circle" />
              <font-awesome-icon
                class="social-icon"
                size="2x"
                :transform="social.transform"
                :icon="['fab', social.social]"
              ></font-awesome-icon>
            </font-awesome-layers>
            <font-awesome-layers
              class="social-icon-layer fa-lg"
              v-else
            >
              <font-awesome-icon size="2x" icon="circle" />
              <font-awesome-icon
                class="social-icon"
                size="2x"
                :transform="social.transform"
                :icon="['fa', social.social]"
              ></font-awesome-icon>
            </font-awesome-layers>
          </a>
        </li>
      </ul>
    </div>
  </section>
</template>

<script>
export default {
    name: 'StartSocials',
    components: {
    },
    props: {
    },
    data () {
      return {
        socials: [
          {
            social: 'github',
            url: 'https://github.com/shortpoet',
            transform: 'shrink-5'
          },
          {
            social: 'linkedin',
            url: 'https://www.linkedin.com/in/carlos-soriano-49aaa97/',
            transform: 'shrink-6 right-1'
          },
          {
            social: 'instagram',
            url: 'https://www.instagram.com/shortpoet/',
            transform: 'shrink-5 right-1'
          },
          {
            social: 'twitter',
            url: 'https://twitter.com/shortpoet3',
            transform: 'shrink-6'
          },
          {
            social: 'file-pdf',
            url: window.location.protocol + '//' + window.location.host + '/pdf',
            transform: 'shrink-6 right-2.5'
          }
        ]
      }
    },
    computed: {
    }
}
</script>
