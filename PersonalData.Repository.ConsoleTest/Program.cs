using PersonalData.Repository.Model.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PersonalData.Repository.Extensions;

namespace PersonalData.Repository.ConsoleTest {
    class Program {

        string greet1(Option<string> greetee)
                => greetee.Match(
                    None: () => "Sorry, who?",
                    Some: (name) => $"Hello, {name}"
                );

        static void Main(string[] args) {

            Func<Option<string>, string> greet2 = (Option<string> greetee)
                => greetee.Match(
                    None: () => "Sorry, who?",
                    Some: (name) => $"Hello, {name}"
                );

            string gg1 = greet2("Jo");

            string gg2 = greet2(null);

            using (PersonalDataContext context = new PersonalDataContext()) {

                foreach (TypeDigest typeDigest in context.TypeDigests) {
                    Console.WriteLine(typeDigest.Code);
                }
            }

            Console.ReadKey();
        }
    }
}
