using System;
using System.Collections.Generic;
using System.Text;
using CLModels;

namespace CLValidator
{
    public class EmployeeDataTypeChecker
    {
        //Formålet med denne klasse er at tjekke bruger input for employee model. 
        private List<string> errorMessages;
        private DataTypeChecker dataCheck;
        public EmployeeDataTypeChecker()
        {
            errorMessages = new List<string>();
            dataCheck = new DataTypeChecker();
        }
        public bool employeeDataChecker(List<object> employeeFields)
        {
            bool validationResult = true;
            if (dataCheck.checkString(employeeFields[0]) == false)
            {
                fejlMeddelelseIncrementer("Name was not a string");
                validationResult = false;
            }
            if (dataCheck.checkString(employeeFields[1]) == false)
            {
                fejlMeddelelseIncrementer("Address was not a string");
                validationResult = false;
            }
            if (dataCheck.checkInt(employeeFields[2]) == false)
            {
                fejlMeddelelseIncrementer("Zipcode was not an int");
                validationResult  = false;
            }
            if(dataCheck.checkDateTime(employeeFields[3]) == false)
            {
                fejlMeddelelseIncrementer("Birthday was not a birthday");
                validationResult = false;
            }
            if (dataCheck.checkString(employeeFields[4]) == false)
            {
                fejlMeddelelseIncrementer("Company was not a string");
                validationResult = false;
            }
            if (dataCheck.checkString(employeeFields[5]) == false)
            {
                fejlMeddelelseIncrementer("Department was not a string");
                validationResult = false;
            }
            return validationResult;
        }
        private void fejlMeddelelseIncrementer(string errorType)
        {
            errorMessages.Add(errorType);
        }
        public List<string> getErrorMessages()
        {
            return errorMessages;
        }
    }
}
