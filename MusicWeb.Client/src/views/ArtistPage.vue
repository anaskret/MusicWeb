<template>
    <div>
        <Header />
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
            artists: [],
            albums: [],
            songs: [],
            comments: [],
        };
    },
    created() {
        this.getArtist();
        this.getSongs();
        this.getComments();
        this.getArtists();
    },
    methods: {
        getArtists() {
            const { getAll } = useArtists();
            getAll().then((response) => {
                this.artists = response.data;
                console.log(response.data);
            });
        },

        getArtist() {
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
    },
};
</script>
