<template>
  <div class="user-message-container">
    <div class="message-content">
      <template v-if="message.type == 'image'">
        <div class="message-image">
          <expandable-image class="message-image-display" :src="message.src">
            <template v-slot:placeholder>
              <v-row class="fill-height ma-0" align="center" justify="center">
                <v-progress-circular
                  indeterminate
                  color="grey lighten-5"
                ></v-progress-circular>
              </v-row>
            </template>
          </expandable-image>
        </div>
      </template>
      <template v-else>
        <div
          class="message-text"
          :style="{ background: colors.message.myself.bg }"
        >
          <p :style="{ color: colors.message.myself.text }">
            {{ message.text }}
          </p>
        </div>
      </template>
      <div class="message-send_date">
        <template>
          {{ message.send_date }}
        </template>
        <font-awesome-icon
          v-if="message.uploaded"
          class="icon-sent"
          icon="check"
        />
        <div v-else class="message-loading"></div>
      </div>
    </div>
    <div class="thumb-img-container">
      <v-img
        v-if="current_user.imagePath"
        class="user-thumb"
        :src="`${server_url}/${current_user.imagePath}`"
      >
      </v-img>
      <v-img
        v-else
        class="user-thumb"
        :src="require(`@/assets/unknownUser.svg`)"
      >
      </v-img>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "UserMessage",
  props: {
    message: {
      type: Object,
      required: true,
    },
    colors: {
      type: Object,
      required: true,
    },
  },
  computed: {
    ...mapGetters(["messages", "current_user", "server_url"]),
  },
};
</script>

<style lang="less">
.display-message-container .user-message-container {
  display: flex;
  align-items: flex-end;
  justify-content: flex-end;
  padding-right: 10px;

  .message-content {
    display: flex;
    align-items: flex-end;
    justify-content: flex-start;
    flex-direction: column;
    flex-grow: 1;
  }

  .user-thumb {
    width: 25px;
    height: 25px;
    border-radius: 50%;
    margin-left: 10px;
  }

  .message-send_date {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    text-align: left;
    overflow-wrap: break-word;
    width: 100%;
    padding: 2px 7px;
    border-radius: 15px;
    margin: 0;
    max-width: 70%;
    font-size: 10px;
    color: #bdb8b8;
  }

  .message-text {
    word-break: break-word;
    text-align: left;
    white-space: pre-wrap;
    overflow-wrap: break-word;
    background: #bdb8b8;
    padding: 6px 10px;
    line-height: 14px;
    border-radius: 15px;
    margin: 5px 0 5px 0;
    max-width: 70%;
    border-bottom-right-radius: 0px;
  }
}
</style>
