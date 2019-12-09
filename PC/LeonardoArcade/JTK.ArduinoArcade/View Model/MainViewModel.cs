using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace JTK.ArduinoArcade {
    class MainViewModel : INotifyPropertyChanged {
        #region PropertyChanged

        /// <summary>
        /// The event that is fired when any child property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Properties

        public bool Applying { 
            get => applying;
            set {
                applying = value;
                OnPropertyChanged(nameof(Applying));
            }
        }
        bool applying = false;

        public bool ApplyIsEnabled {
            get => applyIsEnabled;
            set {
                applyIsEnabled = value;
                OnPropertyChanged(nameof(ApplyIsEnabled));
            }
        }
        bool applyIsEnabled = false;
        
        public int UpKeyCode {
            get => upKeyCode;
            set {
                upKeyCode = value;
                OnPropertyChanged(nameof(UpKeyCode));
            }
        }
        int upKeyCode;

        public int DownKeyCode {
            get => downKeyCode;
            set {
                downKeyCode = value;
                OnPropertyChanged(nameof(DownKeyCode));
            }
        }
        int downKeyCode;

        public int LeftKeyCode {
            get => leftKeyCode;
            set {
                leftKeyCode = value;
                OnPropertyChanged(nameof(LeftKeyCode));
            }
        }
        int leftKeyCode;

        public int RightKeyCode {
            get => rightKeyCode;
            set {
                rightKeyCode = value;
                OnPropertyChanged(nameof(RightKeyCode));
            }
        }
        int rightKeyCode;

        public NotifyableIntWrapper[] ButtonKeyCodes {
            get => buttonKeyCodes;
            set {
                buttonKeyCodes = value;
                OnPropertyChanged(nameof(ButtonKeyCodes));
            }
        }
        NotifyableIntWrapper[] buttonKeyCodes;

        public int[] ButtonsCountSamples {
            get => buttonsCountSamples;
            set {
                buttonsCountSamples = value;
                OnPropertyChanged(nameof(ButtonsCountSamples));
            }
        }
        int[] buttonsCountSamples = { 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int ButtonsCount {
            get => buttonsCount;
            set {
                buttonsCount = value;
                OnPropertyChanged(nameof(ButtonsCount));
            }
        }
        int buttonsCount;

        public string Port {
            get => port;
            set {
                port = value;
                OnPropertyChanged(nameof(Port));
            }
        }
        string port;

        public string[] Ports {
            get => ports;
            set {
                ports = value;
                OnPropertyChanged(nameof(Ports));
            }
        }
        string[] ports = {};

        #endregion

        #region Commands

        public ICommand ApplyCommand { get; private set; }

        public ICommand UpdatePortListCommand { get; private set; }

        public ICommand SelectPortCommand { get; private set; }

        public ICommand SetButtonsCountCommand { get; private set; }

        #endregion

        #region Constructor

        public MainViewModel() {
            // Assign commands
            ApplyCommand = new RelayCommand(async () => await Apply());
            UpdatePortListCommand = new RelayCommand(() => UpdatePortList());
            SelectPortCommand = new ParameterizedRelayCommand((parameter) => SelectPort(parameter.ToString()));
            SetButtonsCountCommand = new ParameterizedRelayCommand((parameter) => SetButtonsCount((int)parameter));
            // Load settings
            var btnsCnt = Properties.Settings.Default.ButtonsCount;
            SetButtonsCount(btnsCnt);
            try {
                var mapSplit = Properties.Settings.Default.Map.Split(',');
                if (mapSplit.Length >= 4) {
                    UpKeyCode = int.Parse(mapSplit[0]);
                    DownKeyCode = int.Parse(mapSplit[1]);
                    LeftKeyCode = int.Parse(mapSplit[2]);
                    RightKeyCode = int.Parse(mapSplit[3]);
                }
                for (var i = 0; i < buttonKeyCodes.Length && i+4 < mapSplit.Length; i++) {
                    if (int.TryParse(mapSplit[i+4], out int result)) {
                        buttonKeyCodes[i] = new NotifyableIntWrapper(result);
                    }
                }
            } catch {
                Properties.Settings.Default.Map = "";
                Properties.Settings.Default.Save();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Apply key mapping to the Arduino Leonardo that connected with current selected COM port by serial communication.
        /// </summary>
        async Task Apply() {
            Applying = true;
            bool succeed = false;
            await Task.Run(() => {
                var serialPort = new SerialPort {
                    PortName = Port,
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    Handshake = Handshake.None,
                    StopBits = StopBits.One,
                    Encoding = Encoding.ASCII,
                    WriteTimeout=3000
                };
                try {
                    serialPort?.Open();
                    string map = SerializeCurrentMap();
                    serialPort.Write(map);
                    serialPort.Close();
                    succeed = true;
                    // Save setting
                    Properties.Settings.Default.Map = map;
                    Properties.Settings.Default.Save();
                } catch (Exception exception) {
                    Debug.WriteLine(exception.Message);
                } finally {
                    if (serialPort?.IsOpen ?? false) {
                        serialPort.Close();
                    }
                }
            });
            
            if (succeed) {
                MessageBox.Show("Applied!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                MessageBox.Show("Failed to send the message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Applying = false;
        }

        /// <summary>
        /// Update the 'Ports' property containing a current available serial port list.
        /// </summary>
        void UpdatePortList() {
            Ports = new List<string>(SerialPort.GetPortNames()).ToArray();
        }

        /// <summary>
        /// Change the current selected serial port.
        /// </summary>
        /// <param name="port"></param>
        void SelectPort(string port) {
            ApplyIsEnabled = string.IsNullOrWhiteSpace(port) == false;
        }

        /// <summary>
        /// Change the current set arcade buttons count.
        /// </summary>
        /// <param name="count"></param>
        void SetButtonsCount(int count) {
            ButtonKeyCodes = new NotifyableIntWrapper[count];
            for (var i = 0; i < count; i++) {
                ButtonKeyCodes[i] = new NotifyableIntWrapper(0);
            }
            ButtonsCount = count;
            // Save setting
            Properties.Settings.Default.ButtonsCount = count;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Serialize to a string the current key mapping.
        /// </summary>
        /// <returns>Serialized string</returns>
        string SerializeCurrentMap() {
            var sb = new StringBuilder();
            sb.Append($"{UpKeyCode},");
            sb.Append($"{DownKeyCode},");
            sb.Append($"{LeftKeyCode},");
            sb.Append($"{RightKeyCode},");
            foreach (var kc in ButtonKeyCodes) {
                sb.Append($"{kc},");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        #endregion
    }
}
