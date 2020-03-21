<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-top" id="sideNav">
    <a class="navbar-brand js-scroll-trigger" href="#about">
      <span class="d-block d-lg-none">Carlos Soriano - Resume</span>
      <span id="pic" class="d-none d-lg-block" @mouseenter="cyclePics" @mouseleave="revertPic">
        <img class="img-fluid img-profile rounded-circle mx-auto mb-2" :src="pic" alt="profile pic">
        <!-- <img class="img-fluid img-profile rounded-circle mx-auto mb-2" src="@/assets/profile_pic.jpg" alt=""> -->
      </span>
    </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#about">About</a>
        </li>
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#experience">Experience</a>
        </li>
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#education">Education</a>
        </li>
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#skills">Skills</a>
        </li>
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#awards">Spoken Languages</a>
        </li>
        <li class="nav-item">
          <a class="nav-link js-scroll-trigger" href="#interests">Interests</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  name: 'StartNav',
  data () {
    return {
      pic: require('@/assets/profile_pic.jpg')
    }
  },
  methods: {
    revertPic () {
      // this.pic = require('@/assets/profile_pic.jpg')
      // clearInterval()
    },
    cyclePics () {
      // let i = 0
      // let pics = [require('@/assets/profile_pic1.jpg'), require('@/assets/profile_pic2.jpg')]
      // let counter = 0
      // let cycle = () => {
      //   if (i == 0) {
      //     this.pic = pics[1]
      //     i = 1
      //   } else {
      //     this.pic = pics[0]
      //     i = 0
      //   }
      //   if (++counter > 5) {
      //     clearInterval(cycle)
      //   }
      // }
      // setInterval(cycle, 1500)
    }
  }
}
</script>

<style scoped>
/* 
  http://css3.bradshawenterprises.com/cfimg/
  For "n" images You must define:
  a=presentation time for one image
  b=duration for cross fading
  Total animation-duration is of course t=(a+b)*n

  animation-delay = t/n or = a+b

  Percentage for keyframes:

  1.  0%
  2.  a/t*100%
  3.  (a+b)/t*100% = 1/n*100%
  4.  100%-(b/t*100%)
  5.  100%

 */

#pic {
  /* position:relative; */
  /* height:281px;
  width:450px; */
  /* margin:0 auto; */
}

#pic img {
  /* position:absolute; */
  /* left:0;
  -webkit-transition: opacity 1s ease-in-out;
  -moz-transition: opacity 1s ease-in-out;
  -o-transition: opacity 1s ease-in-out;
  transition: opacity 1s ease-in-out; */
}

#pic img.top:hover {
  opacity:0;
}

@keyframes cf4FadeInOut {
  0% {
    opacity:1;
  }
  17% {
    opacity:1;
  }
  25% {
    opacity:0;
  }
  92% {
    opacity:0;
  }
  100% {
    opacity:1;
  }
}

#cf4a img:nth-of-type(1) {
  animation-delay: 6s;
}
#cf4a img:nth-of-type(2) {
  animation-delay: 4s;
}
#cf4a img:nth-of-type(3) {
  animation-delay: 2s;
}
#cf4a img:nth-of-type(4) {
  animation-delay: 0;
}

</style>