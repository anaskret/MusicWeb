<template>
  <div fluid>
    <Header
      :parent="album"
      :show_observe_button="show_observe_button"
      :vote_title="vote_title"
    />

    <InfoSection :parent="album" :module_name="module_name" />
    <ItemList :songs="songs" />
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemList from "@/components/ItemList.vue";
import InfoSection from "@/components/InfoSection.vue";
// import useAlbums from "@/modules/albums";

export default {
  name: "AlbumPage",
  components: {
    Header,
    ItemList,
    InfoSection,
  },
  data() {
    return {
      id: this.$route.params.id,
      artist: {},
      album: {
        name: "Weather Systems",
        artistName: "Anathema",
        establishmentDate: "2021-10-12T17:41:14.306",
        duration: 55,
        bio: 'Anathema (gr. klatwa) to angielska grupa muzyczna. Powstala 1990 roku w Liverpoolu. Poczatkowo wykonujaca drugofalowy death metal/doom metal, bedac wraz z grupami Katatonia, Tiamat, Winter, My Dying Bride i Paradise Lost prekursorem gatunku. Obecnie grupa zaliczana jest do nurtu art rocka oraz rocka atmosferycznego. Anathema zostala stworzona w 1990 roku pod nazwa Pagan Angel. W listopadzie tego roku zespól nagral pierwsze demo "An Iliad of Woes". Zmiana nazwy nastapila na poczatku 1991 roku. Pierwsze demo przyciagnelo uwage zespolów z brytyjskiej sceny metalowej i pozwolilo Anathemie zagrac koncerty u boku takich kapel jak Bolt Thrower czy Paradise Lost.',
      },
      songs: {},
      reviews: {},
      show_observe_button: false,
      module_name: "Album",
      vote_title: "Oceń album:",
    };
  },
  created() {
    this.getSongs();
    this.getArtist();
  },
  methods: {
    getSongs() {
      this.songs = [
        {
          img: "weather",
          title: "Untochable, pt I",
          album: "Weather Systems",
          rating: "5.0",
        },
        {
          img: "weather",
          title: "Untouchable, pt II",
          album: "Weather Systems",
          rating: 4.9,
        },
        {
          img: "weather",
          title: "The Gathering Of The Cloud",
          album: "Weather Systems",
          rating: 4.9,
        },
      ];
    },
  },
  //   setup() {
  // const { getById } = useAlbums();

  // const getAlbums = function () {
  //     getAll().then((response) => {
  //         this.albums = response;
  //     });
  // };

  // return {
  // getAlbums,
  // };
  //   },
  //   setup() {
  // const { getById } = useAlbums();

  // const getAlbum = function () {
  //   getById(this.id).then((response) => {
  //     this.album = response;
  //   });
  // };

  // return {
  //   getAlbum
  // };
  //   },
};
</script>
