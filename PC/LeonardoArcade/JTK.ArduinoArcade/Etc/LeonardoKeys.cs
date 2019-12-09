using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static JTK.ArduinoArcade.LeonardoModifierKeys;

namespace JTK.ArduinoArcade {
    static class LeonardoKeys {
        public static int VirtualKeyToLeonardoKey(Key k) {
            if (Key.A <= k && k <= Key.Z) { // A-Z
                return k - Key.A + 0x61;
            } else if (Key.D0 <= k && k <= Key.D9) { // 0-9
                return k - Key.D0 + 0x30;
            } else if (Key.F1 <= k && k <= Key.F12) { //F1-F12
                return k - Key.F1 + (int)KEY_F1;
            } else {
                switch (k) {
                    case Key.Space: return 0x20;
                    case Key.OemTilde: return 0x60;// ~ 7E
                    case Key.OemMinus: return 0x2D;// _ 5F
                    case Key.OemPlus: return 0x3D; // + 2B
                    case Key.OemOpenBrackets: return 0x5B;//{ 7B
                    case Key.OemCloseBrackets: return 0x5D;//} 7D
                    case Key.OemSemicolon: return 0x3B;// : 3A
                    case Key.OemQuotes: return 0x27; // " 22
                    case Key.OemPipe: return 0x5C;// | 7C
                    case Key.OemComma: return 0x2C;// < 3C
                    case Key.OemPeriod: return 0x2E;// > 3E
                    case Key.OemQuestion: return 0x2F;// ? 3F

                    case Key.Insert: return (int)KEY_INSERT;
                    case Key.Delete: return (int)KEY_DELETE;
                    case Key.Home: return (int)KEY_HOME;
                    case Key.End: return (int)KEY_END;
                    case Key.PageUp: return (int)KEY_PAGE_UP;
                    case Key.PageDown: return (int)KEY_PAGE_DOWN;

                    case Key.Divide: return 0x2F;
                    case Key.Multiply: return 0x2A;
                    case Key.Subtract: return 0x2D;
                    case Key.Add: return 0x2B;
                    case Key.Decimal: return 0x2E;

                    case Key.Up: return (int)KEY_UP_ARROW;
                    case Key.Down: return (int)KEY_DOWN_ARROW;
                    case Key.Left: return (int)KEY_LEFT_ARROW;
                    case Key.Right: return (int)KEY_RIGHT_ARROW;

                    case Key.Return: return (int)KEY_RETURN;
                    case Key.Escape: return (int)KEY_ESC;
                    case Key.Back: return (int)KEY_BACKSPACE;
                    case Key.Tab: return (int)KEY_TAB;
                    case Key.CapsLock: return (int)KEY_CAPS_LOCK;

                    case Key.LeftCtrl: return (int)KEY_LEFT_CTRL;
                    case Key.RightCtrl: case Key.HanjaMode: return (int)KEY_RIGHT_CTRL;

                    case Key.LeftAlt: case Key.System: return (int)KEY_LEFT_ALT;
                    case Key.RightAlt: case Key.HangulMode: case Key.ImeProcessed: return (int)KEY_RIGHT_ALT;

                    case Key.LWin: return (int)KEY_LEFT_GUI;
                    case Key.RWin: return (int)KEY_RIGHT_GUI;

                    case Key.LeftShift: return (int)KEY_LEFT_SHIFT;
                    case Key.RightShift: return (int)KEY_RIGHT_SHIFT;

                    default: return 0;
                }
            }
        }

        public static string LeonardoKeyToString(int key) {
            if (0x61 <= key && key <= 0x7A) { // A-Z
                return ((char)('A' + key - 0x61)).ToString();
            } else if (0x30 <= key && key <= 0x39) {
                return ((char)('0' + key - 0x30)).ToString();
            } else if ((int)KEY_F1 <= key && key <= (int)KEY_F9) {
                return $"F{(char)('1' + key - KEY_F1)}";
            } else if ((int)KEY_F10 <= key && key <= (int)KEY_F12) {
                return $"F1{(char)('0' + key - KEY_F10)}";
            } else if (key == 0x20) {
                return "Space";
            } else if (key == 0x2A) {
                return "*";
            } else if (key == 0x2B) {
                return "+";
            } else if (key == 0x60) {
                return "`";
            } else if (key == 0x2D) {
                return "-";
            } else if (key == 0x3D) {
                return "=";
            } else if (key == 0x5B) {
                return "[";
            } else if (key == 0x5D) {
                return "]";
            } else if (key == 0x3B) {
                return ";";
            } else if (key == 0x27) {
                return "'";
            } else if (key == 0x5C) {
                return "\\";
            } else if (key == 0x2C) {
                return ",";
            } else if (key == 0x2E) {
                return ".";
            } else if (key == 0x2F) {
                return "/";
            } else {
                switch ((LeonardoModifierKeys)key) {
                    case KEY_UP_ARROW: return "↑";
                    case KEY_DOWN_ARROW: return "↓";
                    case KEY_LEFT_ARROW: return "←";
                    case KEY_RIGHT_ARROW: return "→";
                    case KEY_RETURN: return "Return";
                    case KEY_ESC: return "Esc";
                    case KEY_BACKSPACE: return "Back";
                    case KEY_TAB: return "Tab";
                    case KEY_CAPS_LOCK: return "Caps Lock";
                    case KEY_LEFT_CTRL: return "L Ctrl";
                    case KEY_LEFT_SHIFT: return "L Shift";
                    case KEY_LEFT_ALT: return "L Alt";
                    case KEY_LEFT_GUI: return "L Win";
                    case KEY_RIGHT_CTRL: return "R Ctrl";
                    case KEY_RIGHT_SHIFT: return "R Shift";
                    case KEY_RIGHT_ALT: return "R Alt";
                    case KEY_RIGHT_GUI: return "R Win";
                    case KEY_INSERT: return "Insert";
                    case KEY_DELETE: return "Delete";
                    case KEY_HOME: return "Home";
                    case KEY_END: return "End";
                    case KEY_PAGE_UP: return "Page Up";
                    case KEY_PAGE_DOWN: return "Page Down";
                }
            }
            return "";
        }
    }
}
