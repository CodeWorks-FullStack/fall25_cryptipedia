<script setup>
import { AppState } from '@/AppState.js';
import { Cryptid } from '@/models/Cryptid.js';
import { cryptidEncountersService } from '@/services/CryptidEncountersService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { useRoute } from 'vue-router';

const props = defineProps({
  cryptid: { type: Cryptid, required: true }
})

const route = useRoute()

async function deleteCryptidEncounter() {
  const confirmed = await Pop.confirm(`Are you sure you did not encounter the ${props.cryptid.name}?`)

  if (!confirmed) return

  try {
    const cryptidEncounter = AppState.encounteredCryptids.find(cryptid => cryptid.id == props.cryptid.id)

    logger.log('the encounter', cryptidEncounter)

    await cryptidEncountersService.deleteCryptidEncounter(cryptidEncounter.cryptidEncounterId)
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT DELETE CRYPTID ENCOUNTER', error)
  }
}
</script>


<template>
  <div class="position-relative cryptid-info">
    <RouterLink :to="{ name: 'Cryptid Details', params: { cryptidId: cryptid.id } }"
      :title="`View the details for ${cryptid.name} IF YOU DARE`">
      <img :src="cryptid.imgUrl" :alt="`A picture of the ${cryptid.name} cryptid`">
    </RouterLink>
    <div class="position-absolute bottom-0 w-100 p-3 ibm-plex-mono-font">
      <span v-if="cryptid.id < 10">0</span>{{ cryptid.id }}
      <hr>
      {{ cryptid.name }}
    </div>
    <div v-if="route.name == 'Home'" class="position-absolute top-0 p-3 end-0">
      <span class="mdi mdi-ufo"></span> {{ cryptid.encounterCount }}
    </div>
    <!-- NOTE since this sits *on top* of the RouterLink, it will not navigate you to a new page when clicked on -->
    <div @click="deleteCryptidEncounter()" v-if="route.name == 'Account'" role="button"
      :title="'Delete encounter with ' + cryptid.name" class="position-absolute top-0 p-3 end-0">
      <span class="mdi mdi-trash-can"></span>
    </div>
  </div>
</template>


<style lang="scss" scoped>
img {
  width: 100%;
  height: 600px;
  object-fit: cover;
  filter: blur(4px);
  transition: filter 1s ease, transform 1s ease;
  transform: scale(1.10);
}

.cryptid-info {
  text-shadow: 0 0 10px black, 1px 2px black;
  font-weight: bold;
  font-size: 1.5rem;
  overflow: hidden;
}

.cryptid-info:hover img {
  filter: blur(0);
  transform: scale(1);
}

a {
  text-decoration: unset;
  color: unset;
}
</style>