using ModelAssistant;
using static ModelAssistant.Extensions;
using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;
using static ModelAssistant.F;

namespace PersonalData.Repository {

    public class TypeRepository : ITypeRepository {

        private static readonly ObjectCache<TypeDigest> TypeCache = new ObjectCache<TypeDigest>();
        private static readonly ObjectCache<TypeTable> TypeTableCache = new ObjectCache<TypeTable>();
        private static readonly ObjectCache<List<TypeDigest>> CategoryTypesCache = new ObjectCache<List<TypeDigest>>();
        private static readonly ObjectCache<List<TypeDigest>> ParentTypesCache = new ObjectCache<List<TypeDigest>>();

        private static R Connect<R>(Func<PersonalDataContext, R> func)
            => Using(new PersonalDataContext(), func);

        public Option<TypeDigest> GetTypeDigest(int idType)
            => TypeCache.Get(
                idType.ToString(),
                () => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.Id == idType).FirstOrDefault())
            );


        public Option<TypeDigest> GetTypeDigest(string code)
            => TypeCache.Get(
                code,
                () => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.Code == code).FirstOrDefault())
            );

        public List<TypeDigest> GetTypeDigestsByCategory(int idType)
            => CategoryTypesCache.Get(
                idType.ToString(),
                () => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.TypeCategoryId == idType).ToList())
            );

        public List<TypeDigest> GetTypeDigestsByCategory(string code)
            => CategoryTypesCache.Get(
                code,
                () => {
                    return GetTypeDigest(code).Match(
                        None: () => new List<TypeDigest>(),
                        Some: categoryType => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.TypeCategoryId == categoryType.Id).ToList())
                    );
                }
            );

        public Option<TypeDigest> GetRootCategoryTypeDigest() {
            string rootCode = "TypeCategory";
            return TypeCache.Get(
                rootCode,
                () => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.Code == rootCode).FirstOrDefault())
            );
        }

        public List<TypeDigest> GetTypeDigestsByParent(int idType)
            => ParentTypesCache.Get(
                idType.ToString(),
                () => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.ParentId == idType).ToList())
            );

        public List<TypeDigest> GetTypeDigestsByParent(string code)
            => ParentTypesCache.Get(
                code,
                () => {
                    return GetTypeDigest(code).Match(
                        None: () => new List<TypeDigest>(),
                        Some: parentType => Connect(ctx => ctx.TypeDigests.Where(typeDigest => typeDigest.ParentId == parentType.Id).ToList())
                    );
                }
            );

        public void InsertTypeDigest(TypeDigest type) {

            ResetTypeCache(type);

            if (type.TypeCategoryId == GetRootCategoryTypeDigest().Match(() => -1, t => t.Id)) {

                Connect(
                    ctx => {

                        ctx.TypeDigests.Add(type);
                        ctx.SaveChanges();

                        TypeCategory newCategory = new TypeCategory() {
                            Id = type.Id,
                            TypeTableId = type.TypeTableId
                        };
                        ctx.TypeCategories.Add(newCategory);
                        ctx.SaveChanges();

                        return Unit();
                    }
                );
            }
            else {
                Connect(
                    ctx => {
                        ctx.TypeDigests.Add(type);
                        ctx.SaveChanges();
                        return Unit();
                    }
                );
            }
        }

        private void ResetTypeCache(TypeDigest type) {
            TypeCache.Reset(type.Code);
            TypeCache.Reset(type.Id.ToString());
            if (type.ParentId.HasValue) {
                ParentTypesCache.Reset(type.ParentId.ToString());
                GetTypeDigest(type.ParentId.Value).Match(
                    None: () => Unit(),
                    Some: t => {
                        ParentTypesCache.Reset(t.Code);
                        return Unit();
                    }
                );
            }

            CategoryTypesCache.Reset(type.TypeCategoryId.ToString());
            GetTypeDigest(type.TypeCategoryId.Value).Match(
                None: () => Unit(),
                Some: t => {
                    CategoryTypesCache.Reset(t.Code);
                    return Unit();
                }
            );
            
        }

        public void DeleteTypeDigest(TypeDigest type) {

            ResetTypeCache(type);
            if (type.TypeCategoryId == GetRootCategoryTypeDigest().Match(() => -1, t => t.Id)) {
                Connect(
                    ctx => {

                        ctx.TypeDigests
                            .Where(c => c.TypeCategoryId == type.Id)
                            .ToList()
                            .ForEach(c => ctx.Entry(c).State = System.Data.Entity.EntityState.Deleted);
                        ctx.SaveChanges();

                        TypeCategory currentCategory = ctx.TypeCategories.Where(c => c.Id == type.Id).FirstOrDefault();
                        ctx.TypeCategories.Attach(currentCategory);
                        ctx.TypeCategories.Remove(currentCategory);
                        ctx.SaveChanges();

                        ctx.TypeDigests.Attach(type);
                        ctx.TypeDigests.Remove(type);
                        ctx.SaveChanges();

                        return Unit();
                    }
                );
            }
            else {
                Connect(
                    ctx => {

                        ctx.TypeDigests.Attach(type);
                        ctx.TypeDigests.Remove(type);
                        ctx.SaveChanges();

                        return Unit();
                    }
                );
            }
        }

        public Option<TypeTable> GetTypeTable(int idTypeTable)
            => TypeTableCache.Get(
                idTypeTable.ToString(),
                () => Connect(ctx => ctx.TypeTables.Where(typeTable => typeTable.Id == idTypeTable).FirstOrDefault())
            );
    }
}
