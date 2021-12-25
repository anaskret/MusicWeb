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
    messageHub.SendMessage = (friendId, messageId) => {
      return startedPromise
        .then(() => connection.invoke("SendMessage", friendId, messageId))
        .catch(console.error);
    };

    connection.on("SendMessage", (friendId, messageId) => {
      messageHub.$emit("friend-sent-message", friendId, messageId);
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
