using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Enums
{
    public enum ArtistType
    {
        [Description("Individual")]
        Individual,
        [Description("Band Member")]
        BandMember,
        [Description("Band")]
        Bamd
    }
}
