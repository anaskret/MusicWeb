import {
  HubConnectionBuilder,
  HttpTransportType,
  LogLevel,
} from "@aspnet/signalr";
import store from "@/store";
export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(`${store.state.serverUrl}/friendshub`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .configureLogging(LogLevel.Information)
      .build();
    const friendsHub = new Vue();
    Vue.prototype.$friendsHub = friendsHub;

    //hub methods
    friendsHub.sendFriendRequest = (userId, friendId) => {
      return startedPromise
        .then(() => connection.invoke("SendFriendRequest", userId, friendId))
        .catch(console.error);
    };

    connection.on("SendFriendRequest", (userId, friendId, fullName) => {
      friendsHub.$emit("friend-request-received", userId, friendId, fullName);
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
