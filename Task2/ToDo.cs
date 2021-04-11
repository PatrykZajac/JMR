using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

internal class ToDo
{
    public IEnumerable<(DemoSource.Account, DemoSource.Person)>
        MatchPersonToAccount(
        IEnumerable<DemoSource.Group> groups,
        IEnumerable<DemoSource.Account> accounts,
        IEnumerable<string> emails)
    {
        var result = new List<(DemoSource.Account, DemoSource.Person)>();

        var emailAddresesDictionary = new Dictionary<string, DemoSource.Account>();

        foreach (var email in emails)
        {
            emailAddresesDictionary.Add(email, accounts.Where(item => item.EmailAddress.Email == email).FirstOrDefault());
        }

        Parallel.ForEach(groups, g =>
        {
            Parallel.ForEach(g.People, p =>
            {
                Parallel.ForEach(p.Emails, e =>
                {
                    result.Add((emailAddresesDictionary[e.Email], p));
                });
            });


        });



        return result;
    }
}