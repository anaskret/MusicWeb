using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Tests
{
    public class InMemoryDatabase : IDisposable
    {
        private bool disposed = false;
        protected readonly DbContextOptions<AppDbContext> DbOptions;

        public InMemoryDatabase()
        {
            DbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("SampleDb" + Guid.NewGuid().ToString())
                .Options;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                using (var sampleDbContext = new AppDbContext(DbOptions))
                {
                    sampleDbContext.Database.EnsureDeleted();
                }
            }
            disposed = true;
        }

        ~InMemoryDatabase()
        {
            Dispose(false);
        }
    }
}
