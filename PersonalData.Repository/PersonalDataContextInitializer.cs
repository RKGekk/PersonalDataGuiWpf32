using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository {

    public class PersonalDataContextInitializer
        //: DropCreateDatabaseAlways<PersonalDataContext> {
        //: DropCreateDatabaseIfModelChanges<PersonalDataContext> {
        //: MigrateDatabaseToLatestVersion<PersonalDataContext, Configuration> {
        : CreateDatabaseIfNotExists<PersonalDataContext> {

        protected DateTime _defaultOpen = new DateTime(1900, 1, 1);
        protected DateTime _defaultClose = new DateTime(2100, 1, 1);

        public TypeTable TypeTableRootCategory { get; set; }
        public TypeDigest TypeRootCategory { get; set; }
        public TypeCategory TypeCategoryRootCategory { get; set; }

        public TypeDigest TypeReferenceGroup { get; set; }
        public TypeCategory TypeCategoryReferenceGroup { get; set; }
        public TypeDigest TypeReferenceType { get; set; }
        public TypeDigest TypeReferenceConst { get; set; }

        public TypeDigest TypeConstReferenceCategory { get; set; }
        public TypeCategory TypeCategoryConstReference { get; set; }
        public TypeDigest TypeConstNullReference { get; set; }
        public TypeDigest TypeConstStringReference { get; set; }
        public TypeDigest TypeConstIntReference { get; set; }
        public TypeDigest TypeConstFloatReference { get; set; }
        public TypeDigest TypeConstBoolReference { get; set; }

        public TypeDigest TypeExpressionNodeCategory { get; set; }
        public TypeCategory TypeCategoryExpressionNode { get; set; }
        public TypeDigest TypeExpressionNodeReference { get; set; }
        public TypeDigest TypeExpressionNodeOperator { get; set; }

        public TypeDigest TypeOperationNodeCategory { get; set; }
        public TypeCategory TypeCategoryOperationNode { get; set; }

        public TypeDigest TypeOperationNodeUnaryCategory { get; set; }
        public TypeCategory TypeCategoryOperationNodeUnary { get; set; }

        public TypeDigest TypeOperationNodeBinaryCategory { get; set; }
        public TypeCategory TypeCategoryOperationNodeBinary { get; set; }

        public TypeDigest TypeOperationNodeTernaryCategory { get; set; }
        public TypeCategory TypeCategoryOperationNodeTernary { get; set; }

        public TypeDigest TypeExpressionNodeOperatorPlus { get; set; }
        public TypeDigest TypeExpressionNodeOperatorMinus { get; set; }
        public TypeDigest TypeExpressionNodeOperatorMultiply { get; set; }
        public TypeDigest TypeExpressionNodeOperatorDivide { get; set; }
        public TypeDigest TypeExpressionNodeOperatorAssign { get; set; }
        public TypeDigest TypeExpressionNodeOperatorIf { get; set; }
        public TypeDigest TypeExpressionNodeOperatorEqual { get; set; }

        protected override void Seed(PersonalDataContext context) {

            InitializeRootCatalog(context);

            InitializeTypeReferenceGroup(context);
            InitializeTypeConstReference(context);
            InitializeTypeExpressionNode(context);
            InitializeTypeOperationNode(context);
        }

        private void InitializeRootCatalog(PersonalDataContext ctx) {

            TypeTableRootCategory = new TypeTable() {
                Table = "drTypeCategory",
                Name = "TypeCategory",
                Note = "Категории",
                PK = "idTypeCategory",
                TableObjectId = null
            };
            ctx.TypeTables.Add(TypeTableRootCategory);
            ctx.SaveChanges();

            TypeRootCategory = new TypeDigest() {
                Code = "TypeCategory",
                BCode = "TypeCategory",
                Name = "Типы справочников (Категории)",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 0
            };
            ctx.TypeDigests.Add(TypeRootCategory);
            ctx.SaveChanges(); ;

            TypeCategoryRootCategory = new TypeCategory() {
                Id = TypeRootCategory.Id,
                TypeTable = TypeTableRootCategory
            };
            ctx.TypeCategories.Add(TypeCategoryRootCategory);
            ctx.SaveChanges();

            TypeRootCategory.Category = TypeCategoryRootCategory;

            ctx.SaveChanges();
        }

        private void InitializeTypeReferenceGroup(PersonalDataContext ctx) {

            TypeReferenceGroup = new TypeDigest() {
                ParentType = TypeRootCategory,
                Category = TypeCategoryRootCategory,

                Code = "ReferenceGroup",
                BCode = "ReferenceGroup",
                Name = "Категория хранения типов указателей на данные (указатели на типы, данные по действиям, константы или другие типы, наследуемые от указателей)",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeReferenceGroup);
            ctx.SaveChanges();

            TypeCategoryReferenceGroup = new TypeCategory() {
                Id = TypeReferenceGroup.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryReferenceGroup);
            ctx.SaveChanges();

            TypeReferenceType = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryReferenceGroup,
                Code = "TypeReference",
                BCode = "TypeReference",
                Name = "Указатель на типы из drType",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            TypeReferenceConst = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryReferenceGroup,
                Code = "ConstReference",
                BCode = "ConstReference",
                Name = "Указатель на константу",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 3
            };
            ctx.TypeDigests.AddRange(new[] { TypeReferenceType, TypeReferenceConst });
            ctx.SaveChanges();
        }

        private void InitializeTypeConstReference(PersonalDataContext ctx) {

            TypeConstReferenceCategory = new TypeDigest() {
                ParentType = TypeRootCategory,
                Category = TypeCategoryRootCategory,

                Code = "ConstReferenceCategory",
                BCode = "ConstReferenceCategory",
                Name = "Категория типов указателей на константы",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 3
            };
            ctx.TypeDigests.Add(TypeConstReferenceCategory);
            ctx.SaveChanges();

            TypeCategoryConstReference = new TypeCategory() {
                Id = TypeConstReferenceCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryConstReference);
            ctx.SaveChanges();

            TypeConstNullReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryConstReference,
                Code = "NullConstReference",
                BCode = "NullConstReference",
                Name = "Указатель на константу-null",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            TypeConstStringReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryConstReference,
                Code = "StringConstReference",
                BCode = "StringConstReference",
                Name = "Указатель на константу-строку",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 2
            };
            TypeConstIntReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryConstReference,
                Code = "IntConstReference",
                BCode = "IntConstReference",
                Name = "Указатель на константу-целое число",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 3
            };
            TypeConstFloatReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryConstReference,
                Code = "FloatConstReference",
                BCode = "FloatConstReference",
                Name = "Указатель на константу-число с плавающей точкой",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 4
            };
            TypeConstBoolReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryConstReference,
                Code = "BoolConstReference",
                BCode = "BoolConstReference",
                Name = "Указатель на константу-логическое значение",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 5
            };
            ctx.TypeDigests.AddRange(new[] { TypeConstNullReference, TypeConstStringReference, TypeConstIntReference, TypeConstFloatReference, TypeConstBoolReference });
            ctx.SaveChanges();
        }

        private void InitializeTypeExpressionNode(PersonalDataContext ctx) {

            TypeExpressionNodeCategory = new TypeDigest() {
                ParentType = TypeRootCategory,
                Category = TypeCategoryRootCategory,

                Code = "ExpressionNodeTypeCategory",
                BCode = "ExpressionNodeTypeCategory",
                Name = "Категория для типов узлов выражений",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeExpressionNodeCategory);
            ctx.SaveChanges();

            TypeCategoryExpressionNode = new TypeCategory() {
                Id = TypeExpressionNodeCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryExpressionNode);
            ctx.SaveChanges();

            TypeExpressionNodeReference = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryExpressionNode,
                Code = "ReferenceExpressionNode",
                BCode = "ReferenceExpressionNode",
                Name = "Узел хранит указатель на значение",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            TypeExpressionNodeOperator = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryExpressionNode,
                Code = "OperatorExpressionNode",
                BCode = "OperatorExpressionNode",
                Name = "Указатель на оператор",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 2
            };
            ctx.TypeDigests.AddRange(new[] { TypeExpressionNodeReference, TypeExpressionNodeOperator });
            ctx.SaveChanges();
        }

        private void InitializeTypeOperationNode(PersonalDataContext ctx) {

            TypeOperationNodeCategory = new TypeDigest() {
                ParentType = TypeRootCategory,
                Category = TypeCategoryRootCategory,

                Code = "OperationNodeTypeCategory",
                BCode = "OperationNodeTypeCategory",
                Name = "Категория для хранения видов операций",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeOperationNodeCategory);
            ctx.SaveChanges();

            TypeCategoryOperationNode = new TypeCategory() {
                Id = TypeOperationNodeCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryOperationNode);
            ctx.SaveChanges();


            TypeOperationNodeUnaryCategory = new TypeDigest() {
                ParentType = TypeOperationNodeCategory,
                Category = TypeCategoryRootCategory,

                Code = "OperationNodeUnaryTypeCategory",
                BCode = "OperationNodeUnaryTypeCategory",
                Name = "Категория для хранения унарных операций",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeOperationNodeUnaryCategory);
            ctx.SaveChanges();

            TypeCategoryOperationNodeUnary = new TypeCategory() {
                Id = TypeOperationNodeUnaryCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryOperationNodeUnary);
            ctx.SaveChanges();


            TypeOperationNodeBinaryCategory = new TypeDigest() {
                ParentType = TypeOperationNodeCategory,
                Category = TypeCategoryRootCategory,

                Code = "OperationNodeBinaryTypeCategory",
                BCode = "OperationNodeBinaryTypeCategory",
                Name = "Категория для хранения бинарных операций",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeOperationNodeBinaryCategory);
            ctx.SaveChanges();

            TypeCategoryOperationNodeBinary = new TypeCategory() {
                Id = TypeOperationNodeBinaryCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryOperationNodeBinary);
            ctx.SaveChanges();


            TypeOperationNodeTernaryCategory = new TypeDigest() {
                ParentType = TypeOperationNodeCategory,
                Category = TypeCategoryRootCategory,

                Code = "OperationNodeTernaryTypeCategory",
                BCode = "OperationNodeTernaryTypeCategory",
                Name = "Категория для хранения тернарных операций",
                TypeTable = TypeTableRootCategory,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            ctx.TypeDigests.Add(TypeOperationNodeTernaryCategory);
            ctx.SaveChanges();

            TypeCategoryOperationNodeTernary = new TypeCategory() {
                Id = TypeOperationNodeTernaryCategory.Id,
                TypeTable = null
            };
            ctx.TypeCategories.Add(TypeCategoryOperationNodeTernary);
            ctx.SaveChanges();


            TypeExpressionNodeOperatorPlus = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorPlusNode",
                BCode = "Plus",
                Name = "Оператор плюс",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 1
            };
            TypeExpressionNodeOperatorMinus = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorMinusNode",
                BCode = "Minus",
                Name = "Оператор минус",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 2
            };
            TypeExpressionNodeOperatorMultiply = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorMultiplyNode",
                BCode = "Multiply",
                Name = "Оператор умножить",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 3
            };
            TypeExpressionNodeOperatorDivide = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorDivideNode",
                BCode = "Divide",
                Name = "Оператор разделить",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 4
            };
            TypeExpressionNodeOperatorAssign = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorAssignNode",
                BCode = "Assign",
                Name = "Оператор присвоения",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 5
            };
            TypeExpressionNodeOperatorIf = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeTernary,
                Code = "OperatorIfNode",
                BCode = "If",
                Name = "Оператор если",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 6
            };
            TypeExpressionNodeOperatorEqual = new TypeDigest() {
                ParentType = null,
                Category = TypeCategoryOperationNodeBinary,
                Code = "OperatorEqualNode",
                BCode = "Equal",
                Name = "Оператор сравнения",
                TypeTable = null,
                Note = null,
                Edit = _defaultOpen,
                Open = _defaultOpen,
                Close = _defaultClose,
                Order = 7
            };
            ctx.TypeDigests.AddRange(new[] { TypeExpressionNodeOperatorPlus, TypeExpressionNodeOperatorMinus, TypeExpressionNodeOperatorMultiply, TypeExpressionNodeOperatorDivide, TypeExpressionNodeOperatorAssign, TypeExpressionNodeOperatorIf, TypeExpressionNodeOperatorEqual });
            ctx.SaveChanges();
        }
    }
}
