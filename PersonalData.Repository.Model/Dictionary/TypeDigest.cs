using PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Dictionary {

    /// <summary>
    /// Элемент справочника типов
    /// </summary>
    public class TypeDigest {

        /// <summary>
        /// ID элемента справочника типов.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID родительского элемента справочника.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// ID категории типа.
        /// </summary>
        public int? TypeCategoryId { get; set; }

        /// <summary>
        /// Код элемента справочника типов.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Бизнес-код элемента справочника типов.
        /// </summary>
        public string BCode { get; set; }

        /// <summary>
        /// Наименование элемента справочника типов.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID таблицы для типа
        /// </summary>
        public int? TypeTableId { get; set; }

        /// <summary>
        /// Примечание для типа
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Дата последнего редактирования.
        /// </summary>
        public DateTime Edit { get; set; }

        /// <summary>
        /// Дата начала действия элемента справочника типов.
        /// </summary>
        public DateTime Open { get; set; }

        /// <summary>
        /// Дата окончания действия элемента справочника типов.
        /// </summary>
        public DateTime Close { get; set; }

        /// <summary>
        /// Порядковый номер элемента справочника типов.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Если тип является категорией
        /// </summary>
        public virtual TypeCategory TypeCategoryBase { get; set; }

        /// <summary>
        /// Категория типа если тип является категорией
        /// </summary>
        public virtual TypeCategory Category { get; set; }

        /// <summary>
        /// Таблица связанная с типом
        /// </summary>
        public virtual TypeTable TypeTable { get; set; }

        /// <summary>
        /// Родительский тип
        /// </summary>
        public virtual TypeDigest ParentType { get; set; }

        /// <summary>
        /// Получить тип категория для данного типа
        /// </summary>
        public virtual TypeDigest TypeInCategory { get; set; }

        /// <summary>
        /// Дочерние типы
        /// </summary>
        public virtual ICollection<TypeDigest> ChildTypes { get; set; }

        /// <summary>
        /// Типы в категори
        /// </summary>
        public virtual ICollection<TypeDigest> TypesInCategory { get; set; }

        /// <summary>
        /// Связь типа
        /// </summary>
        public virtual TypeDigestRelation TypeRelationBase { get; set; }

        /// <summary>
        /// Все связи типа слева
        /// </summary>
        public virtual ICollection<TypeDigestRelation> TypeDigestRelation_TypeDigest1 { get; set; }

        /// <summary>
        /// Все связи типа справа
        /// </summary>
        public virtual ICollection<TypeDigestRelation> TypeDigestRelation_TypeDigest2 { get; set; }

        /// <summary>
        /// Список узлов для данного типа узла.
        /// </summary>
        public virtual ICollection<ExpressionNode> ExpressionNode_ExpressionNodeTypes { get; set; }

        /// <summary>
        /// Список ссылко для данного типа ссылки.
        /// </summary>
        public virtual ICollection<Reference> Reference_ReferenceTypes { get; set; }

        /// <summary>
        /// Список ссылкок на типы для данного типа ссылки.
        /// </summary>
        public virtual ICollection<TypeReference> TypeReference_TypeReferences { get; set; }

        /// <summary>
        /// Список указателей на константы для данного типа ссылок.
        /// </summary>
        public virtual ICollection<ConstReference> ConstReference_ConstantReferenceTypes { get; set; }

        /// <summary>
        /// Список операторов для данного типа оператора.
        /// </summary>
        public virtual ICollection<OperationNode> OperationNode_OperationNodeTypes { get; set; }

        /// <summary>
        /// Список документов данного типа.
        /// </summary>
        public virtual ICollection<IdentityDocument> IdentityDocument_DocumentTypes { get; set; }

        /// <summary>
        /// Список субъектов данного типа.
        /// </summary>
        public virtual ICollection<Subject> Subject_SubjectTypes { get; set; }

        /// <summary>
        /// Список имен типа.
        /// </summary>
        public virtual ICollection<SubjectName> SubjectName_SubjectNameTypes { get; set; }

        /// <summary>
        /// Список типов организаций.
        /// </summary>
        public virtual ICollection<Organization> Organization_OrganizationTypes { get; set; }

        /// <summary>
        /// Список семейных положений.
        /// </summary>
        public virtual ICollection<MaritalStatus> MaritalStatus_MaritalStatusTypes { get; set; }

        /// <summary>
        /// Список полов человека.
        /// </summary>
        public virtual ICollection<Gender> Gender_GenderTypes { get; set; }

        /// <summary>
        /// Список физических характеристик человека.
        /// </summary>
        public virtual ICollection<PhysicalCharacteristic> PhysicalCharacteristic_PhysicalCharacteristicTypes { get; set; }
    }
}
