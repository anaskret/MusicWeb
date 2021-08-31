using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Repositories.Interfaces.Origins;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Origins
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
