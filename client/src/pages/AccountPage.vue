<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Pop } from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { cryptidEncountersService } from '@/services/CryptidEncountersService.js';
import CryptidCard from '@/components/CryptidCard.vue';

const account = computed(() => AppState.account)
const cryptids = computed(() => AppState.encounteredCryptids)

onMounted(getMyEncounteredCryptids)

async function getMyEncounteredCryptids() {
  try {
    await cryptidEncountersService.getMyEncounteredCryptids()
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET MY ENCOUNTERED CRYPTIDS', error)
  }
}

</script>

<template>
  <div v-if="account" class="container">
    <div class="row">
      <div class="col-12">
        <h1 class="display-1 italiana-font">{{ cryptids.length }} CRYPTIDS ENCOUNTERED</h1>
      </div>
    </div>
    <div class="row">
      <div v-for="cryptid in cryptids" :key="'encountered-cryptid-' + cryptid.cryptidEncounterId"
        class="col-md-3 px-0 mb-4">
        <CryptidCard :cryptid="cryptid" />
      </div>
    </div>
  </div>
  <div v-else>
    <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
  </div>
</template>

<style scoped lang="scss"></style>
