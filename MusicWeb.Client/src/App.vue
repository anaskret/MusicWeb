<template>
  <v-app>
    <Navbar @show-alert="showAlert" />
    <v-snackbar v-model="alert_show" :timeout="timeout">
      {{ alert_message }}

      <template v-slot:action="{ attrs }">
        <v-btn
          :color="alert_type"
          text
          v-bind="attrs"
          @click="alert_show = false"
        >
          Zamknij
        </v-btn>
      </template>
    </v-snackbar>
    <div class="chat" v-if="!['Login', 'Register'].includes(this.$route.name)">
      <Chat
        v-if="chatVisibility"
        @user-typing="userTyping"
        @close-chat="closeChat"
      />
    </div>
    <v-main>
      <router-view @show-alert="showAlert" />
    </v-main>
    <Button
      @open-chat="openChat"
      v-if="!['Login', 'Register'].includes(this.$route.name)"
    />
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar";
import Chat from "@/components/chat/Chat";
import Button from "@/components/chat/Button";
export default {
  name: "App",
  components: {
    Navbar,
    Chat,
    Button,
  },
  data() {
    return {
      alert_message: "",
      alert_show: false,
      timeout: 2500,
      alert_type: "",
      chatVisibility: true,
    };
  },
  mounted() {
    this.$friendsHub.$on(
      "friend-request-received",
      this.prepareFriendRequestAlert
    );
  },
  methods: {
    showAlert(message, type) {
      this.alert_show = true;
      this.alert_message = message;
      this.alert_type = type;
    },
    openChat() {
      this.chatVisibility = true;
    },
    prepareFriendRequestAlert(userId, friendId) {
      debugger;
      this.showAlert(`${userId} requested ${friendId}`, "success");
    },
    userTyping: function (e) {
      console.log("typing", e);
    },
    closeChat() {
      this.chatVisibility = false;
    },
  },
};
</script>

<style>
.chat {
  display: flex;
  position: relative;
  z-index: 2;
  justify-content: flex-end;
  align-items: flex-start;
}
</style>
