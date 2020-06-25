using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Оператор(операция)
    /// </summary>
    public class OperationNode {

        /// <summary>
        /// Идентификатор операции.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа операции.
        /// </summary>
        public int OperationNodeTypeId { get; set; }

        /// <summary>
        /// Узел выражения.
        /// </summary>
        public virtual ExpressionNode ExpressionNode { get; set; }

        /// <summary>
        /// Тип операции.
        /// </summary>
        public virtual TypeDigest OperationNodeType { get; set; }

        /// <summary>
        /// Список аргументов для данной операции.
        /// </summary>
        public virtual ICollection<OperationArgumentList> OperationArgumentList { get; set; }
    }
}
