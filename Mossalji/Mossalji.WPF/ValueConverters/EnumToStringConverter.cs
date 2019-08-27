using Mossalji.WPF.Properties;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace Mossalji.WPF
{
    /// <summary>
    /// A converter that takes in a boolean and returns a thickness of 2 if true, useful for applying 
    /// border radius on a true value
    /// </summary>
    public class EnumToStringConverter : BaseValueConverter<EnumToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            { return null; }

            return Resources.ResourceManager.GetString(value.ToString());
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = (string)value;

            foreach (object enumValue in Enum.GetValues(targetType))
            {
                if (str == Resources.ResourceManager.GetString(enumValue.ToString()))
                { return enumValue; }
            }

            throw new ArgumentException(null, "value");
        }


        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }

    public sealed class EnumerateExtension : MarkupExtension
    {
        public Type Type { get; set; }

        public EnumerateExtension(Type type)
        {
            this.Type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            string[] names = Enum.GetNames(Type);
            string[] values = new string[names.Length];

            for (int i = 0; i < names.Length; i++)
            { values[i] = Resources.ResourceManager.GetString(names[i]); }

            return values;
        }

        private string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
