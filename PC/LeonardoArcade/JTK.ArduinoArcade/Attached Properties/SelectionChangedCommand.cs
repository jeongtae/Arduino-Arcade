using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JTK.ArduinoArcade {
    class SelectionChangedCommand : BaseAttachedProperty<SelectionChangedCommand, ICommand> {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is ComboBox control) {
                control.SelectionChanged -= ComboBox_SelectionChanged;
                control.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

        private static void ComboBox_SelectionChanged(object sender, EventArgs e) {
            if (sender is ComboBox control) {
                (GetValue(control) as ICommand)?.Execute(SelectionChangedCommandParameter.GetValue(control));
            }
        }
    }

    class SelectionChangedCommandParameter : BaseAttachedProperty<SelectionChangedCommandParameter, object> { }
}
