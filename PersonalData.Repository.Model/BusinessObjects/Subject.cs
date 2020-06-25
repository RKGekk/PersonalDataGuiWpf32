using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Субъект(агрегация для человека, организации людей или иного объекта уоторый может управлять процессами)
    /// </summary>
    public class Subject {

        /// <summary>
        /// ID субъекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа субъекта(человек, организация людей или иное)
        /// </summary>
        public int SubjectTypeId { get; set; }

        /// <summary>
        /// Все связи с документами привязанные к данному субъекту
        /// </summary>
        public virtual ICollection<DocumentSubject> DocumentSubjects { get; set; }

        /// <summary>
        /// Все пароли на данном субъекте
        /// </summary>
        public virtual ICollection<UserLogin> UserLogins { get; set; }

        /// <summary>
        /// Все роли на субъекте
        /// </summary>
        public virtual ICollection<SubjectRole> SubjectRoles { get; set; }

        /// <summary>
        /// Субъект-организация
        /// </summary>
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// Субъект-человек
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Все имена субъекта
        /// </summary>
        public virtual ICollection<SubjectName> SubjectNames { get; set; }

        /// <summary>
        /// Тип субъекта
        /// </summary>
        public virtual TypeDigest SubjectType { get; set; }
    }
}
