<template>
  <section class="resume-section" id="about">

    <!-- basic info row -->
    <div class="d-flex flex-row justify-content-between align-items-center mt-0 ml-3" id="basic-info">

      <!-- photo column -->
      <div class="d-flex flex-column align-items-center" id="photo">
        <img class="img-fluid img-profile rounded m-1 mb-2" :src="pic" alt="profile pic" :style="{height: '8rem', width: '7rem'}">
      </div>

      <!-- name contact column -->
      <div class="d-flex flex-column mt-1 ml-3" id="name-contact">
        <ul class="list-inline">
          <li>
            <h2 class="mb-0">{{ name }}
              <span class="text-primary">{{ surname }}</span>
            </h2>
          </li>
          <li>
            <span class="not-name">
              <a :href="'mailto:' + email">
                {{ email }}
              </a>
            </span>
          </li>
          <li>
            <span class="not-name">
              {{ address }}
            </span>
          </li>
          <li>
            <span class="not-name">{{ flags.replace(/,/g, '') }}</span>
          </li>
          <li>
            <span class="not-name">Valid Work Visas: {{ visas }}</span>
          </li>
        </ul>
      </div>

      <!-- socials column -->
      <div class="d-flex flex-column ml-auto mr-5" id="socials">
        <ul class="list-inline list-social-icons mb-0 mt-3">
          <li
            class="social-item"
            v-for="(social, i) in socials"
            :key="i"
          >
            <a :href="social.url">

              <font-awesome-layers
                class="social-icon-layer fa-lg"
                v-if="!social.social.includes('globe')"
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

              <span>{{social.url}}</span>
            </a>
          </li>
          <PDFAction 
            :target="'pdf-anchor'"
          />
        </ul>
      </div>

    </div>

    <PDFBorder class="my-2" :size=".25"/>

    <!-- objective rows -->
    <!-- ml-3 to match pic -->
    <div class="resume-section ml-3">
      <div class="d-flex align-items-center" id="objective">
        <h4 class="">
          Objective
        </h4>
      </div>

      <div class="d-flex align-items-center" id="objective">
        <div class="resume-item d-flex flex-column justify-content-between">
          <p class="mb-1">{{ aboutMe1 }}</p>
          <p>{{ aboutMe2 }}</p>
        </div>
      </div>
    </div>

  </section>
</template>

<script>
import PDFBorder from '@/components/Resume/PDF/PDFBorder'
import PDFAction from '@/components/Utils/PDFAction'

export default {
    name: 'PDFAbout',
    components: {
      PDFAction,
      PDFBorder
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
        pic: require('@/assets/github_profile_pic.png'),
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
            social: 'globe',
            url: 'https://shortpoet.com',
            transform: 'shrink-6 right-.25'
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
<style>
.social-item {
  font-size: .55rem;
}
</style>
