using MovieApp.Ioc;
using System.Data.Entity;

namespace MovieApp.Models
{
    public class MovieContext : EntityRepository<Movie>
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }

        /// <summary>
        /// Обновление данных о фильме
        /// </summary>
        /// <param name="acc"></param>
        public void Update(Movie movie, int? userId)
        {
            if (!userId.HasValue || movie.UserId.Equals(userId.Value))
            {
                base.Entry(movie).State = EntityState.Modified;
                base.SaveChanges();
            }
        }
    }
}