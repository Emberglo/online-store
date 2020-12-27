<template>
  <div class="ItemComponent col-3 rounded m-4">
    <img src="{{ item.picture }}" alt="" class="p-0 m-0" onclick="getActiveItem">
  </div>
    <!-- <h3>Item Name</h3>
    <p>Item Description</p>
    <div class="d-flex justify-content-between w-100">
      <button class="btn btn-sm btn-primary">Add To Wishlist</button>
      <h5 class="pl-2">Item Price</h5>
    </div> -->
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ItemComponent',
  setup(props) {
    return {
      item: computed(() => props.itemProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
