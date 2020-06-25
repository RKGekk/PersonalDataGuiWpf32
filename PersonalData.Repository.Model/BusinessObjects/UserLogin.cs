using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Пароль и логин для субъектов
    /// </summary>
    public class UserLogin {

        /// <summary>
        /// ID логина и пароля
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID субъект для логина и пароля
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Дата с которой начинает действовать логин и пароль
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата до которой действовует логин и пароль
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Хэш логина
        /// </summary>
        public string LoginHash { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Хэш паролья
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Субьект у которого установлен данный пароль
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}
