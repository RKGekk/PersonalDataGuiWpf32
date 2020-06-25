using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Биометрические данные человека(рост, вес, цвет глаз, отпечатки пальцев и тд.)
    /// </summary>
    public class PhysicalCharacteristic {

        /// <summary>
        /// ID физической характеристики
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID человека для которого сохранена физическая хорактеритика
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Значение физической характеристики
        /// </summary>
        public string PhysicalValue { get; set; }

        /// <summary>
        /// Тип значения физической характеристики
        /// </summary>
        public int PhysicalValueTypeId { get; set; }

        /// <summary>
        /// Дата начала действия характеристики
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия характеристики
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Человек у которого физическая величина
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Тип для хранения физической характеристики
        /// </summary>
        public virtual TypeDigest PhysicalCharacteristicType { get; set; }
    }
}
