using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace JTK.ArduinoArcade {
    class BooleanInversionValueConverter : MarkupExtension, IValueConverter {
        static BooleanInversionValueConverter instance = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return bool.TryParse(value?.ToString(), out bool b) && b != true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return instance ?? (instance = new BooleanInversionValueConverter());
        }
    }
}
