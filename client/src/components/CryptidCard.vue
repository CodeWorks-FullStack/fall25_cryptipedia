<script setup>
import { Cryptid } from '@/models/Cryptid.js';

defineProps({
  cryptid: { type: Cryptid, required: true }
})
</script>


<template>
  <RouterLink :to="{ name: 'Cryptid Details', params: { cryptidId: cryptid.id } }"
    :title="`View the details for ${cryptid.name} IF YOU DARE`">
    <div class="position-relative cryptid-info">
      <img :src="cryptid.imgUrl" :alt="`A picture of the ${cryptid.name} cryptid`">
      <div class="position-absolute bottom-0 w-100 p-3 ibm-plex-mono-font">
        <span v-if="cryptid.id < 10">0</span>{{ cryptid.id }}
        <hr>
        {{ cryptid.name }}
      </div>
      <div class="position-absolute top-0 p-3 end-0">
        <span class="mdi mdi-ufo"></span> 0
      </div>
    </div>
  </RouterLink>
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