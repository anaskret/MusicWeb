<template>
      <v-row justify="center"> 
      <v-col md="10">
  <v-card>
  <v-form @submit.prevent="onSubmit" v-if="type =='song'">
    <v-container>
      <v-row justify="center">
        <v-col md="10">
        <h1 class="pb-5" >{{title}}</h1>
          <v-text-field
            :counter="100"
            label="Song name"
            v-model.trim="item.name"
            :error-messages="nameErrors"
            @input="$v.item.name.$touch()"
            @blur="$v.item.name.$touch()"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-menu
          :close-on-content-click="false"
          :nudge-right="40"
          transition="scale-transition"
          offset-y
          min-width="auto"
          outlined
        >
          <template v-slot:activator="{ on, attrs }">
            <v-text-field
              label="Release date"
              prepend-icon="mdi-calendar"
              v-model.trim="item.releaseDate"
              :error-messages="releaseDateErrors"
              @input="$v.item.releaseDate.$touch()"
              @blur="$v.item.releaseDate.$touch()"
              readonly
              required
              v-bind="attrs"
              v-on="on"
            ></v-text-field>
          </template>
          <v-date-picker
            color="#647da1"
            v-model.trim="item.releaseDate"
          ></v-date-picker>
        </v-menu>
        </v-col> 
        <v-col md="10">
          <v-text-field           
            :counter="50"
            label="Song length"
            :error-messages="lengthErrors"
            @input="$v.item.length.$touch()"
            @blur="$v.item.length.$touch()"
            v-model.trim="item.length"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-select
          :items="dataArray"
          item-text="name"
          item-value="id"
          v-model.trim="item.albumId"
          label="Album"
        ></v-select>
        </v-col>
        <v-col md="10">
          <v-text-field
            :counter="10"
            label="Position on album"
            :error-messages="positionOnAlbumErrors"
            @input="$v.item.positionOnAlbum.$touch()"
            @blur="$v.item.positionOnAlbum.$touch()"
            v-model.trim="item.positionOnAlbum"
            required
          ></v-text-field>
        </v-col>
        <v-col md="10">
          <v-textarea
            :counter="1000"
            label="Lyrics"
            required
            v-model.trim="item.text"
            :error-messages="textErrors"
            @input="$v.item.text.$touch()"
            @blur="$v.item.text.$touch()"
          ></v-textarea>
        </v-col>
        <v-col md="10">
          <v-btn type="submit" @click.prevent="submitForm">Submit</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
  <v-form @submit.prevent="onSubmit" v-else>
    <v-container>
      <v-row justify="center">
        <v-col md="10">
        <h1 class="pb-5" >{{title}}</h1>
          <v-text-field
            
            :counter="100"
            label="Album name"
            v-model.trim="item.name"
            :error-messages="nameErrors"
            @input="$v.item.name.$touch()"
            @blur="$v.item.name.$touch()"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-menu
          :close-on-content-click="false"
          :nudge-right="40"
          transition="scale-transition"
          offset-y
          min-width="auto"
          outlined
        >
          <template v-slot:activator="{ on, attrs }">
            <v-text-field
              label="Release date"
              prepend-icon="mdi-calendar"
              v-model.trim="item.releaseDate"
              readonly
              required
              v-bind="attrs"
              v-on="on"
              :error-messages="releaseDateErrors"
            @input="$v.item.releaseDate.$touch()"
            @blur="$v.item.releaseDate.$touch()"
            ></v-text-field>
          </template>
          <v-date-picker
            color="#647da1"
            v-model.trim="item.releaseDate"
          ></v-date-picker>
        </v-menu>
        </v-col> 
        <v-col md="10">
           <v-select
          :items="dataArray"
          item-text="name"
          item-value="id"
          v-model.trim="item.albumGenreId"
          :error-messages="genreErrors"
            @input="$v.item.albumGenreId.$touch()"
            @blur="$v.item.albumGenreId.$touch()"
          label="Album genre"
        ></v-select>
        </v-col> 
        <v-col md="10">
          <v-text-field
            
            :counter="10"
            label="Album duration"
            v-model.trim="item.duration"
            :error-messages="durationErrors"
            @input="$v.item.duration.$touch()"
            @blur="$v.item.duration.$touch()"
            required
          ></v-text-field>
        </v-col>
        <v-col md="10">
          <v-textarea
            
            :counter="5000"
            label="Description"
            v-model.trim="item.description"
            :error-messages="descriptionErrors"
            @input="$v.item.description.$touch()"
            @blur="$v.item.description.$touch()"
            required
          ></v-textarea>
        </v-col>
        <v-col md="10">
          <v-btn type="submit" @click.prevent="submitForm">Submit</v-btn>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
  </v-card>
      </v-col>
    </v-row>
