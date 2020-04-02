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
            <span class="mx-0" style="color:#343a40">
              <a :href="'mailto:' + email">
                {{ email }}
              </a>
            </span>
          </li>
          <li>
            <span>
              {{ address }}
            </span>
          </li>
          <li>
          <span>Emoji Placeholder</span>
          </li>
        </ul>
      </div>

      <!-- socials column -->
      <div class="d-flex flex-column ml-auto mr-5" id="socials">
        <ul class="list-inline list-social-icons mb-0">
          <li
            class="social-item"
            v-for="(social, i) in socials"
            :key="i"
          >
            <a :href="social.url">
              <span class="fa-stack fa-lg mr-1">
                <i class="fa fa-circle fa-stack-2x"></i>
                <i :class="'fa fa-' + social.social + ' fa-stack-1x fa-inverse'"></i>
              </span>
              <span>{{social.url}}</span>
            </a>
          </li>
        </ul>
      </div>

    </div>

    <PDFBorder class="my-3" :size=".5"/>

    <!-- objective rows -->

    <div class="d-flex d-row resume-section p-3 p-lg-5 d-flex align-items-center" id="objective">
      <h4 className="text-xs font-bold uppercase mt-6 mb-2">
        Objective
      </h4>
    </div>

    <div class="d-flex d-row resume-section p-3 p-lg-5 d-flex align-items-center" id="objective">
      <div class="col-12 resume-item d-flex flex-column flex-md-row justify-content-between mb-5">
        <p class="text-sm">{{ aboutMe1 }}</p>
        <p class="text-sm">{{ aboutMe2 }}</p>      
      </div>
    </div>

  </section>
</template>

<script>
import PDFBorder from '@/components/Resume/PDF/PDFBorder'
export default {
    name: 'PDFAbout',
    components: {
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
      }
    },
    data () {
      return {
        pic: require('@/assets/github_profile_pic.png'),
        socials: [
          {
            social: 'github',
            url: 'https://github.com/shortpoet',
          },
          {
            social: 'linkedin',
            url: 'https://www.linkedin.com/in/carlos-soriano-49aaa97/',
          },
          {
            social: 'instagram',
            url: 'https://www.instagram.com/shortpoet/',
          },
          {
            social: 'twitter',
            url: 'https://twitter.com/shortpoet3',
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
