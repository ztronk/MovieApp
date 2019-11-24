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
        private readonly DbSet<T> set;

        public EntityRepository()
            : base("Movie")
        {
            set = base.Set<T>();
        }

        /// <summary>
        /// Создание записи в базе данных
        /// </summary>
        /// <param name="acc"></param>
        public void Create(T acc)
        {
            set.Add(acc);
            base.SaveChanges();
        }

        /// <summary>
        /// Обновление записи в базе данных
        /// </summary>
        /// <param name="acc"></param>
        public void Update(T acc)
        {
            base.Entry(acc).State = EntityState.Modified;
            base.SaveChanges();
        }

        /// <summary>
        /// Получние списка записей в базе данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Get()
        {
            foreach (var acc in set)
                yield return acc;
        }

        /// <summary>
        /// Получение записи в базе данных по ее идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(Guid id)
        {
            return set.Find(id);
        }
    }
}