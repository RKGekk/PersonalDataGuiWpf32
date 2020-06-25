using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Связь роли и веб контента для управления
    /// </summary>
    public class WebContentRole {

        /// <summary>
        /// ID связи роли и веб контента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID веб ресурса(файл, контроллер-действие и тд)
        /// </summary>
        public int WebContentId { get; set; }

        /// <summary>
        /// Контент для данной роли
        /// </summary>
        public virtual WebContent WebContent { get; set; }

        /// <summary>
        /// Базовая сущьность роли
        /// </summary>
        public virtual SubjectRole BaseSubjectRole { get; set; }
    }
}
