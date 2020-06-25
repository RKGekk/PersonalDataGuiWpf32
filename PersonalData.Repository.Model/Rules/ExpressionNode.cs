using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Rules {

    /// <summary>
    /// Узел выражения.
    /// </summary>
    /// <remarks>
    /// Every EXPRESSION NODE is differentiated by an expression value and
    /// expression value type name(see Figure 4.13). An expression value denotes
    /// the calculation type of the expression(Direct, Nested, Conditional, Other). The
    /// expression value type name indicates the return type of expression being
    /// used(for example, Boolean, integer, or string). A unary expression contains
    /// one operand and a unary(single element) operator. A binary expression contains
    /// two operands separated by one operator. A conditional expression is a
    /// compound expression that contains a condition.An assignment expression
    /// stores a constant value in the variable designated by the left operand.It uses
    /// an abstract syntax tree to store the structure of the expression.
    /// </remarks>
    public class ExpressionNode {

        /// <summary>
        /// Идентификатор узла выражения.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа узла.
        /// </summary>
        public int ExpressionNodeTypeId { get; set; }

        /// <summary>
        /// Тип узла.
        /// </summary>
        public virtual TypeDigest ExpressionNodeType { get; set; }

        /// <summary>
        /// Ссылка (наследник).
        /// </summary>
        public virtual Reference Reference { get; set; }

        /// <summary>
        /// Операция (наследник).
        /// </summary>
        public virtual OperationNode OperationNode { get; set; }

        /// <summary>
        /// Список аргументов.
        /// </summary>
        public virtual ICollection<OperationArgumentList> OperationArgumentList { get; set; }
    }
}
