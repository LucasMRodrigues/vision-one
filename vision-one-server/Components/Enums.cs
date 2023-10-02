using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LoginApp.Components
{
    public class Enums
    {
        public class Api
        {
            public enum Error
            {
                // Membership
                [Description("PasswordsMustMatch")]
                PasswordsMustMatch = 400,
                [Description("PasswordIsNotValid")]
                PasswordIsNotValid = 401,
                [Description("EmailIsNotValid")]
                EmailIsNotValid = 402,
                [Description("EmailNotRegistered")]
                EmailNotRegistered = 403,
                [Description("CannotFindData")]
                CannotFindData = 404,
                [Description("PasswordIsWrong")]
                PasswordIsWrong = 405,
                

                // General
                [Description("GeneralException")]
                GeneralException = 500,
                [Description("MissingData")]
                MissingData = 501
            }
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static Dictionary<int, string> GetDescriptions(Type enumType)
        {
            Array enumTypeValues = Enum.GetValues(enumType);

            Dictionary<int, string> descriptions = new Dictionary<int, string>(enumTypeValues.Length);
            for (int i = 0; i <= enumTypeValues.Length - 1; i++)
            {
                descriptions.Add(Convert.ToInt32(enumTypeValues.GetValue(i)), GetDescription((Enum)enumTypeValues.GetValue(i)));
            }
            return descriptions;
        }
    }
}
