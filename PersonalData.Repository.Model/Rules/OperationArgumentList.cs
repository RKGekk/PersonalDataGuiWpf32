using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Аргументы для оператора(аргумент операции).
    /// </summary>
    public class OperationArgumentList {

        /// <summary>
        /// Идентификатор списка аргументов оператора.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер по счету аргумента для оператора(номер последовательности).
        /// </summary>
        public int ArgumentSequence { get; set; }

        /// <summary>
        /// Имя аргумента
        /// </summary>
        public string ArgumentName { get; set; }

        /// <summary>
        /// Идентификатор аргумента для оператора(базового узла).
        /// </summary>
        public int ExpressionArgumentId { get; set; }

        /// <summary>
        /// Идентификатор оператора(операции).
        /// </summary>
        public int ExpressionOperationId { get; set; }

        /// <summary>
        /// Базовый узел.
        /// </summary>
        public virtual ExpressionNode ExpressionArgument { get; set; }

        /// <summary>
        /// Операция, в которой учавствует данный аргумент.
        /// </summary>
        public virtual OperationNode ExpressionOperation { get; set; }
    }
}
