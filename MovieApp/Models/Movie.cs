using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    /// <summary>Фильм</summary>
    public class Movie
    {
        /// <summary>Идентификатор фильма</summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>Дата создания записи о фильме</summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>Идентификатор пользователя, создавшего запись о фильме</summary>
        public string UserId { get; set; }
        /// <summary>Наименование фильма</summary>
        [Display(Name = "Наименование")]
        public string Title { get; set; }
        /// <summary>Описание фильма</summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }
        /// <summary>Год выпуска</summary>
        [Display(Name = "Год создания")]
        public int Year { get; set; }
        /// <summary>Режисер</summary>
        [Display(Name = "Режисер")]
        public string Director { get; set; }
        /// <summary>Постер - наименование файла</summary>
        [Display(Name = "Постер")]
        public string Poster { get; set; }

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