using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class NamingConventionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumReviews_Albums_AlbumId",
                table: "AlbumReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumReviews_AspNetUsers_UserId",
                table: "AlbumReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genres_AlbumGenreId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistComments_Artists_ArtistId",
                table: "ArtistComments");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistComments_AspNetUsers_UserId",
                table: "ArtistComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Cities_CityId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_States_StateId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsOnTheAlbums_Albums_AlbumId",
                table: "ArtistsOnTheAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsOnTheAlbums_Artists_ArtistId",
                table: "ArtistsOnTheAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_BandMembers_Artists_ArtistId",
                table: "BandMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_BandMembers_Artists_BandId",
                table: "BandMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_FriendId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_UserId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGuestArtist_Artists_ArtistId",
                table: "SongGuestArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGuestArtist_Songs_SongId",
                table: "SongGuestArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongReviews_AspNetUsers_UserId",
                table: "SongReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_SongReviews_Songs_SongId",
                table: "SongReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ComposerId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteAlbums_Albums_AlbumId",
                table: "UserFavoriteAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteAlbums_AspNetUsers_UserId",
                table: "UserFavoriteAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtists_Artists_ArtistId",
                table: "UserFavoriteArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtists_AspNetUsers_UserId",
                table: "UserFavoriteArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteSongs_AspNetUsers_UserId",
                table: "UserFavoriteSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteSongs_Songs_SongId",
                table: "UserFavoriteSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserObservedArtists_Artists_ArtistId",
                table: "UserObservedArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserObservedArtists_AspNetUsers_UserId",
                table: "UserObservedArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserObservedArtists",
                table: "UserObservedArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteSongs",
                table: "UserFavoriteSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteArtists",
                table: "UserFavoriteArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteAlbums",
                table: "UserFavoriteAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongReviews",
                table: "SongReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BandMembers",
                table: "BandMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistsOnTheAlbums",
                table: "ArtistsOnTheAlbums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistComments",
                table: "ArtistComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumReviews",
                table: "AlbumReviews");

            migrationBuilder.RenameTable(
                name: "UserObservedArtists",
                newName: "UserObservedArtist");

            migrationBuilder.RenameTable(
                name: "UserFriends",
                newName: "UserFriend");

            migrationBuilder.RenameTable(
                name: "UserFavoriteSongs",
                newName: "UserFavoriteSong");

            migrationBuilder.RenameTable(
                name: "UserFavoriteArtists",
                newName: "UserFavoriteArtist");

            migrationBuilder.RenameTable(
                name: "UserFavoriteAlbums",
                newName: "UserFavoriteAlbum");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "State");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.RenameTable(
                name: "SongReviews",
                newName: "SongReview");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "Chat");

            migrationBuilder.RenameTable(
                name: "BandMembers",
                newName: "BandMember");

            migrationBuilder.RenameTable(
                name: "ArtistsOnTheAlbums",
                newName: "ArtistsOnTheAlbum");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameTable(
                name: "ArtistComments",
                newName: "ArtistComment");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameTable(
                name: "AlbumReviews",
                newName: "AlbumReview");

            migrationBuilder.RenameIndex(
                name: "IX_UserObservedArtists_UserId",
                table: "UserObservedArtist",
                newName: "IX_UserObservedArtist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserObservedArtists_ArtistId",
                table: "UserObservedArtist",
                newName: "IX_UserObservedArtist_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriend",
                newName: "IX_UserFriend_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_FriendId",
                table: "UserFriend",
                newName: "IX_UserFriend_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteSongs_UserId",
                table: "UserFavoriteSong",
                newName: "IX_UserFavoriteSong_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteSongs_SongId",
                table: "UserFavoriteSong",
                newName: "IX_UserFavoriteSong_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtists_UserId",
                table: "UserFavoriteArtist",
                newName: "IX_UserFavoriteArtist_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtists_ArtistId",
                table: "UserFavoriteArtist",
                newName: "IX_UserFavoriteArtist_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteAlbums_UserId",
                table: "UserFavoriteAlbum",
                newName: "IX_UserFavoriteAlbum_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteAlbums_AlbumId",
                table: "UserFavoriteAlbum",
                newName: "IX_UserFavoriteAlbum_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "State",
                newName: "IX_State_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_ComposerId",
                table: "Song",
                newName: "IX_Song_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_Songs_AlbumId",
                table: "Song",
                newName: "IX_Song_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_SongReviews_UserId",
                table: "SongReview",
                newName: "IX_SongReview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SongReviews_SongId",
                table: "SongReview",
                newName: "IX_SongReview_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatId",
                table: "Message",
                newName: "IX_Message_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                table: "City",
                newName: "IX_City_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_UserId",
                table: "Chat",
                newName: "IX_Chat_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_FriendId",
                table: "Chat",
                newName: "IX_Chat_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_BandMembers_BandId",
                table: "BandMember",
                newName: "IX_BandMember_BandId");

            migrationBuilder.RenameIndex(
                name: "IX_BandMembers_ArtistId",
                table: "BandMember",
                newName: "IX_BandMember_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistsOnTheAlbums_ArtistId",
                table: "ArtistsOnTheAlbum",
                newName: "IX_ArtistsOnTheAlbum_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistsOnTheAlbums_AlbumId",
                table: "ArtistsOnTheAlbum",
                newName: "IX_ArtistsOnTheAlbum_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_StateId",
                table: "Artist",
                newName: "IX_Artist_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_CountryId",
                table: "Artist",
                newName: "IX_Artist_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_CityId",
                table: "Artist",
                newName: "IX_Artist_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistComments_UserId",
                table: "ArtistComment",
                newName: "IX_ArtistComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistComments_ArtistId",
                table: "ArtistComment",
                newName: "IX_ArtistComment_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistId",
                table: "Album",
                newName: "IX_Album_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_AlbumGenreId",
                table: "Album",
                newName: "IX_Album_AlbumGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumReviews_UserId",
                table: "AlbumReview",
                newName: "IX_AlbumReview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumReviews_AlbumId",
                table: "AlbumReview",
                newName: "IX_AlbumReview_AlbumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserObservedArtist",
                table: "UserObservedArtist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriend",
                table: "UserFriend",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteSong",
                table: "UserFavoriteSong",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteArtist",
                table: "UserFavoriteArtist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteAlbum",
                table: "UserFavoriteAlbum",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongReview",
                table: "SongReview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BandMember",
                table: "BandMember",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistsOnTheAlbum",
                table: "ArtistsOnTheAlbum",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistComment",
                table: "ArtistComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumReview",
                table: "AlbumReview",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Genre_AlbumGenreId",
                table: "Album",
                column: "AlbumGenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumReview_Album_AlbumId",
                table: "AlbumReview",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumReview_AspNetUsers_UserId",
                table: "AlbumReview",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_City_CityId",
                table: "Artist",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Country_CountryId",
                table: "Artist",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_State_StateId",
                table: "Artist",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistComment_Artist_ArtistId",
                table: "ArtistComment",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistComment_AspNetUsers_UserId",
                table: "ArtistComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsOnTheAlbum_Album_AlbumId",
                table: "ArtistsOnTheAlbum",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsOnTheAlbum_Artist_ArtistId",
                table: "ArtistsOnTheAlbum",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandMember_Artist_ArtistId",
                table: "BandMember",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandMember_Artist_BandId",
                table: "BandMember",
                column: "BandId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_FriendId",
                table: "Chat",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                table: "Chat",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Song_Artist_ComposerId",
                table: "Song",
                column: "ComposerId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGuestArtist_Artist_ArtistId",
                table: "SongGuestArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGuestArtist_Song_SongId",
                table: "SongGuestArtist",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongReview_AspNetUsers_UserId",
                table: "SongReview",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongReview_Song_SongId",
                table: "SongReview",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteAlbum_Album_AlbumId",
                table: "UserFavoriteAlbum",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteAlbum_AspNetUsers_UserId",
                table: "UserFavoriteAlbum",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtist_Artist_ArtistId",
                table: "UserFavoriteArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtist_AspNetUsers_UserId",
                table: "UserFavoriteArtist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteSong_AspNetUsers_UserId",
                table: "UserFavoriteSong",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteSong_Song_SongId",
                table: "UserFavoriteSong",
                column: "SongId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_AspNetUsers_FriendId",
                table: "UserFriend",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_AspNetUsers_UserId",
                table: "UserFriend",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserObservedArtist_Artist_ArtistId",
                table: "UserObservedArtist",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserObservedArtist_AspNetUsers_UserId",
                table: "UserObservedArtist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Artist_ArtistId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Album_Genre_AlbumGenreId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumReview_Album_AlbumId",
                table: "AlbumReview");

            migrationBuilder.DropForeignKey(
                name: "FK_AlbumReview_AspNetUsers_UserId",
                table: "AlbumReview");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_City_CityId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Country_CountryId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Artist_State_StateId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistComment_Artist_ArtistId",
                table: "ArtistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistComment_AspNetUsers_UserId",
                table: "ArtistComment");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsOnTheAlbum_Album_AlbumId",
                table: "ArtistsOnTheAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistsOnTheAlbum_Artist_ArtistId",
                table: "ArtistsOnTheAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_BandMember_Artist_ArtistId",
                table: "BandMember");

            migrationBuilder.DropForeignKey(
                name: "FK_BandMember_Artist_BandId",
                table: "BandMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_FriendId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AspNetUsers_UserId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Chat_ChatId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Album_AlbumId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_Song_Artist_ComposerId",
                table: "Song");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGuestArtist_Artist_ArtistId",
                table: "SongGuestArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGuestArtist_Song_SongId",
                table: "SongGuestArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_SongReview_AspNetUsers_UserId",
                table: "SongReview");

            migrationBuilder.DropForeignKey(
                name: "FK_SongReview_Song_SongId",
                table: "SongReview");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteAlbum_Album_AlbumId",
                table: "UserFavoriteAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteAlbum_AspNetUsers_UserId",
                table: "UserFavoriteAlbum");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtist_Artist_ArtistId",
                table: "UserFavoriteArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteArtist_AspNetUsers_UserId",
                table: "UserFavoriteArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteSong_AspNetUsers_UserId",
                table: "UserFavoriteSong");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteSong_Song_SongId",
                table: "UserFavoriteSong");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_AspNetUsers_FriendId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_AspNetUsers_UserId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserObservedArtist_Artist_ArtistId",
                table: "UserObservedArtist");

            migrationBuilder.DropForeignKey(
                name: "FK_UserObservedArtist_AspNetUsers_UserId",
                table: "UserObservedArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserObservedArtist",
                table: "UserObservedArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriend",
                table: "UserFriend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteSong",
                table: "UserFavoriteSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteArtist",
                table: "UserFavoriteArtist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteAlbum",
                table: "UserFavoriteAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongReview",
                table: "SongReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BandMember",
                table: "BandMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistsOnTheAlbum",
                table: "ArtistsOnTheAlbum");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistComment",
                table: "ArtistComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlbumReview",
                table: "AlbumReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "UserObservedArtist",
                newName: "UserObservedArtists");

            migrationBuilder.RenameTable(
                name: "UserFriend",
                newName: "UserFriends");

            migrationBuilder.RenameTable(
                name: "UserFavoriteSong",
                newName: "UserFavoriteSongs");

            migrationBuilder.RenameTable(
                name: "UserFavoriteArtist",
                newName: "UserFavoriteArtists");

            migrationBuilder.RenameTable(
                name: "UserFavoriteAlbum",
                newName: "UserFavoriteAlbums");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "States");

            migrationBuilder.RenameTable(
                name: "SongReview",
                newName: "SongReviews");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "Chats");

            migrationBuilder.RenameTable(
                name: "BandMember",
                newName: "BandMembers");

            migrationBuilder.RenameTable(
                name: "ArtistsOnTheAlbum",
                newName: "ArtistsOnTheAlbums");

            migrationBuilder.RenameTable(
                name: "ArtistComment",
                newName: "ArtistComments");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameTable(
                name: "AlbumReview",
                newName: "AlbumReviews");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_UserObservedArtist_UserId",
                table: "UserObservedArtists",
                newName: "IX_UserObservedArtists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserObservedArtist_ArtistId",
                table: "UserObservedArtists",
                newName: "IX_UserObservedArtists_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriend_UserId",
                table: "UserFriends",
                newName: "IX_UserFriends_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriends",
                newName: "IX_UserFriends_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteSong_UserId",
                table: "UserFavoriteSongs",
                newName: "IX_UserFavoriteSongs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteSong_SongId",
                table: "UserFavoriteSongs",
                newName: "IX_UserFavoriteSongs_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtist_UserId",
                table: "UserFavoriteArtists",
                newName: "IX_UserFavoriteArtists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteArtist_ArtistId",
                table: "UserFavoriteArtists",
                newName: "IX_UserFavoriteArtists_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteAlbum_UserId",
                table: "UserFavoriteAlbums",
                newName: "IX_UserFavoriteAlbums_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavoriteAlbum_AlbumId",
                table: "UserFavoriteAlbums",
                newName: "IX_UserFavoriteAlbums_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_State_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_SongReview_UserId",
                table: "SongReviews",
                newName: "IX_SongReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SongReview_SongId",
                table: "SongReviews",
                newName: "IX_SongReviews_SongId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_ComposerId",
                table: "Songs",
                newName: "IX_Songs_ComposerId");

            migrationBuilder.RenameIndex(
                name: "IX_Song_AlbumId",
                table: "Songs",
                newName: "IX_Songs_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatId",
                table: "Messages",
                newName: "IX_Messages_ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_City_StateId",
                table: "Cities",
                newName: "IX_Cities_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_UserId",
                table: "Chats",
                newName: "IX_Chats_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_FriendId",
                table: "Chats",
                newName: "IX_Chats_FriendId");

            migrationBuilder.RenameIndex(
                name: "IX_BandMember_BandId",
                table: "BandMembers",
                newName: "IX_BandMembers_BandId");

            migrationBuilder.RenameIndex(
                name: "IX_BandMember_ArtistId",
                table: "BandMembers",
                newName: "IX_BandMembers_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistsOnTheAlbum_ArtistId",
                table: "ArtistsOnTheAlbums",
                newName: "IX_ArtistsOnTheAlbums_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistsOnTheAlbum_AlbumId",
                table: "ArtistsOnTheAlbums",
                newName: "IX_ArtistsOnTheAlbums_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistComment_UserId",
                table: "ArtistComments",
                newName: "IX_ArtistComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistComment_ArtistId",
                table: "ArtistComments",
                newName: "IX_ArtistComments_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_StateId",
                table: "Artists",
                newName: "IX_Artists_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_CountryId",
                table: "Artists",
                newName: "IX_Artists_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Artist_CityId",
                table: "Artists",
                newName: "IX_Artists_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumReview_UserId",
                table: "AlbumReviews",
                newName: "IX_AlbumReviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AlbumReview_AlbumId",
                table: "AlbumReviews",
                newName: "IX_AlbumReviews_AlbumId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_ArtistId",
                table: "Albums",
                newName: "IX_Albums_ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_AlbumGenreId",
                table: "Albums",
                newName: "IX_Albums_AlbumGenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserObservedArtists",
                table: "UserObservedArtists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteSongs",
                table: "UserFavoriteSongs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteArtists",
                table: "UserFavoriteArtists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteAlbums",
                table: "UserFavoriteAlbums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongReviews",
                table: "SongReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BandMembers",
                table: "BandMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistsOnTheAlbums",
                table: "ArtistsOnTheAlbums",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistComments",
                table: "ArtistComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlbumReviews",
                table: "AlbumReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumReviews_Albums_AlbumId",
                table: "AlbumReviews",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumReviews_AspNetUsers_UserId",
                table: "AlbumReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genres_AlbumGenreId",
                table: "Albums",
                column: "AlbumGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistComments_Artists_ArtistId",
                table: "ArtistComments",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistComments_AspNetUsers_UserId",
                table: "ArtistComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Cities_CityId",
                table: "Artists",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_States_StateId",
                table: "Artists",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsOnTheAlbums_Albums_AlbumId",
                table: "ArtistsOnTheAlbums",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistsOnTheAlbums_Artists_ArtistId",
                table: "ArtistsOnTheAlbums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandMembers_Artists_ArtistId",
                table: "BandMembers",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandMembers_Artists_BandId",
                table: "BandMembers",
                column: "BandId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_FriendId",
                table: "Chats",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_UserId",
                table: "Chats",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGuestArtist_Artists_ArtistId",
                table: "SongGuestArtist",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGuestArtist_Songs_SongId",
                table: "SongGuestArtist",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongReviews_AspNetUsers_UserId",
                table: "SongReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongReviews_Songs_SongId",
                table: "SongReviews",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ComposerId",
                table: "Songs",
                column: "ComposerId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteAlbums_Albums_AlbumId",
                table: "UserFavoriteAlbums",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteAlbums_AspNetUsers_UserId",
                table: "UserFavoriteAlbums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtists_Artists_ArtistId",
                table: "UserFavoriteArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteArtists_AspNetUsers_UserId",
                table: "UserFavoriteArtists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteSongs_AspNetUsers_UserId",
                table: "UserFavoriteSongs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteSongs_Songs_SongId",
                table: "UserFavoriteSongs",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_FriendId",
                table: "UserFriends",
                column: "FriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_AspNetUsers_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserObservedArtists_Artists_ArtistId",
                table: "UserObservedArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserObservedArtists_AspNetUsers_UserId",
                table: "UserObservedArtists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
