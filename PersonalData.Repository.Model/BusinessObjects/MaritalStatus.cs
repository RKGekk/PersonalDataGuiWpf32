using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Семейный статус
    /// </summary>
    public class MaritalStatus {

        /// <summary>
        /// ID семейного положения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа для хранения семейного положения
        /// </summary>
        public int MaritalTypeId { get; set; }

        /// <summary>
        /// ID человека для которого сохранено семейное положение
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Дата начала действия характеристики семейное положение
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия характеристики семейное положение
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Человек у которого установлено семейное положение
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Вид семейного положения
        /// </summary>
        public virtual TypeDigest MaritalStatusType { get; set; }
    }
}
