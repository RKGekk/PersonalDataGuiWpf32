using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Операнды выражения (Тип узла - ссылка)
    /// </summary>
    public class Reference {

        /// <summary>
        /// Идентификатор ссылки.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа ссылки.
        /// </summary>
        public int ReferenceTypeId { get; set; }

        /// <summary>
        /// Базовый узел.
        /// </summary>
        public virtual ExpressionNode ExpressionNode { get; set; }

        /// <summary>
        /// Тип ссылки.
        /// </summary>
        public virtual TypeDigest ReferenceType { get; set; }

        /// <summary>
        /// Наследник на ссылку типа.
        /// </summary>
        public virtual TypeReference TypeReference { get; set; }

        /// <summary>
        /// Наследник на константную ссылку.
        /// </summary>
        public virtual ConstReference ConstReference { get; set; }
    }
}
