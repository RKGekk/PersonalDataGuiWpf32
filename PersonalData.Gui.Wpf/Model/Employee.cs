using PersonalData.Repository;
using PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.Model {

    public class Employee {

        private TypeRepository _typeRepository = new TypeRepository();
        private PersonalDataRepository _personalDataRepository = new PersonalDataRepository();

        public enum MaritalStatusType {
            Free,
            Married,
            Divorced
        }

        public enum GenderType {
            Male,
            Female
        }

        public static GenderType GenderFromCode(string genderCode) {
            switch(genderCode) {
                case "GenderTypeMale":
                    return GenderType.Male;
                case "GenderTypeFemale":
                    return GenderType.Female;
                default:
                    return GenderType.Male;
            }
        }

        public static MaritalStatusType MaritalFromCode(string MaritalCode) {
            switch (MaritalCode) {
                case "MaritalStatusTypeFree":
                    return MaritalStatusType.Free;
                case "MaritalStatusTypeMarried":
                    return MaritalStatusType.Married;
                case "MaritalStatusTypeDivorced":
                    return MaritalStatusType.Divorced;
                default:
                    return MaritalStatusType.Free;
            }
        }

        public List<Alias> Names { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatusType MatitalStatus { get; set; }
        public GenderType Gender { get; set; }

        public Department EmployeeDepartment { get; set; }
        public List<Employee> ManagerOf { get; set; }
        public List<Employee> ReportsTo { get; set; }

        public void Insert(string firstName, string secondName, string patronymic, GenderType gender, MaritalStatusType maritalStatus, DateTime birthDate, Department department) {

            Subject subject = new Subject();
            subject.SubjectTypeId = _typeRepository.GetTypeDigest("SubjectTypePerson").Match(() => new TypeDigest(), r => r).Id;

            Person person = new Person();
            person.BirthDate = birthDate;
            person.Comment = "";

            string maritalStatusCode = "";
            switch (maritalStatus) {
                case Employee.MaritalStatusType.Free: {
                        maritalStatusCode = "MaritalStatusTypeFree";
                    }
                    break;

                case Employee.MaritalStatusType.Married: {
                        maritalStatusCode = "MaritalStatusTypeMarried";
                    }
                    break;
                case Employee.MaritalStatusType.Divorced: {
                        maritalStatusCode = "MaritalStatusTypeDivorced";
                    }
                    break;
                default: {
                        maritalStatusCode = "MaritalStatusTypeFree";
                    }
                    break;
            }
            MaritalStatus reMaritalStatus = new MaritalStatus();
            reMaritalStatus.MaritalTypeId = _typeRepository.GetTypeDigest(maritalStatusCode).Match(() => new TypeDigest(), r => r).Id;
            reMaritalStatus.From = DateTime.Now;
            reMaritalStatus.Thru = new DateTime(2100, 1, 1);
            person.MaritalStatuses = new List<MaritalStatus>() { reMaritalStatus };

            string genderCode = "";
            switch (gender) {
                case Employee.GenderType.Male: {
                        genderCode = "GenderTypeMale";
                    }
                    break;
                case Employee.GenderType.Female: {
                        genderCode = "GenderTypeFemale";
                    }
                    break;
                default: {
                        genderCode = "GenderTypeMale";
                    }
                    break;
            }
            Gender reGender = new Gender();
            reGender.GenderTypeId = _typeRepository.GetTypeDigest(genderCode).Match(() => new TypeDigest(), r => r).Id;
            reGender.From = DateTime.Now;
            reGender.Thru = new DateTime(2100, 1, 1);
            person.Genders = new List<Gender>() { reGender };

            subject.Person = person;

            string firstNameCode = "NameTypeFirst";
            string secondNameCode = "NameTypeSecond";
            string patronymicNameCode = "NameTypePatronymic";
            SubjectName reSubjectFirstName = new SubjectName();
            SubjectName reSubjectSecondName = new SubjectName();
            SubjectName reSubjectPatronymicName = new SubjectName();
            reSubjectFirstName.NameTypeId = _typeRepository.GetTypeDigest(firstNameCode).Match(() => new TypeDigest(), r => r).Id;
            reSubjectFirstName.Name = firstName;
            reSubjectFirstName.From = DateTime.Now;
            reSubjectFirstName.Thru = new DateTime(2100, 1, 1);
            reSubjectSecondName.NameTypeId = _typeRepository.GetTypeDigest(secondNameCode).Match(() => new TypeDigest(), r => r).Id;
            reSubjectSecondName.Name = secondName;
            reSubjectSecondName.From = DateTime.Now;
            reSubjectSecondName.Thru = new DateTime(2100, 1, 1);
            reSubjectPatronymicName.NameTypeId = _typeRepository.GetTypeDigest(patronymicNameCode).Match(() => new TypeDigest(), r => r).Id;
            reSubjectPatronymicName.Name = patronymic;
            reSubjectPatronymicName.From = DateTime.Now;
            reSubjectPatronymicName.Thru = new DateTime(2100, 1, 1);
            subject.SubjectNames = new List<SubjectName>() { reSubjectFirstName, reSubjectSecondName, reSubjectPatronymicName };

            SubjectRole subjectRole = new SubjectRole();
            subjectRole.RoleTypeId = _typeRepository.GetTypeDigest("SubjectRoleEmployee").Match(() => new TypeDigest(), r => r).Id;
            subjectRole.From = DateTime.Now;
            subjectRole.Thru = new DateTime(2100, 1, 1);
            SubjectRole subjectRoleTo = _personalDataRepository.GetSubjectRoles(department.Id, "SubjectRoleDepartment")[0];
            RoleRelation roleRelation = new RoleRelation();
            roleRelation.FromSubjectRole = subjectRole;
            roleRelation.ToSubjectRole = subjectRoleTo;
            roleRelation.From = DateTime.Now;
            roleRelation.Thru = new DateTime(2100, 1, 1);
            roleRelation.RelationTypeId = _typeRepository.GetTypeDigest("RoleRelationEmployeeOfDepartment").Match(() => new TypeDigest(), r => r).Id;
            subjectRole.SubjectRolesFrom = new List<RoleRelation>() { roleRelation };
            subject.SubjectRoles = new List<SubjectRole>() { subjectRole };

            _personalDataRepository.InsertSubject(subject);
        }
    }
}
