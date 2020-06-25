using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Пол человека
    /// </summary>
    public class Gender {

        /// <summary>
        /// ID пола
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа для хранения пола
        /// </summary>
        public int GenderTypeId { get; set; }

        /// <summary>
        /// ID человека для которого сохранен пол
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Дата начала действия характеристики пол
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия характеристики пол
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Человек у которого установлен пол
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Тип для хранения пола человека
        /// </summary>
        public virtual TypeDigest GenderType { get; set; }
    }
}
