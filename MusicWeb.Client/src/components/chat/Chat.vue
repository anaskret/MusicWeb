<template>
  <div class="chat-container">
    <Header :colors="colors" v-on="$listeners" />
    <MessageDisplay :colors="colors" v-on="$listeners" />
    <Sender :colors="colors" v-on="$listeners" @refresh-messages="getMessages" />
  </div>
</template>

<script>
import Header from "./Header.vue";
import MessageDisplay from "./MessageDisplay.vue";
import Sender from "./Sender";
import { mapMutations, mapGetters } from "vuex";
import useChats from "@/modules/chats";

export default {
  name: "Chat",
  components: {
    Header,
    MessageDisplay,
    Sender,
  },
  data() {
    return {
      placeholder: "Start typing...",
      colors: {
        header: {
          bg: "#2C2F33",
          text: "#d9d9d9",
        },
        message: {
          myself: {
            bg: "#d9d9d9",
            text: "#000",
          },
          others: {
            bg: "#2C2F33",
            text: "#d9d9d9",
          },
          messagesDisplay: {
            bg: "#0d1117",
          },
        },
        submit_icon: "#d9d9d9",
        submit_image_icon: "#d9d9d9",
      },
    };
  },
  computed: {
    ...mapGetters({
      account: "current_user",
      current_chat: "current_chat",
      chat_page: "chat_page",
      participant: "participant"
    }),
  },
  watch: {
    placeholder() {
      this.setPlaceholder(this.placeholder);
    },
    current_chat: {
        immediate: true,
        handler(){
            this.getMessages();
        }
    }
  },
  created() {
    this.setPlaceholder(this.placeholder);
  },
  methods: {
    ...mapMutations(["setPlaceholder", "setMessages"]),
  },
  setup() {
    const { getPagedMessages, readFriendMessages } = useChats();
  
    const getMessages = function (){
        readFriendMessages({chatId: this.current_chat.id, userId: this.participant.id}).then((response) =>
        {
            if(response.status == 200){
                getPagedMessages(this.current_chat.id, this.chat_page, 7).then((response) => 
                {
                    this.setMessages(response);
                });
            } else {
                this.$emit(
                  "show-alert",
                  `Error something went wrong. ${response.message}`,
                  "error"
                  );
            }
        });
    }

    return {
        getMessages
    }
  }
};
</script>

<style scoped>
.chat-container {
  display: flex;
  position: fixed;
  flex-direction: column;
  align-items: stretch;
  overflow: hidden;
  bottom: 1rem;
  right: 6rem;
  height: 50%;
  background: #f0eeee;
  border-radius: 10px;
}
</style>
