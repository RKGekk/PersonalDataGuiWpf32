using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.BusinessObjects {

    /// <summary>
    /// Любое наименование(фамилия, имя, отчество, название команды, имя огранизации и тд)
    /// </summary>
    public class SubjectName {

        /// <summary>
        /// ID имени
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID типа имени человека(фамилия, имя, отчество и тд)
        /// </summary>
        public int NameTypeId { get; set; }

        /// <summary>
        /// В какой последовательности выводить имя
        /// </summary>
        public int OrderInSequence { get; set; }

        /// <summary>
        /// ID типа имени человека(фамилия, имя, отчество, название команды, имя огранизации и тд)
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата начала действия наименования
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Дата окончания действия наименования
        /// </summary>
        public DateTime Thru { get; set; }

        /// <summary>
        /// Имя данного субъекта
        /// </summary>
        public virtual Subject Subject { get; set; }

        /// <summary>
        /// Тип имени
        /// </summary>
        public virtual TypeDigest NameType { get; set; }
    }
}
