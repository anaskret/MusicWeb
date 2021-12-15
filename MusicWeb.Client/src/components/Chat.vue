<template>
  <div class="background">
    <v-btn fab class="chat-btn">
      <font-awesome-icon
        class="icon pa-1"
        icon="comment"
        size="2x"
        outlined
      ></font-awesome-icon>
    </v-btn>
  </div>
</template>
<script>
export default {
  name: "Chat",
  setup() {},
};
</script>
<style scoped>
.background {
  display: flex;
  position: sticky;
  bottom: 1rem;
  z-index: 1;
  justify-content: flex-end;
  align-items: flex-start;
}
.chat-btn {
  margin-right: 1rem;
}
</style>
