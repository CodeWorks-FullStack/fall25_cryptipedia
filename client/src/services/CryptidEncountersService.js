import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class CryptidEncountersService {
  async getCryptidEncountersByCryptidId(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}/cryptidEncounters`)
    logger.log('GOT CRYPTID ENCOUNTERS 🥸🥸🥸', response.data)
  }
}

export const cryptidEncountersService = new CryptidEncountersService()