<template>
  <div class="pdf-action">
    <!-- <font-awesome-layers
      class="social-icon-layer fa-lg"
    >
      <font-awesome-icon size="2x" icon="circle" />
      <font-awesome-icon
        class="social-icon"
        size="2x"
        :transform="social.transform"
        :icon="['fa', social.social]"
      ></font-awesome-icon>
    </font-awesome-layers> -->
    <span class="badge badge-seconda" @click="toPDF">PDF</span>
  </div>
</template>

<script>
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
  }
}
</script>

<style>


</style>