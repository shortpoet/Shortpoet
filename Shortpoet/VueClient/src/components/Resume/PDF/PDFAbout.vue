<template>
  <section class="resume-section" id="about">

    <!-- basic info row -->
    <div class="row align-items-center" id="basic-info">

      <!-- photo column -->
      <div class="col-3 align-items-center" id="photo">
        <img class="img-fluid img-profile rounded mx-auto mb-2" :src="pic" alt="profile pic">
      </div>

      <!-- name contact column -->
      <div class="col-6" id="name-contact">
        <h3 class="mb-0">{{ name }}
          <span class="">{{ surname }}</span>
        </h3>
        <span>
          {{ address }}
        </span>
        <span class="mx-2" style="color:#343a40">
          <a :href="'mailto:' + email">
            {{ email }}
          </a>
        </span>
        <span>Emoji Placeholder</span>
      </div>

      <!-- socials column -->
      <div class="col-3" id="socials">
        <ul class="list-inline list-social-icons mb-0">
          <li
            v-for="(social, i) in socials"
            :key="i"
          >
            <a :href="social.url">
              <span class="fa-stack fa-lg">
                <i class="fa fa-circle fa-stack-2x"></i>
                <i :class="'fa fa-' + social.social + ' fa-stack-1x fa-inverse'"></i>
              </span>
            </a>
          </li>
        </ul>
      </div>

    </div>

    <hr class="my-6" />
    
    <!-- objective row -->
    <div class="row" id="objective">
      <div class="col-12">
        <h6 className="text-xs font-bold uppercase mt-6 mb-2">
          Objective
        </h6>
        <p class="text-sm">{{ aboutMe1 }}</p>
        <p class="text-sm">{{ aboutMe2 }}</p>      
      </div>
    </div>

  </section>
</template>

<script>
export default {
    name: 'PDFAbout',
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

</style>
