using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Роль на субъекте
    /// </summary>
    public class SubjectRole {

        /// <summary>
        /// ID роли субъекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа роли
        /// </summary>
        public int RoleTypeId { get; set; }

        /// <summary>
        /// ID субъекта
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Дата начала действия роли
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия роли
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Роль для веб контента
        /// </summary>
        public virtual WebContentRole WebContentRole { get; set; }

        /// <summary>
        /// Субъект для данной роли
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Все связи с ролями с лева
        /// </summary>
        public virtual ICollection<RoleRelation> SubjectRolesFrom { get; set; }

        /// <summary>
        /// Все связи с ролями с права
        /// </summary>
        public virtual ICollection<RoleRelation> SubjectRolesTo { get; set; }
    }
}
