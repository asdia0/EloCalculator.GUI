namespace EloCalculator.GUI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// Code taken from <see href="https://stackoverflow.com/questions/20326744/wpf-binding-width-to-parent-width0-3">here</see>.
    /// </summary>
    public class PercentageConverter : MarkupExtension, IValueConverter
    {
        private static PercentageConverter _instance;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ??= new PercentageConverter();
        }
    }
}