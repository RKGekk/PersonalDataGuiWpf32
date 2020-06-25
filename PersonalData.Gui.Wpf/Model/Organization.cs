using PersonalData.Repository;
using bo = PersonalData.Repository.Model.BusinessObjects;
using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.Model {

    public class Organization {

        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }

        private TypeRepository _typeRepository = new TypeRepository();
        private PersonalDataRepository _personalDataRepository = new PersonalDataRepository();

        public Organization() {
            Departments = _personalDataRepository.GetAllNames(_personalDataRepository.GetAllSubjects("SubjectTypeDepartment"), "NameTypeFull").Select(sn => new Department(sn.Name, "", sn.SubjectId)).ToList();
            Employees =
                _personalDataRepository
                .GetAllPersons()
                .Select(
                    p => new Employee() {
                        DateOfBirth = p.BirthDate,
                        Gender = Employee.GenderFromCode(_personalDataRepository.GetLastGenderCode(p.Id)),
                        MatitalStatus = Employee.MaritalFromCode(_personalDataRepository.GetLastMaritalStatusCode(p.Id)),
                        Names =
                            _personalDataRepository
                            .GetAllNames(p.Id)
                            .Select(
                                sn => new Alias() {
                                    Sequence = sn.OrderInSequence,
                                    FullName = sn.Name,
                                    NameType = Alias.AliasTypeFromCode(_typeRepository.GetTypeDigest(sn.NameTypeId).Match(() => new TypeDigest(), t => t).Code),
                                    ShortName = sn.Name[0].ToString()
                                }
                            ).ToList()
                    }
                )
                .ToList();
            
        }
    }
}
