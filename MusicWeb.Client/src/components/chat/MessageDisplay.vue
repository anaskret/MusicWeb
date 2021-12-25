<template>
  <div
    ref="displayMessageContainer"
    :style="{ background: colors.message.messagesDisplay.bg }"
    class="display-message-container"
    @scroll="updateScrollState"
  >
    <div v-if="loading" class="loader">
      <div class="message-loading"></div>
    </div>
    <div
      v-for="(message, index) in messages"
      :key="index"
      class="message-container"
    >
      <UserMessage v-if="message.myself" :message="message" :colors="colors" />
      <ParticipantMessage v-else :message="message" :colors="colors" />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapMutations } from "vuex";
import UserMessage from "./UserMessage.vue";
import ParticipantMessage from "./ParticipantMessage.vue";
export default {
  name: "MessageDisplay",
  components: {
    UserMessage,
    ParticipantMessage,
  },
  props: {
    colors: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      updateScroll: true,
      lastMessage: null,
      loading: false,
      messageSent: true,
      messageReceived: false,
      toLoad: [
        {
          content: "TEST",
          participantId: 1,
          timestamp: {
            year: 2016,
            month: 3,
            day: 5,
            hour: 10,
            minute: 10,
            second: 3,
            millisecond: 123,
          },
          uploaded: true,
        },
        {
          content: "Test1",
          participantId: "0162bff4-cd0c-4572-a066-51f6f5ce90a6",
          timestamp: {
            year: 2016,
            month: 1,
            day: 5,
            hour: 19,
            minute: 10,
            second: 3,
            millisecond: 123,
          },
          uploaded: true,
        },
        {
          type: "image",
          src: "https://localhost:5001/Users/6bc841d3-b7d7-4381-81b1-1d6fd45fc33d.jpg",
          preview:
            "https://localhost:5001/Users/6bc841d3-b7d7-4381-81b1-1d6fd45fc33d.jpg",
          participantId: "0162bff4-cd0c-4572-a066-51f6f5ce90a6",
          timestamp: {
            year: 2012,
            month: 3,
            day: 7,
            hour: 20,
            minute: 10,
            second: 3,
            millisecond: 123,
          },
          uploaded: true,
        },
        {
          content: "TEST",
          participantId: 1,
          timestamp: {
            year: 2016,
            month: 3,
            day: 5,
            hour: 10,
            minute: 10,
            second: 3,
            millisecond: 123,
          },
          uploaded: true,
        },
      ],
    };
  },
  computed: {
    ...mapGetters(["messages", "current_user"]),
  },
  mounted() {
    this.scrollDown();
    this.$refs.displayMessageContainer.dispatchEvent(new CustomEvent("scroll"));
  },
  updated() {
    if (
      this.messages.length &&
      !this.messageCompare(
        this.messages[this.messages.length - 1],
        this.lastMessage
      )
    ) {
      if (
        this.updateScroll ||
        (this.messageSent &&
          this.messages[this.messages.length - 1].participantId ==
            this.current_user.id) ||
        (this.messageReceived &&
          this.messages[this.messages.length - 1].participantId !=
            this.current_user.id)
      ) {
        this.scrollDown();
        if (this.messages.length) {
          this.lastMessage = this.messages[this.messages.length - 1];
        }
      }
    }
  },
  methods: {
    ...mapMutations(["loadOldMessages"]),
    messageCompare(message1, message2) {
      if (!message2 || !message1) {
        return message1 === message2;
      }
      let participant_equal = message1.participantId == message2.participantId;
      let content_equal = message1.content == message2.content;
      let timestamp_equal =
        message1.timestamp.valueOf() === message2.timestamp.valueOf();

      return participant_equal && content_equal && timestamp_equal;
    },
    updateScrollState({ target: { scrollTop, clientHeight, scrollHeight } }) {
      this.updateScroll = scrollTop + clientHeight >= scrollHeight;

      if (this.toLoad.length > 0 && scrollTop < 20) {
        this.loading = true;
        this.loadMoreMessages();
      }
    },
    loadMoreMessages() {
      setTimeout(() => {
        this.toLoad.forEach((message) => {
          this.loadOldMessages(message);
          this.toLoad = [];
          this.loading = false;
        });
      }, 1000);
    },
    scrollDown() {
      let scrollDiv = this.$refs.displayMessageContainer;
      scrollDiv.scrollTop = scrollDiv.scrollHeight;

      this.updateScroll = false;
    },
  },
};
</script>

<style lang="less">
.chat-container .display-message-container {
  flex: 1;
  overflow-y: scroll;
  overflow-x: hidden;
  display: flex;
  flex-direction: column;
  padding-bottom: 10px;
  max-height: 100%;

  .message-image {
    padding: 6px 10px;
    border-radius: 15px;
    margin: 5px 0 5px 0;
    max-width: 70%;
    position: relative;
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .message-image-display {
    width: 100%;
    max-width: 100px;
    max-height: 100px;
    border-radius: 5px;
    cursor: pointer;
    transition: 0.3s ease;
  }

  .message-image-display:hover {
    opacity: 0.8;
  }

  .message-text > p {
    margin: 5px 0 5px 0;
    font-size: 14px;
  }

  .message-container {
    display: flex;
    flex-wrap: wrap;
    flex-direction: column;
  }

  .message-username {
    font-size: 10px;
    font-weight: bold;
  }

  .icon-sent {
    padding-left: 5px;
    color: #d1d1d1;
  }

  .loader {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 1rem;

    .message-loading {
      width: 16px;
      height: 16px;
      margin: 5px 0 0 0;
      border: 1px solid rgb(187, 183, 183);
      border-left-color: rgb(59, 59, 59);
      border-radius: 50%;
      animation: spin 1.3s ease infinite;
    }
  }

  .message-loading {
    height: 8px;
    width: 8px;
    margin-left: 2px;
    border: 1px solid rgb(187, 183, 183);
    border-left-color: rgb(59, 59, 59);
    border-radius: 50%;
    animation: spin 1.3s ease infinite;
  }

  .message-username-image {
    margin: 10px 10px 0px 10px;
    font-size: 12px;
    font-weight: bold;
  }
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
