<template>
  <div>
    <Header />
    <ItemCarousel />
  </div>
</template>

<script>
import Header from "../components/Header";
import ItemCarousel from "../components/ItemCarousel.vue";

export default {
  name: "ArtistPage",

  components: {
    Header,
    ItemCarousel,
  },
};
</script>
