using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Dictionary {

    /// <summary>
    /// Категория для справочника
    /// </summary>
    public class TypeCategory {

        /// <summary>
        /// ID категории
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID таблицы для категории
        /// </summary>
        public int? TypeTableId { get; set; }

        /// <summary>
        /// Базовый тип для категории
        /// </summary>
        public virtual TypeDigest TypeDigest { get; set; }

        /// <summary>
        /// Таблица категории
        /// </summary>
        public virtual TypeTable TypeTable { get; set; }

        /// <summary>
        /// Список типов, которые ссылаются на этоту категорию(находятся в этой категории)
        /// </summary>
        public virtual ICollection<TypeDigest> TypeDigests { get; set; }
    }
}
