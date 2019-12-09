using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JTK.ArduinoArcade {
    /// <summary>
    /// KeyBoxControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class KeyBoxControl : UserControl {
        public KeyBoxControl() {
            InitializeComponent();
        }

        #region Properties

        public int KeyCode {
            get => (int)GetValue(KeyCodeProperty);
            set => SetValue(KeyCodeProperty, value);
        }

        #endregion

        #region Registration of Dependency Property

        public static readonly DependencyProperty KeyCodeProperty = DependencyProperty.Register(
            name: nameof(KeyCode), 
            propertyType: typeof(int), 
            ownerType: typeof(KeyBoxControl), 
            typeMetadata: new PropertyMetadata(defaultValue:0, propertyChangedCallback:KeyCodePropertyChangedCallback),
            validateValueCallback: KeyCodeValidateValueCallback);

        /// <summary>
        /// The callback event when the <see cref="KeyCode"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e">The arguments for the event</param>
        static void KeyCodePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            (d as KeyBoxControl).OnKeyCodePropertyChanged(e);
        }

        static bool KeyCodeValidateValueCallback(object obj) {
            int value = obj is int ? (int)obj : int.Parse(obj.ToString());

            return value >= 0;
        }

        #endregion

        #region Event Methods

        protected override void OnPreviewKeyDown(KeyEventArgs e) {
            base.OnPreviewKeyDown(e);

            var k = e.Key;

            if (e.Key == Key.Tab) {
                e.Handled = true;
            }
            
            KeyCode = LeonardoKeys.VirtualKeyToLeonardoKey(k);
        }

        void OnKeyCodePropertyChanged(DependencyPropertyChangedEventArgs e) {
            MainTextBox.Text = LeonardoKeys.LeonardoKeyToString(KeyCode); //((Key)KeyCode).ToString();
        }

        #endregion
    }
}
