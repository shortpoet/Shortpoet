<template>
  <section class="resume-section" id="about">
    <div class="col-span-3 flex items-center">
      <RxPhoto 
        :pic="require('@/assets/github_profile_pic.png')"
      />
      <div>
        <h1 className="font-bold text-4xl" style="{ color: purple }">
          {{ name }} {{ surname }}
        </h1>
        <h6 className="font-medium text-sm">Software Engineer</h6>

        <div className="flex flex-col mt-4 text-xs">
          {{ address }}
          <span class="ml-1">&#937;</span> 
          <span class="mx-2" style="color:#343a40">&#8226;</span> 
          <a :href="'mailto:' + email">{{ email }}</a>
        </div>
      </div>
      <ul class="list-inline list-social-icons mb-0">
        <li class="list-inline-item">
          <a href="https://www.instagram.com/shortpoet/">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-instagram fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="https://twitter.com/shortpoet3">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-twitter fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="https://www.linkedin.com/in/carlos-soriano-49aaa97/">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-linkedin fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="https://github.com/shortpoet">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-github fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <PdfAction 
            :target="'resume-anchor'"
          />
        </li>
      </ul>
    </div>
  </section>
</template>

<script>
import PdfAction from '@/components/Utils/PdfAction'
import RxPhoto from '@/components/Resume/ResumeRx/RxPhoto'

export default {
    name: 'RxAbout',
    components: {
      PdfAction,
      RxPhoto
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