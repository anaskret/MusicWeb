<template>
      <v-row justify="center"> 
      <v-col md="10">
  <v-card>
  <v-form @submit.prevent="onSubmit" v-if="item_type =='song'">
    <v-container>
      <v-row justify="center">
        <v-col md="10">
        <h1 class="pb-5" >Create item</h1>
          <v-text-field
            :rules="nameRules"
            :counter="100"
            label="Song name"
            v-model.trim="item.name"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="50"
            label="Release Date"
            v-model.trim="item.releaseDate"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="50"
            label="Song length"
            v-model.trim="item.length"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="10"
            label="Album"
            v-model.trim="item.albumId"
            required
          ></v-text-field>
        </v-col>
        <v-col md="10">
          <v-textarea
            :rules="nameRules"
            :counter="5000"
            label="Position on album"
            v-model.trim="item.positionOnAlbum"
            required
          ></v-textarea>
        </v-col>
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="10"
            label="200"
            required
            v-model.trim="item.text"
          ></v-text-field>
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
        <h1 class="pb-5" >Create item</h1>
          <v-text-field
            :rules="nameRules"
            :counter="100"
            label="Album name"
            v-model.trim="item.name"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="50"
            label="Release Date"
            v-model.trim="item.releaseDate"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="50"
            label="Album genre"
            v-model.trim="item.albumGenreId"
            required
          ></v-text-field>
        </v-col> 
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="10"
            label="Album duration"
            v-model.trim="item.duration"
            required
          ></v-text-field>
        </v-col>
        <v-col md="10">
          <v-textarea
            :rules="nameRules"
            :counter="5000"
            label="Description"
            v-model.trim="item.description"
            required
          ></v-textarea>
        </v-col>
        <v-col md="10">
          <v-text-field
            :rules="nameRules"
            :counter="10"
            label="200"
            required
          ></v-text-field>
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

export default ({
  name: "CreateItem",
    props: {
    item: Object,
    genres: Array,
    nameRules: Array,
    submitForm: Function,
    item_type: String,
  },
    
});
</script>
