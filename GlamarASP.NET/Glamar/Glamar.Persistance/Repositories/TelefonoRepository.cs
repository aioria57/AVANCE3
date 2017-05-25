using Glamar.Entities;
using Glamar.Entities.IRepositories;
using Glamar.Persistance;
using Glamar.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistence.Repositoriess
{
    public class TelefonoRepository : Repository<Telefono>, ITelefonoRepository
    {
        private readonly GlamarDbContext _Context;

        public TelefonoRepository(GlamarDbContext context)
        {
            _Context = context;
        }
        public TelefonoRepository() : base()
        {

        }
      
    }
}
