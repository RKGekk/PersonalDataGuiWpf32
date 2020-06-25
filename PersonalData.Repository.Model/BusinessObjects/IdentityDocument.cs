using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Любой документ с номером
    /// </summary>
    public class IdentityDocument {

        /// <summary>
        /// ID документа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID типа документа
        /// </summary>
        public int DocumentTypeId { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Документ действиделен до
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public virtual TypeDigest DocumentType { get; set; }

        /// <summary>
        /// Все связи с субъектами привязанные к данному документу
        /// </summary>
        public virtual ICollection<DocumentSubject> DocumentSubjects { get; set; }
    }
}
