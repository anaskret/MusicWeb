import Vue from "vue";
import Vuex from "vuex";
import moment from "moment";
import useAccounts from "@/modules/accounts";

import { auth } from "./authModule";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: { auth },
  state: {
    connectionError: false,
    tokenExpired: false,
    searchingValue: "",
    serverUrl: "https://localhost:5001",
    messages: [
      {
        content: "Hey, Kacper! How are you today",
        participantId: 1,
        timestamp: {
          year: 2012,
          month: 3,
          day: 5,
          hour: 17,
          minute: 10,
          second: 3,
          millisecond: 123,
        },
        uploaded: true,
        type: "text",
      },
      {
        content: "Hey, Kacper! How are you today",
        participantId: 1,
        timestamp: {
          year: 2012,
          month: 3,
          day: 5,
          hour: 17,
          minute: 10,
          second: 3,
          millisecond: 123,
        },
        uploaded: true,
        type: "text",
      },
      {
        content: "Hey, Kacper! How are you today?",
        participantId: 1,
        timestamp: {
          year: 2012,
          month: 3,
          day: 6,
          hour: 17,
          minute: 30,
          second: 3,
          millisecond: 123,
        },
        uploaded: true,
        type: "text",
      },
      {
        content: "Hey, Kacper! How are you today?",
        participantId: 1,
        timestamp: {
          year: 2012,
          month: 3,
          day: 7,
          hour: 18,
          minute: 10,
          second: 3,
          millisecond: 123,
        },
        uploaded: true,
        type: "text",
      },
      {
        type: "image",
        src: "https://localhost:5001/Users/6bc841d3-b7d7-4381-81b1-1d6fd45fc33d.jpg",
        preview:
          "https://localhost:5001/Users/6bc841d3-b7d7-4381-81b1-1d6fd45fc33d.jpg",
        participantId: 1,
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
        content: "Hey, Monisia! I'm felling really fine this evening.",
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
        type: "text",
      },
      {
        content: "Ok, nice to hear that!",
        participantId: 1,
        timestamp: {
          year: 2012,
          month: 3,
          day: 7,
          hour: 20,
          minute: 11,
          second: 3,
          millisecond: 123,
        },
        uploaded: true,
        type: "text",
      },
    ],
    current_user: {},
    participants: [],
    chatTitle: "",
    placeholder: "",
  },
  mutations: {
    newMessage(state, message) {
      message.timestamp = moment.utc(message.timestamp).format("LT");
      message.myself = message.participantId === state.current_user.id;
      state.messages = [...state.messages, message];
      setTimeout(() => {
        message.uploaded = true;
        if (message.preview) {
          message.src = message.preview;
        }
      }, 1000);
    },
    loadOldMessages(state, message) {
      message.timestamp = moment.utc(message.timestamp).format("LT");
      message.myself = message.participantId === state.current_user.id;
      state.messages.unshift(message);
      setTimeout(() => {
        message.uploaded = true;
        if (message.preview) {
          message.src = message.preview;
        }
      }, 1000);
    },
    setParticipants(state, participants) {
      state.participants = participants;
    },
    setCurrentUser(state) {
      const { getAccountById } = useAccounts();
      getAccountById(state.auth.userId).then((response) => {
        state.current_user = response;
        if (state.messages != null && state.messages != "") {
          state.messages = state.messages.map((message) => {
            if (message.timestamp)
              typeof message.timestamp == "object" &&
                (message.timestamp = moment
                  .utc(message.timestamp)
                  .format("LT"));
            else message.timestamp = moment.utc(message.timestamp).format("LT");

            if (!("myself" in message))
              message.myself = message.participantId === state.current_user.id;
            return message;
          });
        }
      });
    },
    setPlaceholder(state, placeholder) {
      state.placeholder = placeholder;
    },
  },
  actions: {},
  getters: {
    server_url(state) {
      return state.serverUrl;
    },
    messages(state) {
      let messages = [];
      state.messages.forEach((message) => {
        let newMessage = { ...message };
        messages.push(newMessage);
      });
      return messages;
    },
    current_user(state) {
      return state.current_user;
    },
    participants(state) {
      return state.participants;
    },
    placeholder(state) {
      return state.placeholder;
    },
  },
});
