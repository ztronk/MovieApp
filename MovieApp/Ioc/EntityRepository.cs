using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MovieApp.Ioc
{
    public interface IEntityRepository<T> where T : class
    {
        void Create(T context);
        void Update(T context);
        IEnumerable<T> Get();
        T Get(Guid id);
    }

    public class EntityRepository<T> : DbContext, IEntityRepository<T> where T : class
    {
        private readonly DbContext accContext;
        private readonly DbSet<T> accSet;

        public EntityRepository()
            : base("Movie")
        {
            accSet = base.Set<T>();
        }

        /// <summary>
        /// Создание записи в базе данных
        /// </summary>
        /// <param name="acc"></param>
        public void Create(T acc)
        {
            accSet.Add(acc);
            base.SaveChanges();
        }

        /// <summary>
        /// Обновление записи в базе данных
        /// </summary>
        /// <param name="acc"></param>
        public void Update(T acc)
        {
            accContext.Entry(acc).State = EntityState.Modified;
            accContext.SaveChanges();
        }

        /// <summary>
        /// Получние списка записей в базе данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            foreach (var acc in accSet)
                yield return acc;
        }

        /// <summary>
        /// Получение записи в базе данных по ее идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(Guid id)
        {
            return accSet.Find(id);
        }
    }
}