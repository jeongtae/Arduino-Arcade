using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace JTK.ArduinoArcade {
    class ButtonsCountToWidthValueConverter : MarkupExtension, IValueConverter {
        static ButtonsCountToWidthValueConverter instance = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return 500 + (int.TryParse(value?.ToString(), out int i) ? (i / 2) * 1 : 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return instance ?? (instance = new ButtonsCountToWidthValueConverter());
        }
    }
}
