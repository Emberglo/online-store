import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ItemService {
  async getPublicItems() {
    try {
      const res = await api.get('/api/items')
      logger.log(res.data)
      AppState.items = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const itemService = new ItemService()
