<template>
  <div class="header-container" :style="{ background: colors.header.bg }">
    <div class="title">
      <p class="paticipants">
        <span v-for="participant in participants" :key="participant.id">
          {{ participant.name }}
        </span>
      </p>
    </div>
    <div class="close">
      <font-awesome-icon
        class="close-button"
        :color="colors.submitImageIcon"
        icon="times"
        @click="closeChat"
      />
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
      participants: "participants",
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

  .close-button:hover {
    color: #969393;
  }
}
</style>
