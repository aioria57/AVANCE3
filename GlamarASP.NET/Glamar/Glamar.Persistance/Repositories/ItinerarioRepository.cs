using Glamar.Entities;
using Glamar.Entities.IRepositories;
using Glamar.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistence.Repositories
{
    public class ItinerarioRepository : Repository<Itinerario>, IItinerarioRepository
    {
        private readonly GlamarDbContext _Context;

        public ItinerarioRepository(GlamarDbContext context)
        {
            _Context = context;
        }
        public ItinerarioRepository() : base()
        {

        }
       
    }
}
