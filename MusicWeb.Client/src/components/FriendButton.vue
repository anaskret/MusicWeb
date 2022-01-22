<template>
  <div class="friend-button-container">
    <v-btn fab class="friend-btn" @click.stop="showFriendList">
      <font-awesome-icon
        class="icon pa-1"
        icon="user-friends"
        size="2x"
        outlined
      ></font-awesome-icon>
    </v-btn>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "FriendButton",
  computed: {
    ...mapGetters({
      account: "current_user",
    }),
  },
  methods: {
    showFriendList() {
      this.$emit("show-friend-list", true);
      this.$messageHub.subscribeUserGroup(this.account.username);
      this.$friendsHub.subscribeUserGroup(this.account.username);
    },
  },
};
</script>
<style scoped>
.friend-button-container {
  display: flex;
  position: sticky;
  justify-content: flex-end;
  align-items: flex-start;
  bottom: 5.5rem;
}
.friend-btn {
  margin-right: 1rem;
}
</style>
