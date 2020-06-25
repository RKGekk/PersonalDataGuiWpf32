using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Персональные данные по человеку
    /// </summary>
    public class Person {

        /// <summary>
        /// ID человека
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Идентификационный номер налогоплательщика
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// Комментарий по человеку
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Базовый субъект
        /// </summary>
        public virtual Subject BaseSubject { get; set; }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public virtual ICollection<MaritalStatus> MaritalStatuses { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public virtual ICollection<Gender> Genders { get; set; }

        /// <summary>
        /// Физические данные
        /// </summary>
        public virtual ICollection<PhysicalCharacteristic> PhysicalCharacteristics { get; set; }
    }
}
