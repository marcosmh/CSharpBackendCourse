using System;

namespace BackendCSharp.Services
{
	public class PeopleService : IPeopleService
	{

        public bool Validate(People people)
        {
            if(string.IsNullOrEmpty(people.Name))
            {
                return false;
            }

            return true;
        }


    }
}

