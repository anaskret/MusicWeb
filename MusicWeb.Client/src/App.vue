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
        ref="chat_component" 
      />
      <!-- Add calling getPagedMessages from chat or MessageDisplay -->
    </div>
    <v-main>
      <router-view @show-alert="showAlert" />
    </v-main>
    <FriendButton
        @show-friend-list="setDrawer"
        v-if="!['Login', 'Register'].includes(this.$route.name)"
    />
    <Button
        @open-chat="openChat"
        v-if="!['Login', 'Register'].includes(this.$route.name)"
    />
    <FriendList
        :drawer="drawer"
        @update-drawer="setDrawer"
        @show-alert="showAlert"
        @open-chat="openChat"
        ref="friend_list_component"
        v-if="!['Login', 'Register'].includes(this.$route.name)"
    />
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar";
import Chat from "@/components/chat/Chat";
import Button from "@/components/chat/Button";
import FriendList from "@/components/FriendList";
import FriendButton from "@/components/FriendButton";
export default {
  name: "App",
  components: {
    Navbar,
    Chat,
    Button,
    FriendList,
    FriendButton
  },
  data() {
    return {
      alert_message: "",
      alert_show: false,
      timeout: 2500,
      alert_type: "",
      chatVisibility: true,
      drawer: null
    };
  },
  mounted() {
    this.$friendsHub.$on(
      "friend-request-received",
      this.prepareFriendRequestAlert
    );
    this.$friendsHub.$on(
      "friend-request-accepted",
      this.prepareFriendRequestAcceptedAlert
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
    prepareFriendRequestAlert(userId, friendId, fullName) {
      console.log(userId, friendId);
      this.$refs.friend_list_component.getFriendsList();
      this.showAlert(`${fullName} sent you an invitation.`, "success");
    },
    prepareFriendRequestAcceptedAlert(userId, friendId, fullName) {
      console.log(userId, friendId);
      this.$refs.friend_list_component.getFriendsList();
      this.showAlert(`${fullName} accepted your invitation.`, "success");
    },
    userTyping: function (e) {
      console.log("typing", e);
    },
    closeChat() {
      this.chatVisibility = false;
    },
    setDrawer(drawer){
        this.drawer = drawer;
    }
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
