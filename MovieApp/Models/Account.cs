using System;
using System.Data.Entity;

namespace MovieApp.Models
{
    /// <summary>Учетная запись пользователя</summary>
    public class Account
    {
        /// <summary>Идентификаторо пользователя</summary>
        public string Id { get; set; }
        /// <summary>Адрес электронной почты</summary>
        public string Email { get; set; }
        /// <summary>Фамилия имя отчество</summary>
        public string FullName { get; set; }
    }
}