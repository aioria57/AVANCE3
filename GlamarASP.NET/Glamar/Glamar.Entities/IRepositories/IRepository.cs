﻿using System;

using System.Collections.Generic;

using System.Linq;

using System.Linq.Expressions;

using System.Text;

using System.Threading.Tasks;

namespace Glamar.Entities.IRepositories

{

    public interface IRepository<TEntity> where TEntity : class

    {

        //CREATES

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        //READS

        TEntity Get(int? id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //UPDATES

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        //DELETES

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

    }

}