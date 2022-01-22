using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Responses.ApiIntegration
{
    public class ArtistResponseRoot
    {
        public ArtistResponse[] artists { get; set; }
    }

    public class ArtistResponse
    {
        public string idArtist { get; set; }
        public string strArtist { get; set; }
        public object strArtistStripped { get; set; }
        public string strArtistAlternate { get; set; }
        public string strLabel { get; set; }
        public string idLabel { get; set; }
        public string intFormedYear { get; set; }
        public string intBornYear { get; set; }
        public object intDiedYear { get; set; }
        public object strDisbanded { get; set; }
        public string strStyle { get; set; }
        public string strGenre { get; set; }
        public string strMood { get; set; }
        public string strWebsite { get; set; }
        public string strFacebook { get; set; }
        public string strTwitter { get; set; }
        public string strBiographyEN { get; set; }
        public object strBiographyDE { get; set; }
        public object strBiographyFR { get; set; }
        public object strBiographyCN { get; set; }
        public object strBiographyIT { get; set; }
        public object strBiographyJP { get; set; }
        public object strBiographyRU { get; set; }
        public object strBiographyES { get; set; }
        public string strBiographyPT { get; set; }
        public object strBiographySE { get; set; }
        public object strBiographyNL { get; set; }
        public object strBiographyHU { get; set; }
        public object strBiographyNO { get; set; }
        public object strBiographyIL { get; set; }
        public object strBiographyPL { get; set; }
        public string strGender { get; set; }
        public string intMembers { get; set; }
        public string strCountry { get; set; }
        public string strCountryCode { get; set; }
        public string strArtistThumb { get; set; }
        public string strArtistLogo { get; set; }
        public object strArtistCutout { get; set; }
        public string strArtistClearart { get; set; }
        public string strArtistWideThumb { get; set; }
        public string strArtistFanart { get; set; }
        public string strArtistFanart2 { get; set; }
        public string strArtistFanart3 { get; set; }
        public string strArtistFanart4 { get; set; }
        public string strArtistBanner { get; set; }
        public string strMusicBrainzID { get; set; }
        public object strISNIcode { get; set; }
        public string strLastFMChart { get; set; }
        public string intCharted { get; set; }
        public string strLocked { get; set; }
    }
}
