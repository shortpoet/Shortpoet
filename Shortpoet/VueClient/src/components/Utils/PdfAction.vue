<template>
  <div class="pdf-action">
    <!-- <button class="bg-gray-600 hover:bg-gray-700 text-white text-sm font-medium py-2 px-5 rounded" @click="toPDF">PDF</button> -->
    <span class="badge badge-secondary badge-pill" @click="toPDF">PDF</span>
  </div>
</template>

<script>
// import { mapGetters, mapActions } from 'vuex'
import jsPDF from 'jspdf'
import html2canvas from 'html2canvas'
export default {
  name: 'PdfAction',
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