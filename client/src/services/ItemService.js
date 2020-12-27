import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ItemService {
  async getPublicItems() {
    try {
      const res = await api.get('/api/items')
      AppState.items = res.data
    } catch (err) {
      logger.error(err)
    }
  }

  async getActiveItem(itemId) {
    try {
      const res = await api.get('/api/items/' + itemId)
      logger.log('activeItemFunction', res.data)
      AppState.activeItem = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const itemService = new ItemService()
