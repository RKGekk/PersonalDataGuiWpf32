using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Dictionary {

    /// <summary>
    /// Связь типа с таблицей БД(в какой таблице находятся дополнительные колонки для типа).
    /// </summary>
    public class TypeTable {

        /// <summary>
        /// ID таблицы для типа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Таблица имя таблицы в БД.
        /// </summary>
        public string Table { get; set; }

        /// <summary>
        /// Бизнес наименование таблицы для типа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание таблицы.
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Имя столбца Primary Key в таблице.
        /// </summary>
        public string PK { get; set; }

        /// <summary>
        /// Идентификатор объекта таблицы в БД.
        /// </summary>
        public int? TableObjectId { get; set; }

        /// <summary>
        /// Типы в которых указана данная таблица
        /// </summary>
        public virtual ICollection<TypeDigest> TypeDigests { get; set; }

        /// <summary>
        /// Категории в которых указана данная таблица
        /// </summary>
        public virtual ICollection<TypeCategory> TypeCategories { get; set; }

        /// <summary>
        /// Возвращает строковое представление типа.
        /// </summary>
        /// <returns>Строка в формате {Id} : {Name}</returns>
        public override string ToString() {
            return $"{Id} : {Name}";
        }
    }
}
