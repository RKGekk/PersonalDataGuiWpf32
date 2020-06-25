using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Связь документа и субъекта
    /// </summary>
    public class DocumentSubject {

        /// <summary>
        /// ID связи документа и субъекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа связи
        /// </summary>
        public int RelationTypeId { get; set; }

        /// <summary>
        /// ID документа
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// ID субъекта
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// ID дата начала действия связи
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// ID дата окончания действия связи
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Тип связзи
        /// </summary>
        public virtual TypeDigestRelation RelationType { get; set; }

        /// <summary>
        /// Документ
        /// </summary>
        public virtual IdentityDocument Document { get; set; }

        /// <summary>
        /// Субъект
        /// </summary>
        public virtual Subject Subject { get; set; }
    }
}