</template>

<script>
import {
  required,
  minLength,
  maxLength,
  minValue, 
  maxValue,
  decimal,
  and,
  numeric,
} from "vuelidate/lib/validators";

export default {
  name: "CreateItem",
  props: {
    item: Object,
    dataArray: Array,
    submitForm: Function,
    type: String,
    title: String,
  },
  data() {
    return {
      is_logging: false,
      message: "",
      error: {},
    };
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    nameErrors() {
      return this.prepareErrorArray("name");
    },
    releaseDateErrors() {
      return this.prepareErrorArray("releaseDate");
    },
    genreErrors() {
      return this.prepareErrorArray("albumGenreId");
    },
    durationErrors() {
      return this.prepareErrorArray("duration");
    },
    descriptionErrors() {
      return this.prepareErrorArray("description");
    },
    lengthErrors() {
      return this.prepareErrorArray("length");
    },
    positionOnAlbumErrors() {
      return this.prepareErrorArray("positionOnAlbum");
    },
    textErrors() {
      return this.prepareErrorArray("text");
    },
  },
  validations: {
    item: {
      name: {
        required,
        minLength: minLength(3),
        maxLength: maxLength(100),
      },
      albumGenreId: {
        required,
        minValue: minValue(0),
        maxValue: maxValue(1000),
      },
      description: {
        required,
        minLength: minLength(5),
        maxLength: maxLength(1000),
      },
      text: {
        required,
        minLength: minLength(5),
        maxLength: maxLength(1000),
      },
      duration: {
        required,
        decimalPositive: and(decimal, minValue(0.1)),
        minValue: minValue(1),
        maxValue: maxValue(500),
      },
      length: {
        required,
        decimalPositive: and(decimal, minValue(0.1), maxValue(100)),
        minValue: minValue(0.1),
        maxValue: maxValue(100),
      },
      positionOnAlbum: {
        required,
        numeric,
        numericPosition: and(numeric, minValue(1), maxValue(100)),
        minValue: minValue(1),
        maxValue: maxValue(100),
      },
      releaseDate: {
        required,
        date: (value) => value < new Date().toISOString(),
      },

    },
  },
  methods: {

    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.item[field].$dirty) return errors;
      !this.$v.item[field].required && errors.push("Field is required.");
      if (
        this.$v.item[field].maxLength != undefined &&
        this.$v.item[field].minLength != undefined
      ) {
        !this.$v.item[field].maxLength &&
          errors.push(
            `Field cannot be longer than ${this.$v.item[field].$params.maxLength.max} characters.`
          );
        !this.$v.item[field].minLength &&
          errors.push(
            `Field must contain at least ${this.$v.item[field].$params.minLength.min} characters.`
          );
      }

      if (this.$v.item[field].date != undefined) {
        !this.$v.item[field].date &&
          errors.push(`Release date cannot be in the future.`);
      }
      if (this.$v.item[field].decimalPositive != undefined) {
        !this.$v.item[field].decimalPositive &&
          errors.push(`Field must be decimal value from range 0 and 100`);
      }
      if (this.$v.item[field].numericPosition != undefined) {
        !this.$v.item[field].numericPosition &&
          errors.push(`Field must be numeric from range 0.1 and 100.`);
      }
      return errors;
    },
  },
  
};
</script>


