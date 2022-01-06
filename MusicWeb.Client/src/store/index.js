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
    messages: [],
    current_user: {},
    participant: {},
    chatTitle: "",
    placeholder: "",
    current_chat: {},
    chat_page: 0
  },
  mutations: {
    newMessage(state, message) {
      message.send_date = moment(message.send_date).format("LT");
      message.myself = message.participant_id === state.current_user.id;
      state.messages = [...state.messages, message];
      setTimeout(() => {
        message.uploaded = true;
        if (message.preview) {
          message.src = message.preview;
        }
      }, 1000);
    },
    loadOldMessages(state, message) {
      message.send_date = moment(message.send_date).calendar();
      message.myself = message.participant_id === state.current_user.id;
      state.messages.unshift(message);
      setTimeout(() => {//TODO delete this, wait to upload
        message.uploaded = true;
        if (message.preview) {
          message.src = message.preview;
        }
      }, 1000);
    },
    setParticipant(state, participant) {
      state.participant = participant;
    },
    setCurrentUser(state) {
      const { getAccountById } = useAccounts();
      getAccountById(state.auth.userId).then((response) => {
        state.current_user = response;
      });
    },
    setPlaceholder(state, placeholder) {
      state.placeholder = placeholder;
    },
    setCurrentChat(state, chat) {
      state.current_chat = chat;
    },
    setMessages(state, messages){
        state.messages = messages;
        if (state.messages != null && state.messages != "") {
            state.messages = state.messages.map((message) => {
                if(moment(message.send_date).format("L") == moment().format("L")){
                    message.send_date = moment(message.send_date).format("LT");
                } else {
                    message.send_date = moment(message.send_date).calendar();
                }
                
                if (!("myself" in message))
                    message.myself = message.participant_id === state.current_user.id;

                message.uploaded = true; //TODO delete this, wait to upload
                return message;
            });
          }
    },
    incrementChatPage(state){
        state.chat_page += 1;
    }
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
    participant(state) {
      return state.participant;
    },
    placeholder(state) {
      return state.placeholder;
    },
    current_chat(state) {
      return state.current_chat;
    },
    chat_page(state){
      return state.chat_page;
    }
  },
});
