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
    friendsHub.subscribeUserGroup = (userName) => {
        return startedPromise
          .then(() => connection.invoke("SubscribeUserGroup", userName))
          .catch(console.error);
      };
    friendsHub.sendFriendRequest = (userId, friendId, fullName) => {
      return startedPromise
        .then(() => connection.invoke("SendFriendRequest", userId, friendId, fullName))
        .catch(console.error);
    };

    connection.on("SendFriendRequest", (userId, friendId, fullName) => {
      friendsHub.$emit("friend-request-received", userId, friendId, fullName);
    });

    friendsHub.friendRequestAccepted = (userId, friendId) => {
      return startedPromise
        .then(() => connection.invoke("FriendRequestAccepted", userId, friendId))
        .catch(console.error);
    };

    connection.on("FriendRequestAccepted", (userId, friendId, fullname) => {
      friendsHub.$emit("friend-request-accepted", userId, friendId, fullname);
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
