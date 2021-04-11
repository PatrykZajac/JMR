using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DemoImplementation
{
    public class DemoImplementationClass
    {
        /*
         * Mapowanie takie może zostać użyte w sytuacji gdy będzie niewiele rekordów, jeśli do każdej osoby będzie przypisane po 1000 adresów email i osób będzie 1000000
         * to mapowanie takie spowoduje otrzymanie miliarda rekordów, co może mieć problem ze zmieszczeniem się w pamięci operacyjnej
         */
        public static IEnumerable<DemoTarget.PersonWithEmail> Flatten(IEnumerable<DemoSource.Person> people)
        {
            var result = new List<DemoTarget.PersonWithEmail>();

            foreach (var person in people)
            {
                Regex rgx = new Regex("[^a-zA-Z0-9]");
                var name = string.Format("{0}{1}", rgx.Replace(person.Name, ""), rgx.Replace(person.Id, ""));

                foreach (var email in person.Emails)
                {
                    var formattedEmail = string.Format("Email: {0}, EmailType: {1}", email.Email, email.EmailType);
                    result.Add(new DemoTarget.PersonWithEmail()
                    {
                        FormattedEmail = formattedEmail,
                        SanitizedNameWithId = name
                    });
                }
            }
            return result;
        }
    }

}
