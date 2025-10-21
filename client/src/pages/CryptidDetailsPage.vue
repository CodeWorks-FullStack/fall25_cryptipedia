<script setup>
import { AppState } from '@/AppState.js';
import { cryptidEncountersService } from '@/services/CryptidEncountersService.js';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const cryptid = computed(() => AppState.cryptid)
const profiles = computed(() => AppState.cryptidEncounterProfiles)
const account = computed(() => AppState.account)

const route = useRoute()

onMounted(() => {
  getCryptidById()
  getCryptidEncountersByCryptidId()
})

async function getCryptidById() {
  try {
    await cryptidsService.getCryptidById(route.params.cryptidId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET CRYPTID', error)
  }
}

async function getCryptidEncountersByCryptidId() {
  try {
    await cryptidEncountersService.getCryptidEncountersByCryptidId(route.params.cryptidId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET ENCOUNTERS', error)
  }
}

async function createCryptidEncounter() {
  try {
    const cryptidEncounterData = { cryptidId: route.params.cryptidId }
    await cryptidEncountersService.createCryptidEncounter(cryptidEncounterData)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT CREATE CRYPTID ENCOUNTER', error)
  }
}

</script>


<template>
  <div class="container-fluid">
    <div v-if="cryptid" class="row">
      <div class="col-md-8">
        <div class="italiana-font p-3">
          <span class="text-capitalize fs-2 text-warning">
            {{ cryptid.origin }} Cryptid
          </span>
          <h1 class="display-1">{{ cryptid.name.toUpperCase() }}</h1>
          <p class="ibm-plex-mono-font">{{ cryptid.description }}</p>
          <h2>Size</h2>
          <div>
            <span :title="`Size is ${cryptid.size}/10`">
              <span v-for="size in 10" :key="'cryptid-size-' + size" class="mdi fs-2"
                :class="cryptid.size < size ? 'mdi-circle-outline' : 'mdi-circle'"></span>
            </span>
          </div>
          <h2>Threat Level</h2>
          <div class="mb-4">
            <span :title="`Threat Level is ${cryptid.threatLevel}/10`">
              <span v-for="threatLevel in 10" :key="'cryptid-threat-level-' + threatLevel" class="mdi fs-2"
                :class="cryptid.threatLevel < threatLevel ? 'mdi-circle-outline' : 'mdi-circle'"></span>
            </span>
          </div>
          <h2 class="text-warning">
            Encountered By {{ profiles.length }} Human<span v-if="profiles.length != 1">s</span>
          </h2>
          <button @click="createCryptidEncounter()" v-if="account" class="btn btn-warning ibm-plex-mono-font mb-3">
            I've encountered the {{ cryptid.name }}
          </button>
          <div class="d-flex gap-3 flex-wrap">
            <img v-for="profile in profiles" :key="'cryptid-encounter-profile-' + profile.cryptidEncounterId"
              :src="profile.picture" :alt="'A picture of ' + profile.name" class="profile-img"
              :title="`${profile.name} encountered the ${cryptid.name} on ${profile.encounteredAt.toLocaleDateString()}`">
          </div>
        </div>
      </div>
      <div class="col-md-4 px-0">
        <img :src="cryptid.imgUrl" :alt="`A photo of the ${cryptid.name} cryptid`" class="w-100 cryptid-img sticky-top">
      </div>
    </div>
    <div v-else class="row">
      <div class="col-12">
        <h1>Loading...</h1>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.cryptid-img {
  height: calc(100dvh - 76px);
  object-fit: cover;
}

.profile-img {
  height: 70px;
  aspect-ratio: 1/1;
  border-radius: 50%;
  object-fit: cover;
}
</style>