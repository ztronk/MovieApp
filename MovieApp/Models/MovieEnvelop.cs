using System;
using System.Web;

namespace MovieApp.Models
{
    public class MovieEnvelop
    {
        /// <summary>Идентификатор фильма</summary>
        public Guid Id { get; set; }
        /// <summary>Дата создания записи о фильме</summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>Идентификатор пользователя, создавшего запись о фильме</summary>
        public string UserId { get; set; }
        /// <summary>Наименование фильма</summary>
        public string Title { get; set; }
        /// <summary>Описание фильма</summary>
        public string Description { get; set; }
        /// <summary>Год выпуска</summary>
        public int Year { get; set; }
        /// <summary>Режисер</summary>
        public string Director { get; set; }
        /// <summary>Постер - наименование файла</summary>
        public string Poster { get; set; }
        /// <summary>Постер - файла</summary>
        public HttpPostedFileBase Picture { get; set; }

        public MovieEnvelop()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Movie Translate() =>
            new Movie()
            {
                Id = this.Id,
                CreatedDate = this.CreatedDate,
                UserId = this.UserId,
                Title = this.Title,
                Description = this.Description,
                Year = this.Year,
                Director = this.Director,
                Poster = this.Poster
            };
    }
}