using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg.Svn.Api.Exceptions;

namespace Rpg.Svn.Api.Models
{
    public class CharacterEnumerations
    {
        public enum Id
        {

            Uthal = 0,
            Maegor = 1,
            Noon = 2,
            Aratosh = 3,
            Maciota = 4,
            Gormush = 5,
            Rhogar = 6,
            Sat = 7

        };

        public static bool Contains(string character) 
        {
            var candidate = (int)Enum.Parse(typeof(Id), character);

            var mainCharsList = Enum.GetValues(typeof(Id))
                          .OfType<Id>()
                          .Select(s => (int)s);
            if (!mainCharsList.ToList().Contains(candidate))
            {
                throw new NotAMainCharException();
            }
            return true;
        }

        public static int GetIdByName(string character)
        {
            return (int)Enum.Parse(typeof(Id), character);
        }
    }
}
