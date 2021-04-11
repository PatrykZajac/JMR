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
                //Nie bardzo wiem jaki mają mieć format wyjściowo te dane, więc po prostu to ze sobą połączyłem wycinająć wszystko poza dozwolonymi znakami
                var name = rgx.Replace(string.Format("{0}{1}", person.Name, person.Id), "");

                foreach (var email in person.Emails)
                {
                    //Tak samo z tym formatem emaila, brakuje jakiegoś przykłady z formatem wyjściowym
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
