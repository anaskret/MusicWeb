﻿using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Posts
{
    public class Post : BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string PosterId { get; set; }
        public int? ArtistPosterId{ get; set; }
        public int? AlbumId { get; set; }

        public virtual UserFriend Poster { get; set; }
        public virtual UserObservedArtist PosterArtist { get; set; }
    }
}