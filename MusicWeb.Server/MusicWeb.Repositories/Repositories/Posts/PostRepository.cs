using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Repositories.Interfaces.Posts;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Posts
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
