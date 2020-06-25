using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Ссылка на константу в формуле
    /// </summary>
    public class ConstReference {

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа константной ссылки
        /// </summary>
        public int? ConstantReferenceTypeId { get; set; }

        /// <summary>
        /// Строковое значение
        /// </summary>
        public string ValueString { get; set; }

        /// <summary>
        /// Целочисленное значение
        /// </summary>
        public int? ValueInt { get; set; }

        /// <summary>
        /// Значение с плавающей точкой
        /// </summary>
        public double? ValueDouble { get; set; }

        /// <summary>
        /// Булевое значение
        /// </summary>
        public bool? ValueBoolean { get; set; }

        /// <summary>
        /// Ссылка на базовую сущьность
        /// </summary>
        public virtual Reference Reference { get; set; }

        /// <summary>
        /// Тип константной ссылки
        /// </summary>
        public virtual TypeDigest ConstantReferenceType { get; set; }
    }
}
