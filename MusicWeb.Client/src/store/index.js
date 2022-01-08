import Vue from "vue";
import Vuex from "vuex";
import moment from "moment";
import useAccounts from "@/modules/accounts";
import useChats from "@/modules/chats";
import Message from "@/models/Message";

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
    chat_page: 0,
  },
  mutations: {
    newMessage(state, message) {
      const { addNewMessage } = useChats();
      let model_message = new Message(message);
      model_message.send_date = moment().format("LT");
      model_message.myself =
        model_message.participant_id === state.current_user.id;
      state.messages = [...state.messages, model_message];
      addNewMessage(message).then(
        (response) => {
          if (response.status == 200) {
            state.messages.at(-1).uploaded = true;
            if (state.messages.at(-1).preview) {
              state.messages.at(-1).src = state.messages.at(-1).preview;
            }
          } else {
            this.$emit(
              "show-alert",
              `Something went wrong. Error ${response.status}`,
              "error"
            );
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Something went wrong. ${error.response.status} ${error.response.data}`,
            "error"
          );
        }
      );
    },
    loadOldMessages(state, messages) {
      messages = messages.map((message) => {
        if (moment(message.send_date).format("L") == moment().format("L")) {
          message.send_date = moment(message.send_date).format("LT");
        } else {
          message.send_date = moment(message.send_date).calendar();
        }
        message.myself = message.participant_id === state.current_user.id;
        message.uploaded = true;
        if (message.preview) {
          message.src = message.preview;
        }
        return message;
      });
      state.messages = [...messages, ...state.messages];
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
      state.chat_page = 0;
      state.current_chat = chat;
    },
    setMessages(state, messages) {
      state.messages = messages;
      if (state.messages != null && state.messages != "") {
        state.messages = state.messages.map((message) => {
          if (moment(message.send_date).format("L") == moment().format("L")) {
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
    incrementChatPage(state) {
      state.chat_page += 1;
    },
    setAlbum(state, album) {
      state.album = album;
    },
    setSong(state, song) {
      state.song = song;
    },
    setRanking(state, rank_artists) {
      state.rank_artists = rank_artists;
    },
    setArtist(state, artist) {
      state.artist = artist;
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
    participant(state) {
      return state.participant;
    },
    placeholder(state) {
      return state.placeholder;
    },
    current_chat(state) {
      return state.current_chat;
    },
    chat_page(state) {
      return state.chat_page;
    },
    album(state) {
      return state.album;
    },
    song(state) {
      return state.song;
    },
    rankArtists(state) {
      return state.rank_artists;
    },
    artist(state) {
      return state.artist;
    },
  },
});
