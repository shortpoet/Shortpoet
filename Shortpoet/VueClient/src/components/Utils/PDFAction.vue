<template>
  <div type="input" class="pdf-action" data-toggle="tooltip" data-placement="bottom" data-html="true" 
    title=""
    data-original-title="<b>Save</b> PDF. This does <u>not</u> download a file from any where. It is generated fresh by your browser based on a <em>snapshot</em> of this page as you see it."
  >
    <font-awesome-layers
      class="save-icon-layer fa-lg"
      @click="toPDF"
    >
      <font-awesome-icon class="save-icon-circle" size="2x" icon="circle" />
        <font-awesome-icon
          class="save-icon"
          size="2x"
          :transform="'shrink-5 right-1'"
          :icon="['fa', 'save']"
        ></font-awesome-icon>
    </font-awesome-layers>
    <span class="save-text ml-3"> PDF</span>
  </div>
</template>

<script>

// const svgFunc = () => {
//   const ratio = window.devicePixelRatio || 1;
//   [...document.querySelectorAll("svg.svg-inline--fa")].map(svgElement => {
//     // create a new canvas
//     const canvas = document.createElement("canvas");

//     // multiply the dimensions by the ratio (important for retina displays)
//     canvas.width = svgElement.getBoundingClientRect().width * ratio;
//     canvas.height = svgElement.getBoundingClientRect().height * ratio;

//     // force the canvas css to have the same width and height as the original svg icon
//     canvas.style.width = svgElement.getBoundingClientRect().width + "px";
//     canvas.style.height = svgElement.getBoundingClientRect().height + "px";

//     // hide the original svg icon and append the newly created canvas
//     svgElement.style.display = "none";
//     svgElement.parentNode.appendChild(canvas);

//     // draw the original svg icon onto the new canvas
//     var ctx = canvas.getContext("2d");
//     var DOMURL = self.URL || self.webkitURL || self;
//     var svgString = new XMLSerializer().serializeToString(svgElement);
//     var img = new Image();
//     var svg = new Blob([svgString], { type: "image/svg+xml;charset=utf-8" });
//     img.src = DOMURL.createObjectURL(svg);
//     img.onload = function() {
//       ctx.drawImage(img, 0, 0);
//     };
//   });
// }

// import { mapGetters, mapActions } from 'vuex'
import jsPDF from 'jspdf'
import html2canvas from 'html2canvas'
export default {
  name: 'PDFAction',
  components: {
  },
  props: {
    target: {
      type: String
    }
  },
  data () {
    return {
    }
  },
  computed: {
  },
  methods: {
    toPDF () {
      // timeout is set to account for loading time i believe
      setTimeout(() => {
        console.log(this.target)
        // svgFunc()
        html2canvas(document.getElementById(this.target), {
          scale: 3,
          useCORS: true,
          allowTaint: true,
        }).then(canvas => {
          const image = canvas.toDataURL('image/jpeg', 1.0);
          const doc = new jsPDF('p', 'mm', 'a4');
          const pageWidth = doc.internal.pageSize.getWidth();
          const pageHeight = doc.internal.pageSize.getHeight();

          const widthRatio = pageWidth / canvas.width;
          const heightRatio = pageHeight / canvas.height;
          const ratio = widthRatio > heightRatio ? heightRatio : widthRatio;

          const canvasWidth = canvas.width * ratio;
          const canvasHeight = canvas.height * ratio;

          const marginX = (pageWidth - canvasWidth) / 2;
          const marginY = (pageHeight - canvasHeight) / 2;

          doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');
          doc.save(`Carlos_Soriano_${Date.now()}.pdf`);
        });
      }, 250);
    }
  },
  mounted () {
    const $ = this.jquery
    $(function () {
      $('[data-toggle="tooltip"]').tooltip()
    })
  }
}
</script>

<style>


</style>