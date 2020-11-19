using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CLModels;

namespace CLValidator
{
    public class EmployeeFieldChecker
    {
        //Formålet med denne klasse er at tjekke bruger input for employee model. 
        private List<string> errorMessages;
        private FieldChecker fieldCheck;
        public EmployeeFieldChecker()
        {
            errorMessages = new List<string>();
            fieldCheck = new FieldChecker();
        }
        public async Task<bool> Check(Employee employee)
        {
            bool validationResult = true;
            List<char> forbiddenCharacters = new List<char>() {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }; //osv 
            if (await fieldCheck.checkForbinddenStringCharacters(forbiddenCharacters, employee.FirstName) == false)
            {
                fejlMeddelelseIncrementer("Name had forbidden characters");
                validationResult = false;
            }
            if(await fieldCheck.checkDateInterval(employee.BirthDay, new DateTime(1900, 1, 1), DateTime.Now))
            {
                fejlMeddelelseIncrementer("Birthday was not a possible date");
                validationResult = false;
            }

            return validationResult;
        }
        private async void fejlMeddelelseIncrementer(string errorType)
        {
            errorMessages.Add(errorType);
        }
        public async Task<List<string>> getErrorMessages()
        {
            return errorMessages;
        }
    }
}
