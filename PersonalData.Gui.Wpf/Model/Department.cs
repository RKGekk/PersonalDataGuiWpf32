using PersonalData.Repository;
using bo = PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.Model
{
    public class Department {

        private TypeRepository _typeRepository = new TypeRepository();
        private PersonalDataRepository _personalDataRepository = new PersonalDataRepository();

        public Department() {

        }

        public Department(string name, string description, int id) {
            this.Name = name;
            this.Description = description;
            this.Id = id;
        }

        public void Insert(string name) {

            bo.Subject subject = new bo.Subject();
            subject.SubjectTypeId = _typeRepository.GetTypeDigest("SubjectTypeDepartment").Match(() => new TypeDigest(), r => r).Id;

            bo.Organization organization = new bo.Organization();
            organization.OrganizationTypeId = _typeRepository.GetTypeDigest("OrganizationTypeDepartment").Match(() => new TypeDigest(), r => r).Id;
            subject.Organization = organization;

            string fullNameCode = "NameTypeFull";
            bo.SubjectName reSubjectFullName = new bo.SubjectName();
            reSubjectFullName.NameTypeId = _typeRepository.GetTypeDigest(fullNameCode).Match(() => new TypeDigest(), r => r).Id;
            reSubjectFullName.Name = name;
            reSubjectFullName.From = DateTime.Now;
            reSubjectFullName.Thru = new DateTime(2100, 1, 1);
            subject.SubjectNames = new List<bo.SubjectName>() { reSubjectFullName };

            bo.SubjectRole subjectRole = new bo.SubjectRole();
            subjectRole.RoleTypeId = _typeRepository.GetTypeDigest("SubjectRoleDepartment").Match(() => new TypeDigest(), r => r).Id;
            subjectRole.From = DateTime.Now;
            subjectRole.Thru = new DateTime(2100, 1, 1);
            subject.SubjectRoles = new List<bo.SubjectRole>() { subjectRole };

            _personalDataRepository.InsertSubject(subject);
        }

        public List<Department> GetAllDepartments() {
            List<bo.Subject> subjects = _personalDataRepository.GetAllSubjects(_typeRepository.GetTypeDigest("SubjectTypeDepartment").Match(() => new TypeDigest(), r => r).Id).ToList();
            List<bo.SubjectName> names = _personalDataRepository.GetAllNames(subjects.Select(s => s.Id).ToList());
            return names.Select(sn => new Department(sn.Name, "", sn.SubjectId)).ToList();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}
