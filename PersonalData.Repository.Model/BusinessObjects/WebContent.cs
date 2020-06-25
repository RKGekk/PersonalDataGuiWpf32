using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Веб ресурс, для назначения статса и прав
    /// </summary>
    public class WebContent {

        /// <summary>
        /// ID веб ресурса
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа описания веб ресурса(файл, контроллер-действие и тд)
        /// </summary>
        public int WebContentTypeId { get; set; }

        /// <summary>
        /// ID статуса ресурса(активный, заблокированный и тд.)
        /// </summary>
        public int WebContentStatusId { get; set; }

        /// <summary>
        /// Файл над которым осуществляется контроль
        /// </summary>
        public string WebFile { get; set; }

        /// <summary>
        /// Роутер над которым осуществляется контроль
        /// </summary>
        public string WebRoute { get; set; }

        /// <summary>
        /// Контроллер над которым осуществляется контроль
        /// </summary>
        public string WebController { get; set; }

        /// <summary>
        /// Действие над которым осуществляется контроль
        /// </summary>
        public string WebAction { get; set; }

        /// <summary>
        /// Все связи с ролями на данный контент
        /// </summary>
        public virtual ICollection<WebContentRole> WebContentRoles { get; set; }
    }
}
