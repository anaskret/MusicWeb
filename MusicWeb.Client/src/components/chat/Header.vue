<template>
  <div class="header-container" :style="{ background: colors.header.bg }">
    <div class="title">
      <p class="paticipants">
        <span>
          {{ participant.firstname }}
        </span>
      </p>
    </div>
    <div class="close">
      <font-awesome-icon
        class="close-button-icon"
        :color="colors.submit_image_icon"
        icon="times"
        @click="closeChat"
      ></font-awesome-icon>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "Header",
  props: {
    colors: {
      type: Object,
      required: true,
    },
  },
  computed: {
    ...mapGetters({
      account: "current_user",
      participant: "participant",
    }),
  },
  methods: {
    closeChat() {
      this.$emit("close-chat");
    },
  },
};
</script>

<style lang="less">
.chat-container .header-container {
  display: flex;
  align-items: center;
  height: 5rem;
  padding: 5px 20px 0 20px;
  z-index: 2;

  .title {
    flex: 1;
    text-align: left;
  }
  .title > p {
    margin-bottom: 0;
  }

  .paticipants {
    color: #e4e4e4;
    overflow: hidden;
  }

  .close {
    color: #fff;
    font-size: 20px;
    cursor: pointer;
  }

  .close-button-icon:hover {
    color: #969393;
  }
}
</style>
