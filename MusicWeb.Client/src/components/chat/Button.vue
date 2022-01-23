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
      last_open_chat_id: "last_open_chat_id",
    }),
  },
  methods: {
    openChat() {
      this.$root.$emit('get-last-chat', this.last_open_chat_id);
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
}
.chat-btn {
  margin-right: 1rem;
}
</style>
