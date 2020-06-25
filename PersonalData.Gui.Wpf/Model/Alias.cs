using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalData.Gui.Wpf.Model
{
    public class Alias {

        public enum AliasType {
            FirstName,
            SecondName,
            Patronymic
        }

        public static AliasType AliasTypeFromCode(string AliasTypeCode) {
            switch (AliasTypeCode) {
                case "NameTypeFirst":
                    return AliasType.FirstName;
                case "NameTypeSecond":
                    return AliasType.SecondName;
                case "NameTypePatronymic":
                    return AliasType.Patronymic;
                default:
                    return AliasType.FirstName;
            }
        }

        public string FullName { get; set; }
        public string ShortName { get; set; }
        public AliasType NameType { get; set; }
        public int Sequence { get; set; }

        public static List<Alias> GetNames(string name) {

            return new List<Alias>(name.Split(' ').Select(
                (n, i) => new Alias() {
                    FullName = n,
                    NameType = i == 0 ? AliasType.FirstName : i == 1 ? AliasType.SecondName : AliasType.Patronymic,
                    Sequence = i,
                    ShortName = n.First().ToString()
                }
            ));
        }
    }
}
