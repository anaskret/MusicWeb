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
    <div class="chat" v-if="!['Login', 'Register', 'PasswordReset'].includes(this.$route.name)">
      <Chat
        v-if="chat_visibility"
        @user-typing="userTyping"
        @close-chat="closeChat"
        @show-alert="showAlert"
        ref="chat_component"
      />
    </div>
    <v-main>
      <router-view @show-alert="showAlert" />
    </v-main>
    <FriendButton
      @show-friend-list="setDrawer"
      v-if="!['Login', 'Register', 'PasswordReset'].includes(this.$route.name)"
    />
    <ChatButton
      @open-chat="openChat"
      v-if="!['Login', 'Register', 'PasswordReset'].includes(this.$route.name)"
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
import ChatButton from "@/components/chat/Button";
import FriendList from "@/components/FriendList";
import FriendButton from "@/components/FriendButton";
import { mapGetters, mapMutations } from "vuex";
import useChats from "@/modules/chats";
export default {
  name: "App",
  components: {
    Navbar,
    Chat,
    ChatButton,
    FriendList,
    FriendButton,
  },
  data() {
    return {
      alert_message: "",
      alert_show: false,
      timeout: 2500,
      alert_type: "",
      drawer: null,
    };
  },
  computed: {
    ...mapGetters(["current_chat", "current_user", "chat_visibility"]),
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
    this.$messageHub.$on(
      "friend-sent-message",
      this.refreshChat
    );
  },
  methods: {
    ...mapMutations(["setMessages", "toggleChatVisability", "setCurrentUser"]),
    showAlert(message, type) {
      this.alert_show = true;
      this.alert_message = message;
      this.alert_type = type;
    },
    openChat() {
      this.toggleChatVisability(true);
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
    refreshChat(friendUsername, chatId){
      console.log(friendUsername, chatId)
      this.getMessages(chatId);
    },
    userTyping: function (e) {
      console.log("typing", e);
    },
    closeChat() {
      this.toggleChatVisability(false);
    },
    setDrawer(drawer) {
      this.drawer = drawer;
    },
  },
  created() { 
    this.setCurrentUser();
  },
  setup() {
    const { getPagedMessages, readFriendMessages } = useChats();
  
    const getMessages = function (chat_id, chat_page = 0){
        readFriendMessages({chatId: chat_id, userId: this.current_user.id}).then((response) =>
        {
            if(response.status == 200){
                getPagedMessages(chat_id, chat_page, 7).then((response) => 
                {
                    this.setMessages(response);
                });
            } else {
                this.showAlert(`Error something went wrong. ${response.message}`, "error");
            }
        });
    }

    return {
        getMessages
    }
  }
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
