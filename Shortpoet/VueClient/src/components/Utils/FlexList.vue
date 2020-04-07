<template>
  <span class="flex-list-grid d-flex flex-column">
    <span
      v-for="(row, i) in itemRows"
      :key="i"
      class="flex-list-row d-flex"
    >
      <span
        v-for="(item, i) in row" 
        :key="i"
        class="flex-list-item"
      >
        <slot :item="item"></slot>
      </span>
    </span>
  </span>
</template>

<script>
export default {
  name: 'FlexList',
  props: {
    displayRows: {
      type: Number
    },
    items: {
      type: Array
    }
  },
  computed: {
    itemRows () {
      let itemRows = []
      let items = this.items
      let numRows = items.length
      let divisor = Math.round(numRows / this.displayRows)
      let splits = [...Array(this.displayRows).keys()].map(r => ((r + 1) * divisor))
      console.log(splits)
      splits.forEach((s, i) => {
        if (i === 0) {
          itemRows.push(items.slice(0, splits[i]))
        } else if (i === splits.length - 1) {
          itemRows.push(items.slice(splits[i-1]))
        } else {
          itemRows.push(items.slice(splits[i-1], splits[i]))
        }
      })
      return itemRows
    }
  },
  mounted() {
    console.log(this)
  }
}
</script>