import {
  HubConnectionBuilder,
  HttpTransportType,
  LogLevel,
} from "@aspnet/signalr";
import store from "@/store";
export default {
  install(Vue) {
    const connection = new HubConnectionBuilder()
      .withUrl(`${store.state.serverUrl}/userhub`, {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets,
      })
      .configureLogging(LogLevel.Information)
      .build();
    const userHub = new Vue();
    Vue.prototype.$userHub = userHub;

    //hub methods
    userHub.subscribeUserGroup = (userName) => {
      return startedPromise
        .then(() => connection.invoke("SubscribeUserGroup", userName))
        .catch(console.error);
    };
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
