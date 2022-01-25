<template>
<v-row justify="center">
  <v-col lg="10" class="mb-10">
    <div v-if="type=='song'" class="d-flex flex-row mb-5">
      <h1>Your songs</h1>
      <v-btn class="mt-2 ml-10" outlined @click="redirectToItem()">Add new song</v-btn>
    </div>
    <div v-if="type=='album'" class="d-flex flex-row mb-5">
      <h1>Your albums</h1>
      <v-btn class="mt-2 ml-10" outlined @click="redirectToItem()">Add new album</v-btn>
    </div>
     <v-simple-table>
      <thead>
      <tr>
        <th v-for="(column, index) in columns_list" :key="index">{{column}}</th>
      </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in items" :key="index">
          <td><div>
          <v-img :src="require('@/assets/BandPhoto.svg')" style = "width: 50px;"/>
        </div></td>
          <td>{{ item.name }}</td>
          <td>{{ item.releaseDate }}</td>
          <td v-if="type == 'album'">{{ item.duration }}</td>
          <td v-else-if="type == 'song'">{{ item.length }}</td>
          <td v-if="type == 'album'" @click="redirectToItem(item.id)">Edit</td>
        </tr>
        </tbody>
          </v-simple-table>
          </v-col>
          </v-row>
</template>

<script>

export default ({
  name: "ItemsTable",
    props: {
    items: Array,
    columns_list: Array,
    module_name: String,
    type: String,
  },
  methods: {
    redirectToItem(itemId) {
      debugger;
      this.$router.push({ name: "ManageArtistPage", params: { type: this.type, id: itemId } });
    },
    redirectToList(item_id) {
      debugger;
      this.$router.push({ name: "ManageArtistPage", params: { id: item_id } });
    },
  }
});
</script>
