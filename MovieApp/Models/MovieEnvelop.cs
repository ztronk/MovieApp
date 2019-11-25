using System;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name = "Наименование")]
        [MaxLength(255, ErrorMessage = "Введенное значение наименования превышает длину {0} символов")]
        public string Title { get; set; }
        /// <summary>Описание фильма</summary>
        [Display(Name = "Описание")]
        [MaxLength(255, ErrorMessage = "Введенное значение описания превышает длину {0} символов")]
        public string Description { get; set; }
        /// <summary>Год выпуска</summary>
        [Required]
        [Display(Name = "Год создания")]
        [Range(1900, 2020, ErrorMessage = "Год должен быть задан в промежутке от 1900 до 2020")]
        [RegularExpression(@"[0-9][0-9][0-9][0-9]$", ErrorMessage = "Год создания должен быть задан в формате числа XXXX")]
        public int Year { get; set; }
        /// <summary>Режисер</summary>
        [Required]
        [Display(Name = "Режисер")]
        [MaxLength(255, ErrorMessage = "Введенные данные режисера превышают длину {0} символов")]
        public string Director { get; set; }
        /// <summary>Постер - наименование файла</summary>
        [Display(Name = "Постер")]
        public string Poster { get; set; }
        /// <summary>Постер - файла</summary>
        [Display(Name = "Постер")]
        public HttpPostedFileBase Picture { get; set; }

        public MovieEnvelop()
        {
            Id = Guid.NewGuid();
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