using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.DAL.Repositories.Abstract;
using HealthSched.Models.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.Repositories.Concrete
{
    public class TitleRepository : Repository<Title> , ITitleRepository
    {
        public TitleRepository(SqlServerDbContext context) : base(context)
        {
            
        }
    }
}
