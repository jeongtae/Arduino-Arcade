using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTK.ArduinoArcade {
    /// <summary>
    /// The wrapper class for integer type that is available to notify PropertyChanged
    /// </summary>
    class NotifyableIntWrapper : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public NotifyableIntWrapper(int n) {
            Value = n;
        }

        public int Value {
            get => this.value;
            set {
                this.value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        int value;

        public override string ToString() {
            return Value.ToString();
        }
    }
}
