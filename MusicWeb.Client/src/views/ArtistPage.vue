<template>
    <div>
        <Header :artist="artist" :address="address" />
        <item-carousel :albums="albums" />
        <item-list :songs="songs" />
        <comments-list :comments="comments" />
    </div>
</template>

<script>
import Header from "@/components/Header.vue";
import ItemCarousel from "@/components/ItemCarousel.vue";
import ItemList from "@/components/ItemList.vue";
import CommentsList from "../components/CommentsList.vue";
import useArtists from "@/modules/artists";
import useOrigins from "@/modules/origins";
import useAlbums from "@/modules/albums";

export default {
    name: "ArtistPage",
    components: {
        Header,
        ItemCarousel,
        ItemList,
        CommentsList,
    },
    data() {
        return {
            id: this.$route.params.id,
            artist: {},
            address: {},
            albums: [],
            songs: [],
            comments: [],
        };
    },
    created() {
        this.getArtist();
        this.getSongs();
        this.getComments();
        this.getAlbums();
    },
    methods: {
        getAlbums() {
            this.albums = [
                { img: "weather", title: "Weather Systems", year: "2012" },
                {
                    img: "werehere",
                    title: "We're Here Because We're Here",
                    year: "2010",
                },
                {
                    img: "naturaldisaster",
                    title: "A Natural Disaster",
                    year: "2003",
                },
                { img: "judgement", title: "Judgement", year: "1999" },
                { img: "judgement", title: "Eternity", year: "1996" },
            ];
        },
        getSongs() {
            this.songs = [
                {
                    img: "weather",
                    title: "Untochable, pt I",
                    album: "Weather Systems",
                    rating: "5.0",
                },
                {
                    img: "naturaldisaster",
                    title: "Flying",
                    album: "A Natural Disaster",
                    rating: "5.0",
                },
                {
                    img: "judgement",
                    title: "Pitiless",
                    album: "Judgement",
                    rating: "5.0",
                },
            ];
        },
        getComments() {
            this.comments = [
                {
                    img: "",
                    userName: "AnathemaLover",
                    date: "11:12 23.04.2020",
                    text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
                },
                {
                    img: "",
                    userName: "AnathemaLover",
                    date: "11:12 23.04.2020",
                    text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
                },
                {
                    img: "",
                    userName: "AnathemaLover",
                    date: "11:12 23.04.2020",
                    text: "Jakiś tam przykładowy komentarz użytkownika, który kocha Anathemę, bo przecież każdy człowiek na świecie powinien kochać Anathemę. Anathema plz come back.",
                },
            ];
        },

        getAddress(artist) {
            const { getCountryById, getStateById, getCityById } = useOrigins();
            getCountryById(artist.countryId).then((response) => {
                this.address.country = response;
            });
            getStateById(artist.stateId).then((response) => {
                this.address.state = response;
            });
            getCityById(artist.cityId).then((response) => {
                this.address.city = response;
            });
        },
    },

    setup() {
        const { getById } = useArtists();
        const { getAll } = useAlbums();

        const getArtist = function () {
            getById(this.id).then((response) => {
                this.artist = response;
                this.getAddress(response);
            });
        };

        const getAlbums = function () {
            getAll().then((response) => {
                this.albums = response;
            });
        };

        return {
            getArtist,
            getAlbums,
        };
    },
};
</script>
