<template>
  <div class="chat-container">
    <Header :colors="colors" v-on="$listeners" />
    <MessageDisplay :colors="colors" v-on="$listeners" />
    <Sender :colors="colors" v-on="$listeners" />
  </div>
</template>

<script>
import Header from "./Header.vue";
import MessageDisplay from "./MessageDisplay.vue";
import Sender from "./Sender";
import { mapMutations, mapGetters } from "vuex";

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
      participants: [
        {
          name: "Monisia",
          id: 1,
          profilePicture: "",
        },
      ],
    };
  },
  computed: {
    ...mapGetters({
      account: "current_user",
    }),
  },
  watch: {
    participants() {
      this.setParticipants(this.participants);
    },
    placeholder() {
      this.setPlaceholder(this.placeholder);
    },
  },
  created() {
    this.setParticipants(this.participants);
    this.setPlaceholder(this.placeholder);
  },
  methods: {
    ...mapMutations(["setParticipants", "setPlaceholder"]),
  },
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
