using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Связь ролей
    /// </summary>
    public class RoleRelation {

        /// <summary>
        /// ID связи ролей
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID тип связи ролей
        /// </summary>
        public int RelationTypeId { get; set; }

        /// <summary>
        /// ID роли от которой идет связь
        /// </summary>
        public int FromRoleId { get; set; }

        /// <summary>
        /// ID роли к которой идет связь
        /// </summary>
        public int ToRoleId { get; set; }

        /// <summary>
        /// Дата начала действия связи роли
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия связи роли
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Связанная роль 1
        /// </summary>
        public virtual SubjectRole FromSubjectRole { get; set; }

        /// <summary>
        /// Связанная роль 2
        /// </summary>
        public virtual SubjectRole ToSubjectRole { get; set; }

        /// <summary>
        /// Тип связи
        /// </summary>
        public virtual TypeDigestRelation RelationType { get; set; }
    }
}
