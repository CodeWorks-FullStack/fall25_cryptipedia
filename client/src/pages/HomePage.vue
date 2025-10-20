<script setup>
import { AppState } from '@/AppState.js';
import CryptidCard from '@/components/CryptidCard.vue';
import { cryptidsService } from '@/services/CryptidsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const cryptids = computed(() => AppState.cryptids)

onMounted(getCryptids)

async function getCryptids() {
  try {
    await cryptidsService.getCryptids()
  } catch (error) {
    Pop.error(error)
    logger.error('COULD NOT GET CRYPTIDS', error)
  }
}

</script>

<template>
  <section class="container-fluid spooky-woods-bg">
    <div class="row">
      <div class="col-md-8">
        <div class="mx-5 mt-5">
          <h2>Terrestrials</h2>
          <p>
            A terrestrial cryptid is a creature that exists on land but has not been “scientifically” proven. These
            creatures often stem from folklore, mythology, or anecdotal evidence. Unlike aquatic cryptids, like the Loch
            Ness Monster, terrestrial cryptids inhabit forests, mountains, or other land-based environments.
          </p>
          <p>
            Examples of Terrestrials:
            <br>
            Bigfoot, El Chupacabra and Mothman
          </p>
        </div>
      </div>
      <div class="col-md-4 pe-0 text-end align-self-end mt-5">
        <img src="@/assets/img/little_freak.png" alt="A very mysterious little freak"
          class="img-fluid terrestrial-cryptid">
      </div>
    </div>
  </section>
  <section class="container">
    <div class="row">
      <div class="col-12 my-5">
        <h1 class="italiana-font display-1">CRYPTIDS</h1>
      </div>
    </div>
    <div class="row">
      <div v-for="cryptid in cryptids" :key="'cryptid-card-' + cryptid.id" class="col-md-3 px-0 mb-5">
        <CryptidCard :cryptid="cryptid" />
      </div>
    </div>
  </section>
</template>

<style scoped lang="scss">
.terrestrial-cryptid {
  transform: scaleX(-1);
  filter: hue-rotate(185deg);
  opacity: .8;
}

.spooky-woods-bg {
  background-image: url(@/assets/img/spooky_woods.jpg);
  background-size: cover;
  background-position: center;

  .row {
    backdrop-filter: sepia(.6);
    background-color: rgba(43, 43, 43, 0.429);
  }

  .col-md-8 {
    text-shadow: 0 1px black;
    font-weight: bold;
  }
}
</style>
