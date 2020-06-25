using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Ссылки на типы
    /// </summary>
    public class TypeReference {

        /// <summary>
        /// Идентификатор ссылки на типы.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа на который указывает ссылка.
        /// </summary>
        public int TypeReferenceTypeId { get; set; }

        /// <summary>
        /// Базовая ссылка.
        /// </summary>
        public virtual Reference Reference { get; set; }

        /// <summary>
        /// Тип на который указывает ссылка
        /// </summary>
        public virtual TypeDigest TypeReferenceType { get; set; }
    }
}
