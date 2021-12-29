<template>
  <div class="button-container">
    <v-btn fab class="chat-btn" @click="openChat">
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
import { mapGetters } from "vuex";
export default {
   name: "Button",
   computed: {
      ...mapGetters({
         account: "current_user",
      }),
   },
   methods: {
      openChat() {
         this.$emit("open-chat");
      },
   },
};
</script>
<style scoped>
.button-container {
  display: flex;
  position: sticky;
  justify-content: flex-end;
  align-items: flex-start;
  bottom: 1rem;
  z-index: 1;
}
.chat-btn {
  margin-right: 1rem;
}
</style>
