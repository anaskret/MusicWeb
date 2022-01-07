import {
  HubConnectionBuilder,
  HttpTransportType,
  LogLevel,
} from "@aspnet/signalr";
import store from "@/store";
export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(`${store.state.serverUrl}/messagehub`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .configureLogging(LogLevel.Information)
      .build();
    const messageHub = new Vue();
    Vue.prototype.$messageHub = messageHub;

    //hub methods
    messageHub.subscribeUserGroup = (userName) => {
        return startedPromise
            .then(() => connection.invoke("SubscribeUserGroup", userName))
            .catch(console.error);
    };
    connection.on("SendMessage", (friendUsername, chatId) => {
      messageHub.$emit("friend-sent-message", friendUsername, chatId);
    });

    let startedPromise = null;

    function start() {
      startedPromise = connection.start().catch((err) => {
        console.error("Failed to connect with hub", err);
        return new Promise((resolve, reject) =>
          setTimeout(() => start().then(resolve).catch(reject), 20000)
        );
      });
      return startedPromise;
    }
    connection.onclose(() => start());

    start();
  },
};
