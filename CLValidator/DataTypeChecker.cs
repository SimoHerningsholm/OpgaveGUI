using System;
using CLModels;

namespace CLValidator
{
    public class DataTypeChecker
    {
        //Formålet med denne klasse er udelukkende at tjekke op på datatyper
        public bool checkInt(object inType)
        {
            try
            {
                Convert.ToInt32(inType);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool checkInt(string inField)
        {
            int result;
            return int.TryParse(inField, out result);
        }
        public bool checkFloat(object inType)
        {
            if (inType.GetType() == typeof(float))
            {
                return true;
            }
            return false;
        }
        public bool checkDouble(object inType)
        {
            if (inType.GetType() == typeof(double))
            {
                return true;
            }
            return false;
        }
        public bool checkDecimal(object inType)
        {
            if (inType.GetType() == typeof(decimal))
            {
                return true;
            }
            return false;
        }
        public bool checkChar(object inType)
        {
            if (inType.GetType() == typeof(char))
            {
                return true;
            }
            return false;
        }
        public bool checkString(object inType)
        {
            if (inType.GetType() == typeof(string))
            {
                return true;
            }
            return false;
        }
        public bool checkDateTime(object inType)
        {
            try
            {
                DateTime date = Convert.ToDateTime(inType);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool checkDateTime(string inField)
        {
            DateTime result;
            return DateTime.TryParse(inField, out result);
        }
        public bool checkBool(object inType)
        {
            if (inType.GetType() == typeof(bool))
            {
                return true;
            }
            return false;
        }
        public bool checkBool(string inField)
        {
            try
            {
                Convert.ToBoolean(inField);
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
