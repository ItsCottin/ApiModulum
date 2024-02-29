using System.ComponentModel;

namespace WebApiModulum.Enum
{
    public class ExtensionEnum
    {
        public String getStringEnumInDescription(Type enumerator)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])enumerator
            .GetType()
            .GetField(enumerator.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}