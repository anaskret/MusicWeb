<template>
  <div class="sender-container">
    <div class="message">
    <v-text-field
        v-if="sending_photo"
        v-model="sending_photo"
        solo
        clearable
    ></v-text-field>
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
      @change="prepareImage"
    ></v-file-input>
  </div>
</template>

<script>
import { mapMutations, mapActions, mapGetters } from "vuex";
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
      sending_photo: ""
    };
  },
  computed: {
    ...mapGetters({
      account: "current_user",
      placeholder: "placeholder",
      current_chat: "current_chat",
      base64_image: "base64_image"
    }),
  },
  methods: {
    ...mapMutations(["newMessage", "clearBase64Image"]),
    ...mapActions(['setBase64']),
    handleTyping(e) {
      this.$emit("user-typing", e);
    },
    async sendMessage() {
      let message = {
          chatId: this.current_chat.id,
          senderId: this.account.id,
          text: "",
          imageBytes: "",
          imagePath: "",
          isRead: false
      };
      const input_text = this.text_input;
      this.text_input = "";
      const text_not_empty = /[^\s]+/i;
      const text_matched = input_text.match(/^\s*((.|\n)+?)\s*$/i);
      if (this.image_input && this.base64_image && !input_text && !text_not_empty.test(input_text) && !text_matched){
        message.imageBytes = this.base64_image;
        message.imagePath = `/Chats/${this.current_chat.id}`;
        this.$emit("refresh-messages");
      }
      else if (input_text && text_not_empty.test(input_text) && text_matched) {
        message.text = text_matched[1];
      }

      if((this.image_input && this.base64_image) || (input_text && text_not_empty.test(input_text) && text_matched)){
        this.newMessage(message);
        this.clearBase64Image();
        this.sending_photo = "";
      }
    },
    prepareImage(file) {
      if (file != null && file != "") {
        this.sending_photo = file.name;
        this.setBase64(file);
      }
    },
  },
  watch: {
      sending_photo(){
          if(this.base64_image && !this.sending_photo){
            this.clearBase64Image();
          }
      }
  }
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
