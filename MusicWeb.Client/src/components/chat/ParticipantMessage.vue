<template>
  <div class="participant-message-container">
    <div class="thumb-img-container">
      <v-img
        v-if="participant.imagePath"
        class="participant-thumb"
        :src="`${server_url}/${participant.imagePath}`"
      >
      </v-img>
      <v-img
        v-else
        class="participant-thumb"
        :src="require(`@/assets/unknownUser.svg`)"
      >
      </v-img>
    </div>
    <div class="message-content">
      <template v-if="message.image_path && !message.text">
        <p class="message-username-image">{{participant.firstname}}</p>
        <div class="message-image">
          <expandable-image class="message-image-display" :src="`${server_url}/${message.image_path}`">
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
          :style="{ background: colors.message.others.bg }"
        >
          <p
            class="message-username"
            :style="{ color: colors.message.others.text }"
          >
            {{participant.firstname}}
          </p>
          <p :style="{ color: colors.message.others.text }">
            {{ message.text }}
          </p>
        </div>
      </template>
      <div class="message-send_date">
        <template>
          {{ message.send_date }}
        </template>
        <font-awesome-icon
          v-if="message.is_read"
          class="icon-sent"
          icon="check"
        />
        <div v-else class="message-loading"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from "vuex";
export default {
  name: "ParticipantMessage",
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
    ...mapGetters(["messages", "current_user", "participant", "server_url"]),
  },
};
</script>

<style lang="less">
.display-message-container .participant-message-container {
  display: flex;
  align-items: flex-end;
  padding-left: 10px;

  .message-content {
    display: flex;
    align-items: flex-start;
    justify-content: flex-start;
    flex-direction: column;
    flex-grow: 1;
  }

  .participant-thumb {
    width: 25px;
    height: 25px;
    border-radius: 50%;
    margin-right: 10px;
  }

  .message-send_date {
    display: flex;
    justify-content: flex-start;
    align-items: center;
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
    overflow-wrap: break-word;
    text-align: left;
    white-space: pre-wrap;
    word-break: break-word;
    background: #fff;
    padding: 6px 10px;
    line-height: 14px;
    border-radius: 15px;
    margin: 5px 0 5px 0;
    max-width: 70%;
    border-bottom-left-radius: 0px;
  }
}
</style>
