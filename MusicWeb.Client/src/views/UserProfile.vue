<template>
  <v-container fluid class="py-16 d-flex justify-center">
    <v-row justify="center">
      <v-col md="2" sm="6">
        <v-img :src="require('@/assets/BandPhoto.svg')" contain />
      </v-col>
      <v-col md="4" sm="9">
        <div class="profile-header">
          <p>Profil</p>
          <h1 class="profile-title">
            <span class="text-uppercase display-2">
              {{ account.firstname }} {{ account.lastname }}
            </span>
            <v-dialog v-model="edit_dialog" persistent max-width="600px">
              <template v-slot:activator="{ on, attrs }">
                <v-btn text v-bind="attrs" v-on="on">
                  <font-awesome-icon class="icon" icon="pen" color="#white" />
                </v-btn>
              </template>
              <v-card class="editDialog">
                <v-card-title>
                  <span class="text-h5">Wprowadź nowe dane</span>
                </v-card-title>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          class="p-4"
                          label="Imię"
                          prepend-icon="mdi-account"
                          v-model.trim="$v.account.firstname.$model"
                          :error-messages="firstnameErrors"
                          :counter="12"
                          required
                          @input="$v.account.firstname.$touch()"
                          @blur="$v.account.firstname.$touch()"
                        ></v-text-field>
                      </v-col>
                      <v-col cols="12" sm="6" md="6">
                        <v-text-field
                          class="p-4"
                          label="Nazwisko"
                          prepend-icon="mdi-account"
                          v-model.trim="$v.account.lastname.$model"
                          :error-messages="lastnameErrors"
                          :counter="20"
                          required
                          @input="$v.account.lastname.$touch()"
                          @blur="$v.account.lastname.$touch()"
                        ></v-text-field>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn @click="edit_dialog = false"> Anuluj </v-btn>
                  <v-btn @click="edit_dialog = false"> Zapisz </v-btn>
                </v-card-actions>
              </v-card>
            </v-dialog>
          </h1>
        </div>
      </v-col>
      <v-col md="9">
        <ReviewList :reviews="reviews" />
      </v-col>
      <v-col md="10">
        <item-carousel
          :items="artists"
          :component_title="artists_title"
          :component_link_title="artists_link_title"
        />
      </v-col>
      <v-col md="10">
        <item-carousel
          :items="genres"
          :component_title="genres_title"
          :component_link_title="genres_link_title"
        />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import ReviewList from "@/components/ReviewList";
import ItemCarousel from "../components/ItemCarousel.vue";
import useAccounts from "@/modules/accounts";
import Account from "@/models/Account";
import { required, minLength, maxLength } from "vuelidate/lib/validators";
export default {
  name: "UserProfile",
  components: {
    ReviewList,
    ItemCarousel,
  },
  data() {
    return {
      reviews: [],
      artists: [],
      genres: [],
      artists_title: "Ulubieni artyści",
      genres_title: "Ulubione gatunki",
      artists_link_title: "Zobacz wszystko",
      genres_link_title: "Zobacz wszystko",
      account: new Account(),
      edit_dialog: false,
    };
  },
  created() {
    this.getReviews();
    this.getArtists();
    this.getGenres();
    this.getAccount();
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    firstnameErrors() {
      return this.prepareErrorArray("firstname");
    },
    lastnameErrors() {
      return this.prepareErrorArray("lastname");
    },
  },
  validations: {
    account: {
      firstname: {
        required,
        minLength: minLength(3),
        maxLength: maxLength(12),
      },
      lastname: {
        required,
        minLength: minLength(3),
        maxLength: maxLength(20),
      },
    },
  },
  methods: {
    getReviews() {
      this.reviews = [
        {
          img: "weather",
          album: "Weather Systems",
          band: "Anathema",
          title: "Dzieło sztuki!",
          content:
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc.",
        },
        {
          img: "werehere",
          album: "We're Here Because We're Here",
          band: "Anathema",
          title: "Dzieło sztuki!",
          content:
            "2Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc. Praesent felis nibh, laoreet et sapien in, tincidunt eleifend tellus. Morbi ante urna, mollis quis eros sed, pulvinar venenatis lacus. Quisque interdum urna molestie porta auctor. Aliquam erat volutpat. Integer in aliquam sem. Quisque varius purus eu eros elementum varius. ",
        },
        {
          img: "naturaldisaster",
          album: "A Natural Disaster",
          band: "Anathema",
          title: "Dzieło sztuki!",
          content:
            "3Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec fringilla magna fringilla nisi tristique, vel tempus risus malesuada. Fusce venenatis, orci eget blandit mollis, diam nisl interdum nulla, a convallis purus augue ut odio. Cras urna sapien, faucibus tincidunt placerat non, laoreet nec nunc. Praesent felis nibh, laoreet et sapien in, tincidunt eleifend tellus. Morbi ante urna, mollis quis eros sed, pulvinar venenatis lacus. Quisque interdum urna molestie porta auctor. Aliquam erat volutpat. Integer in aliquam sem. Quisque varius purus eu eros elementum varius. ",
        },
      ];
    },
    getArtists() {
      this.artists = [
        { img: "BandPhoto", name: "Anathema" },
        {
          img: "BandPhoto",
          name: "Anathema",
        },
        {
          img: "BandPhoto",
          name: "Anathema",
        },
        { img: "BandPhoto", name: "Anathema" },
      ];
    },
    getGenres() {
      this.genres = [
        { img: "BandPhoto", name: "Rock/Metal" },
        {
          img: "BandPhoto",
          name: "Klasyczna",
        },
        {
          img: "BandPhoto",
          name: "Jazz",
        },
        { img: "BandPhoto", name: "Pop" },
      ];
    },
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.account[field].$dirty) return errors;
      !this.$v.account[field].required && errors.push("Pole jest wymagane.");
      if (
        this.$v.account[field].maxLength != undefined &&
        this.$v.account[field].minLength != undefined
      ) {
        !this.$v.account[field].maxLength &&
          errors.push(
            `Pole nie może być dłuższe niż ${this.$v.account[field].$params.maxLength.max} znaków.`
          );
        !this.$v.account[field].minLength &&
          errors.push(
            `Pole musi mieć przynajmniej ${this.$v.account[field].$params.minLength.min} znaków.`
          );
      }
      return errors;
    },
  },
  setup() {
    const { getAccountById } = useAccounts();

    const getAccount = function () {
      getAccountById(localStorage.getItem("user-id")).then((response) => {
        this.account = response;
      });
    };

    return {
      getAccount,
    };
  },
};
</script>

<style scoped>
p > span {
  color: #ebebf2;
  padding-bottom: 1px;
  font-weight: bold;
}
.profile-header {
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
}
.profile-title {
  display: flex;
  align-items: center;
}
.favorites {
  padding: 7%;
}
.editDialog {
  background: #1e1e1e;
}
</style>
