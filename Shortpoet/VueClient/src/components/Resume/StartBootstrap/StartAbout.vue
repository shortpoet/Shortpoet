<template>
  <section class="resume-section p-3 p-lg-5 d-flex d-column" id="about">
    <div class="my-auto">
      <h1 class="mb-0">{{ name }}
        <span class="text-primary">{{ surname }}</span>
      </h1>
      <div class="subheading mb-5">{{ address }}
        <a href="mailto:name@email.com">{{ email }}</a>
      </div>
      <p class="mb-5">{{ aboutMe1 }}</p>
      <p class="mb-5">{{ aboutMe2 }}</p>
      <ul class="list-inline list-social-icons mb-0">
        <li class="list-inline-item">
          <a href="#">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-facebook fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="#">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-twitter fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="#">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-linkedin fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
        <li class="list-inline-item">
          <a href="#">
            <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <i class="fa fa-github fa-stack-1x fa-inverse"></i>
            </span>
          </a>
        </li>
      </ul>
    </div>
  </section>
</template>

<script>
export default {
    name: 'StartAbout',
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