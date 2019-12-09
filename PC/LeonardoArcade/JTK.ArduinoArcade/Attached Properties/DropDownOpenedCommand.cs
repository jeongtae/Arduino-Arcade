using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JTK.ArduinoArcade {
    class DropDownOpenedCommand : BaseAttachedProperty<DropDownOpenedCommand, ICommand> {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            if (sender is ComboBox control) {
                control.DropDownOpened -= ComboBox_DropDownOpened;
                control.DropDownOpened += ComboBox_DropDownOpened;
            }
        }

        private static void ComboBox_DropDownOpened(object sender, EventArgs e) {
            if (sender is ComboBox control) {
                (GetValue(control) as ICommand)?.Execute(null);
            }
        }
    }
}
