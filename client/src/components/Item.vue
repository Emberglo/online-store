<template>
  <div class="ItemComponent col-3 rounded m-4">
    <img :src="itemProp.picture" alt="Item Image" class="p-0 m-0" @click="getActiveItem(item.id)">
  </div>
  <!--
  <h3>{{ item.name }}</h3>
  <p>Item Description</p>
  <div class="d-flex justify-content-between w-100">
    <button class="btn btn-sm btn-primary">Add To Wishlist</button>
    <h5 class="pl-2">Item Price</h5>
  </div>
  -->
</template>

<script>
import { computed } from 'vue'
// import { itemService } from '../services/ItemService'
import { useRouter } from 'vue-router'
export default {
  name: 'ItemComponent',
  props: {
    itemProp: Object
  },
  setup(props) {
    const router = useRouter()
    return {
      item: computed(() => props.itemProp),
      getActiveItem(itemId) {
        router.push({ name: 'ItemPage', params: { itemId: itemId } })
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img {
  max-width: 100%;
  height: auto;
}

</style>
