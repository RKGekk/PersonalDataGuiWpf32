using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Dictionary {

    /// <summary>
    /// Связь между типами
    /// </summary>
    public class TypeDigestRelation {

        /// <summary>
        /// ID связи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID первого типа
        /// </summary>
        public int Type1Id { get; set; }

        /// <summary>
        /// ID второго типа
        /// </summary>
        public int Type2Id { get; set; }

        /// <summary>
        /// Базовый тип для связи
        /// </summary>
        public virtual TypeDigest BaseTypeDigest { get; set; }

        /// <summary>
        /// Базовый тип для связи
        /// </summary>
        public virtual TypeDigest TypeDigest1 { get; set; }

        /// <summary>
        /// Базовый тип для связи
        /// </summary>
        public virtual TypeDigest TypeDigest2 { get; set; }

        /// <summary>
        /// Список типов связей между субъектом и документом
        /// </summary>
        public virtual ICollection<DocumentSubject> DocumentSubject_RelationTypes { get; set; }

        /// <summary>
        /// Список типов связей между ролями
        /// </summary>
        public virtual ICollection<RoleRelation> RoleRelation_RelationTypes { get; set; }
    }
}
