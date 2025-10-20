import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Cryptid } from "@/models/Cryptid.js"

class CryptidsService {
  async getCryptidById(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}`)
    logger.log('GOT CRYPTID 🦟', response.data)
    AppState.cryptid = new Cryptid(response.data)
  }
  async getCryptids() {
    const response = await api.get('api/cryptids')
    logger.log('GOT CRYPTIDS 💀🦇🦟🕷️', response.data)
    AppState.cryptids = response.data.map(pojo => new Cryptid(pojo))
  }
}

export const cryptidsService = new CryptidsService()