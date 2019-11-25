using System;
using System.Collections.Generic;
using System.Web;

namespace MovieApp.Models
{
    /// <summary>Фильм</summary>
    public class Movie
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

        public Movie()
        {
            Id = Guid.NewGuid();
        }

        public MovieEnvelop Translate() =>
            new MovieEnvelop()
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