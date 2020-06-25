using ModelAssistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Repository.Model.Dictionary {

    public interface ITypeRepository {

        /// <summary>
        /// Получить корневую категорию.
        /// </summary>
        /// <returns>Тип.</returns>
        Option<TypeDigest> GetRootCategoryTypeDigest();

        /// <summary>
        /// Получить один тип по id.
        /// </summary>
        /// <param name="idType">Идентификатор типа.</param>
        /// <returns>Тип.</returns>
        Option<TypeDigest> GetTypeDigest(int idType);

        /// <summary>
        /// Получить один тип по коду.
        /// </summary>
        /// <param name="code">Код типа.</param>
        /// <returns>Тип.</returns>
        Option<TypeDigest> GetTypeDigest(string code);

        /// <summary>
        /// Получить типы по id категории.
        /// </summary>
        /// <param name="idType">Идентификатор типа.</param>
        /// <returns>Перечисление типов.</returns>
        List<TypeDigest> GetTypeDigestsByCategory(int idType);

        /// <summary>
        /// Получить типы по коду категории.
        /// </summary>
        /// <param name="code">Код типа.</param>
        /// <returns>Перечисление типов.</returns>
        List<TypeDigest> GetTypeDigestsByCategory(string code);

        /// <summary>
        /// Получить типы по id родительского типа.
        /// </summary>
        /// <param name="idType">Идентификатор типа.</param>
        /// <returns>Перечисление типов.</returns>
        List<TypeDigest> GetTypeDigestsByParent(int idType);

        /// <summary>
        /// Получить типы по коду родительского типа.
        /// </summary>
        /// <param name="code">Код типа.</param>
        /// <returns>Перечисление типов.</returns>
        List<TypeDigest> GetTypeDigestsByParent(string code);

        /// <summary>
        /// Получить описание связанной таблицы с типом по id описания таблицы.
        /// </summary>
        /// <param name="idTypeTable">Id описания связанной таблицы.</param>
        /// <returns>Описание связанной таблицы.</returns>
        Option<TypeTable> GetTypeTable(int idTypeTable);

        /// <summary>
        /// Вставить тип в БД
        /// </summary>
        /// <param name="type">Тип для вставки</param>
        void InsertTypeDigest(TypeDigest type);

        /// <summary>
        /// Удалить тип в БД
        /// </summary>
        /// <param name="type">Тип для удаления</param>
        void DeleteTypeDigest(TypeDigest type);
    }
}
