<template>
  <v-app>
    <Navbar />
    <v-snackbar
        v-model="alertShow"
        :timeout="timeout"
      >
        {{ alertMessage }}
  
        <template v-slot:action="{ attrs }">
          <v-btn
            :color="alertType"
            text
            v-bind="attrs"
            @click="alertShow = false"
          >
            Zamknij
          </v-btn>
        </template>
    </v-snackbar>
    <v-main>
      <router-view @show-alert="showAlert" />
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar";
export default {
  name: "App",
  data() {
    return {
      alertMessage: '',
      alertShow: false,
      timeout: 2500,
      alertType: ''
    };
  },
  methods: {
    showAlert(message, type){
      this.alertShow = true;
      this.alertMessage = message;
      this.alertType = type;
    }
  },
  components: {
    Navbar,
  },
};
</script>
