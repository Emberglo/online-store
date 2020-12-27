<template>
  <div class="home container-fluid align-items-center justify-content-center h-100">
    <div class="row justify-content-around">
      <ItemComponent v-for="item in items" :item-prop="item" :key="item.id" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { itemService } from '../services/ItemService'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    onMounted(async() => {
      await itemService.getPublicItems()
    })
    return {
      profile: computed(() => AppState.profile),
      items: computed(() => AppState.items)
    }
  },
  components: {}
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
