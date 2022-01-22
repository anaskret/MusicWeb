using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Responses.ApiIntegration
{
    public class SongResponseRoot
    {
        public SongResponse[] track { get; set; }
    }

    public class SongResponse
    {
        public string idTrack { get; set; }
        public string idAlbum { get; set; }
        public string idArtist { get; set; }
        public string idLyric { get; set; }
        public object idIMVDB { get; set; }
        public string strTrack { get; set; }
        public string strAlbum { get; set; }
        public string strArtist { get; set; }
        public object strArtistAlternate { get; set; }
        public object intCD { get; set; }
        public string intDuration { get; set; }
        public string strGenre { get; set; }
        public object strMood { get; set; }
        public object strStyle { get; set; }
        public object strTheme { get; set; }
        public object strDescriptionEN { get; set; }
        public object strDescriptionDE { get; set; }
        public object strDescriptionFR { get; set; }
        public object strDescriptionCN { get; set; }
        public object strDescriptionIT { get; set; }
        public object strDescriptionJP { get; set; }
        public object strDescriptionRU { get; set; }
        public object strDescriptionES { get; set; }
        public object strDescriptionPT { get; set; }
        public object strDescriptionSE { get; set; }
        public object strDescriptionNL { get; set; }
        public object strDescriptionHU { get; set; }
        public object strDescriptionNO { get; set; }
        public object strDescriptionIL { get; set; }
        public object strDescriptionPL { get; set; }
        public object strTrackThumb { get; set; }
        public object strTrack3DCase { get; set; }
        public object strTrackLyrics { get; set; }
        public object strMusicVid { get; set; }
        public object strMusicVidDirector { get; set; }
        public object strMusicVidCompany { get; set; }
        public object strMusicVidScreen1 { get; set; }
        public object strMusicVidScreen2 { get; set; }
        public object strMusicVidScreen3 { get; set; }
        public object intMusicVidViews { get; set; }
        public object intMusicVidLikes { get; set; }
        public object intMusicVidDislikes { get; set; }
        public object intMusicVidFavorites { get; set; }
        public object intMusicVidComments { get; set; }
        public string intTrackNumber { get; set; }
        public string intLoved { get; set; }
        public string intScore { get; set; }
        public string intScoreVotes { get; set; }
        public string intTotalListeners { get; set; }
        public string intTotalPlays { get; set; }
        public string strMusicBrainzID { get; set; }
        public string strMusicBrainzAlbumID { get; set; }
        public string strMusicBrainzArtistID { get; set; }
        public string strLocked { get; set; }
    }
}
