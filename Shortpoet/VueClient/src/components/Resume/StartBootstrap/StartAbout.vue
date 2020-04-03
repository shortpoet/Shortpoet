<template>
  <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
    <div class="my-auto">
      <h1 class="mb-0">{{ name }}
        <span class="text-primary">{{ surname }}</span>
      </h1>
      <!-- https://lonewolfonline.net/html-character-codes-ascii-entity-unicode-symbols/ -->
      <div class="subheading mb-5">{{ address }}
        <span class="ml-1">&#937;</span> 
        <span class="mx-2" style="color:#343a40">&#8226;</span> 
        <a :href="'mailto:' + email">{{ email }}</a>
        <span class="mx-2" style="color:#343a40">&#8226;</span> 
        <span class="not-name">{{ flags.replace(/,/g, '') }}</span>
        <span class="mx-2" style="color:#343a40">&#8226;</span> 
        <span class="not-name">Valid Work Visas: {{ visas }}</span>
      </div>
      <p class="mb-5">{{ aboutMe1 }}</p>
      <p class="mb-5">{{ aboutMe2 }}</p>
      <ul class="list-inline list-social-icons mb-0 mt-0">
        <li
          class="social-item list-inline-item"
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
    name: 'StartAbout',
    components: {
    },
    props: {
      name: {
        type: String
      },
      surname: {
        type: String
      },
      email: {
        type: String
      },
      aboutMe: {
        type: String
      },
      address: {
        type: String
      },
      visas: {
        type: String
      },
      flags: {
        type: String
      }
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
      aboutMe1 () {
        return this.aboutMe.slice(0, this.aboutMe.indexOf('The call'))
      },
      aboutMe2 () {
        return this.aboutMe.slice(this.aboutMe.indexOf('The call'))
      }
    }
}
</script>

<style scoped>

</style>