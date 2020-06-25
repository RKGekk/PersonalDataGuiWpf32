using ModelAssistant;
using static ModelAssistant.Extensions;
using PersonalData.Repository.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit = System.ValueTuple;
using static ModelAssistant.F;

namespace PersonalData.Repository {
    public class PersonalDataRepository {

        private static R Connect<R>(Func<PersonalDataContext, R> func)
            => Using(new PersonalDataContext(), func);

        public List<Subject> GetAllSubjects()
            => Connect(ctx => ctx.Subjects.ToList());

        public List<Subject> GetAllSubjects(int subjectTypeId)
            => Connect(ctx => ctx.Subjects.Where(s => s.SubjectTypeId == subjectTypeId).ToList());

        public List<Subject> GetAllSubjects(string subjectTypeCode) {
            int typeId = Connect(ctx => ctx.TypeDigests.Where(s => s.Code == subjectTypeCode).FirstOrDefault().Id);
            return Connect(ctx => ctx.Subjects.Where(s => s.SubjectTypeId == typeId).ToList());
        }

        public List<Person> GetAllPersons() {
            int typeId = Connect(ctx => ctx.TypeDigests.Where(t => t.Code == "SubjectTypePerson").FirstOrDefault().Id);
            var sj = Connect(ctx => ctx.Subjects.Where(s => s.SubjectTypeId == typeId).ToList());
            return Connect(ctx => {
                List<Person> result = new List<Person>();
                foreach (Subject subject in sj) {
                    result.Add(ctx.Persons.Where(p => p.Id == subject.Id).FirstOrDefault());
                }
                return result;
            });
        }

        public List<SubjectRole> GetSubjectRoles(int subjectId, string roleTypeCode) {
            int typeId = Connect(ctx => ctx.TypeDigests.Where(s => s.Code == roleTypeCode).FirstOrDefault().Id);
            return Connect(ctx => ctx.SubjectRoles.Where(s => s.SubjectId == subjectId && s.RoleTypeId == typeId).ToList());
        }

        public List<SubjectName> GetAllNames(int subjectId)
            => Connect(ctx => ctx.SubjectNames.Where(s => s.SubjectId == subjectId).ToList());

        public Gender GetLastGender(int personId)
            => Connect(ctx => ctx.Genders.Where(g => g.PersonId == personId).OrderByDescending(g => g.From).FirstOrDefault());

        public string GetLastGenderCode(int personId) {
            Gender gender = GetLastGender(personId);
            return Connect(ctx => ctx.TypeDigests.Where(s => s.Id == gender.GenderTypeId).FirstOrDefault().Code);
        }

        public MaritalStatus GetLastMaritalStatus(int personId)
            => Connect(ctx => ctx.MaritalStatuses.Where(m => m.PersonId == personId).OrderByDescending(g => g.From).FirstOrDefault());

        public string GetLastMaritalStatusCode(int personId) {
            MaritalStatus maritalStatus = GetLastMaritalStatus(personId);
            return Connect(ctx => ctx.TypeDigests.Where(s => s.Id == maritalStatus.MaritalTypeId).FirstOrDefault().Code);
        }

        public List<SubjectName> GetAllNames(List<int> subjectIds)
            => Connect(ctx => ctx.SubjectNames.Join(subjectIds, sn => sn.SubjectId, i => i, (sn, i) => sn).ToList());

        public List<SubjectName> GetAllNames(List<Subject> subjects)
            => Connect(ctx => ctx.SubjectNames.Join(subjects, sn => sn.SubjectId, s => s.Id, (sn, i) => sn).ToList());

        public List<SubjectName> GetAllNames(List<Subject> subjects, string nameTypeCode) {
            int typeId = Connect(ctx => ctx.TypeDigests.Where(s => s.Code == nameTypeCode).FirstOrDefault().Id);
            var sun = Connect(ctx => ctx.SubjectNames.Where(sn => sn.NameTypeId == typeId).ToList());
            return sun.Join(subjects, sn => sn.SubjectId, s => s.Id, (sn, i) => sn).ToList();
        }

        public void InsertSubject(Subject subject)
            => Connect(
                    ctx => {
                        ctx.Subjects.Add(subject);
                        ctx.SaveChanges();
                        return Unit();
                    }
                );
    }
}
