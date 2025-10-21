import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { CryptidEncounterProfile } from "@/models/CryptidEncounterProfile.js"
import { EncounteredCryptid } from "@/models/EncounteredCryptid.js"

class CryptidEncountersService {
  async getMyEncounteredCryptids() {
    const response = await api.get('account/cryptidEncounters')
    logger.log('GOT MY ENCOUNTERED CRYPTIDS', response.data)
    AppState.encounteredCryptids = response.data.map(pojo => new EncounteredCryptid(pojo))
  }
  async createCryptidEncounter(cryptidEncounterData) {
    const response = await api.post('api/cryptidEncounters', cryptidEncounterData)
    logger.log('CREATED CRYPTID ENCOUNTER 🥸+🦟', response.data)
    AppState.cryptidEncounterProfiles.push(new CryptidEncounterProfile(response.data))
  }
  async getCryptidEncountersByCryptidId(cryptidId) {
    const response = await api.get(`api/cryptids/${cryptidId}/cryptidEncounters`)
    logger.log('GOT CRYPTID ENCOUNTERS 🥸🥸🥸', response.data)
    AppState.cryptidEncounterProfiles = response.data.map(pojo => new CryptidEncounterProfile(pojo))
  }
}

export const cryptidEncountersService = new CryptidEncountersService()