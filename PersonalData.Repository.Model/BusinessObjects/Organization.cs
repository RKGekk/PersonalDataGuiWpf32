using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Организация объектов которые могут управлять системой
    /// </summary>
    public class Organization {

        /// <summary>
        /// ID организации
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID тип организации
        /// </summary>
        public int OrganizationTypeId { get; set; }

        /// <summary>
        /// Базовый субъект
        /// </summary>
        public virtual Subject BaseSubject { get; set; }

        /// <summary>
        /// Тип Организации
        /// </summary>
        public virtual TypeDigest OrganizationType { get; set; }
    }
}
