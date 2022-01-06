<template>
  <div class="sender-container">
    <div class="message">
      <v-text-field
        :placeholder="placeholder"
        v-model="text_input"
        color="white"
        @input="handleTyping"
        @keyup.enter.exact="sendMessage"
      />
    </div>
    <div class="send-icon" @click="sendMessage">
      <font-awesome-icon :color="colors.submit_icon" icon="paper-plane" />
    </div>
    <!-- TODO Not clicable all item only image -->
    <v-file-input
      class="send-icon"
      hide-input
      v-model="image_input"
      :color="colors.submit_image_icon"
      prepend-icon="mdi-image"
      @change="sendImage"
    ></v-file-input>
  </div>
</template>

<script>
import Message from "@/models/Message";
import { mapMutations, mapGetters } from "vuex";
import moment from "moment";
export default {
  name: "Sender",
  props: {
    colors: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      text_input: "",
      image_input: null,
    };
  },
  computed: {
    ...mapGetters({
      account: "current_user",
      placeholder: "placeholder",
    }),
  },
  methods: {
    ...mapMutations(["newMessage"]),
    handleTyping(e) {
      this.$emit("user-typing", e);
    },
    async sendMessage() {
      const input_text = this.text_input;
      this.text_input = "";
      const text_not_empty = /[^\s]+/i;
      const text_matched = input_text.match(/^\s*((.|\n)+?)\s*$/i);
      if (input_text && text_not_empty.test(input_text) && text_matched) {
        let message = new Message({
          content: text_matched[1],
          participant_id: this.account.id,
          send_date: moment().format(),
          uploaded: false,
          type: "text",
        });
        this.newMessage(message);
      }
    },
    async sendImage(file) {
      let message = new Message({
        type: "image",
        preview: URL.createObjectURL(file),
        src: "",
        content: "image",
        participant_id: this.account.id,
        send_date: moment().format(),
        uploaded: false,
        viewed: false,
      });
      this.newMessage(message);
    },
  },
};
</script>

<style lang="less">
.v-input {
  flex: none;
}
.v-input__prepend-outer {
  margin: 0 !important;
}
.chat-container .sender-container {
  display: flex;
  align-items: center;
  height: 4rem;
  background: #2c2f33;
  padding: 0 20px 0 20px;

  .message {
    flex: 1;
  }

  .send-icon {
    cursor: pointer;
    margin-left: 10px;
    opacity: 0.7;
    transition: 0.3s;
    border-radius: 11px;
    padding: 8px;
    margin-top: 0;
  }

  .send-icon:hover {
    opacity: 1;
    background: #7c7c7c;
  }
}
.send-icon:hover {
  opacity: 1;
  background: #7c7c7c;
}
.send-icon:hover {
  opacity: 1;
  background: #7c7c7c;
}
</style>
