<template>
  <div class="ItemPage container-fluid">
    <div class="row">
      <div class="col-10 offset-1">
        <h1>Hi</h1>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { itemService } from '../services/ItemService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  name: 'ItemPage',
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await itemService.getActiveItem(route.params.itemId)
    })
    return {
      activeItem: computed(() => AppState.activeItem)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
