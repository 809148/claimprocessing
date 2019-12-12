using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Api.Infrastructure.DTOs
{
    public class Name
    {
        //private string _prefix, _fName, _lName, _mName, _suffix;
        //public Name (string prefix, string firstName, string lastName, string middleName, string suffix)
        //{
        //    _prefix = prefix;
        //    _fName = firstName;
        //    _lName = lastName;
        //    _mName = middleName;
        //    _suffix = suffix;
        //}

        public string Prefix
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }

        public string MiddleName
        {
            get; set;
        }

        public string Suffix
        {
            get; set;
        }
    }
}
