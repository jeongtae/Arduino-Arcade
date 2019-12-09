/* ------------------------- */
/* -     User Settings     - */
/* ------------------------- */

#define PIN_UP (0)
#define DEF_UP (KEY_UP_ARROW)
#define PIN_DOWN (1)
#define DEF_DOWN (KEY_DOWN_ARROW)
#define PIN_LEFT (2)
#define DEF_LEFT (KEY_LEFT_ARROW)
#define PIN_RIGHT (3)
#define DEF_RIGHT (KEY_RIGHT_ARROW)

#define PIN_BTN1 (4)
#define DEF_BTN1 ('a')
#define PIN_BTN2 (5)
#define DEF_BTN2 ('z')
#define PIN_BTN3 (6)
#define DEF_BTN3 ('s')
#define PIN_BTN4 (7)
#define DEF_BTN4 ('x')
#define PIN_BTN5 (8)
#define DEF_BTN5 ('d')
#define PIN_BTN6 (9)
#define DEF_BTN6 ('c')
#define PIN_BTN7 (10)
#define DEF_BTN7 ('f')
#define PIN_BTN8 (11)
#define DEF_BTN8 ('v')
//#define PIN_BTN9 (12)
//#define DEF_BTN9 ('g')
//#define PIN_BTN10 (14)
//#define DEF_BTN10 ('b')
//#define PIN_BTN11 (15)
//#define DEF_BTN11 ('h')
//#define PIN_BTN12 (16)
//#define DEF_BTN12 ('n')

// Uncomment this line if you experienced double input.
#define DEBOUNCE_MODE
#define DEBOUNCE_TIME_MS (8)


/* ------------------------- */
/* -     Source Codes      - */
/* ------------------------- */

#include <EEPROM.h>
#include <Keyboard.h>
#define VALID_HASH (0x213B)
#define PIN_LED (13)
#define EEPROM_ADDR_OFFSET (0)


const byte keyPins[] = {PIN_UP, PIN_DOWN, PIN_LEFT, PIN_RIGHT
#ifdef PIN_BTN12
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7, PIN_BTN8, PIN_BTN9, PIN_BTN10, PIN_BTN11, PIN_BTN12};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7, DEF_BTN8, DEF_BTN9, DEF_BTN10, DEF_BTN11, DEF_BTN12};
#elif PIN_BTN11
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7, PIN_BTN8, PIN_BTN9, PIN_BTN10, PIN_BTN11};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7, DEF_BTN8, DEF_BTN9, DEF_BTN10, DEF_BTN11};
#elif PIN_BTN10
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7, PIN_BTN8, PIN_BTN9, PIN_BTN10};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7, DEF_BTN8, DEF_BTN9, DEF_BTN10};
#elif PIN_BTN9
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7, PIN_BTN8, PIN_BTN9};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7, DEF_BTN8, DEF_BTN9};
#elif PIN_BTN8
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7, PIN_BTN8};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7, DEF_BTN8};
#elif PIN_BTN7
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6, PIN_BTN7};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6, DEF_BTN7};
#elif PIN_BTN6
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5, PIN_BTN6};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5, DEF_BTN6};
#elif PIN_BTN5
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4, PIN_BTN5};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4, DEF_BTN5};
#elif PIN_BTN4
, PIN_BTN1, PIN_BTN2, PIN_BTN3, PIN_BTN4};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3, DEF_BTN4};
#elif PIN_BTN3
, PIN_BTN1, PIN_BTN2, PIN_BTN3};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2, DEF_BTN3};
#elif PIN_BTN2
, PIN_BTN1, PIN_BTN2};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1, DEF_BTN2};
#elif PIN_BTN1
, PIN_BTN1};
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT, DEF_BTN1};
#else
char keyMap[] = {DEF_UP, DEF_DOWN, DEF_LEFT, DEF_RIGHT};
};
#endif
const byte pinsLength = sizeof(keyPins) / sizeof(byte);
bool pressingStates[pinsLength];
#ifdef DEBOUNCE_MODE
unsigned long stateChangedTime[pinsLength];
#endif

// Read 2 Bytes int from the EEPROM
int readMem(int address) {
  int buffer;
  byte *ptr = (byte *)&buffer;
  address *= 2;
  address += EEPROM_ADDR_OFFSET;
  *ptr++ = EEPROM.read(address++);
  *ptr++ = EEPROM.read(address++);
  return buffer;
}

// Write 2 Bytes int to the EEPROM
void writeMem(int address, const int value) {
  byte *ptr = (byte *)&value;
  address *= 2;
  address += EEPROM_ADDR_OFFSET;
  EEPROM.update(address++, *ptr++);//update
  EEPROM.update(address++, *ptr++);
}

// Load a keymap from the EEPROM
bool loadKeyMap(byte * map, byte length) {
  if(readMem(0) != VALID_HASH || readMem(1) != length) {
    return false;
  }
  for (byte i = 0; i < length; i++) {
    map[i] = readMem(2 + i);
  }
  return true;
}

// Write a keymap from the EEPROM
void saveKeyMap(const byte * map, byte length) {
  writeMem(0, 0);
  for (byte i = 0; i < length; i++) {
    writeMem(2 + i, map[i]);
  }
  writeMem(0, VALID_HASH);
  writeMem(1, length);
}

// Arduino initial setup
void setup() {
  // Setup pins and key map
  for (byte i = 0; i < pinsLength; i++) {
    pinMode(keyPins[i], INPUT_PULLUP);
    keyMap[i] = 0;
    pressingStates[i] = false;
    #ifdef DEBOUNCE_MODE
    stateChangedTime[i] = 0;
    #endif
  }
  pinMode(PIN_LED, OUTPUT);
  
  // Load keymap
  loadKeyMap(keyMap, pinsLength);
  
  // Begin peripherals
  Serial.begin(9600, SERIAL_8N1);
  Keyboard.begin();
}

// Arduino main loop
void loop() {
  // Check for keymap updates
  if (Serial.available() > 0) {
    digitalWrite(PIN_LED, HIGH);
    // Get keymap
    String receivedString = Serial.readString();  // 128,135,122,155 ...
    char *received = receivedString.c_str();
    // Tokenize key map
    byte tokIndex = 0;
    char *tokPtr = strtok(received, ",");  // takes a list of delimiters
    char *toks[pinsLength];
    while(tokPtr != NULL) {
      toks[tokIndex++] = tokPtr;
      tokPtr = strtok(NULL, ",");
      if (tokIndex >= pinsLength) {
        break;
      }
    }
    // If validated
    if (tokIndex == pinsLength) {
      // Apply key map
      for (int i = 0; i < pinsLength; i++) {
        keyMap[i] = atoi(toks[i]);
      }
      // Release keys
      Keyboard.releaseAll();
      // Save keymap
      saveKeyMap(keyMap, pinsLength);
    }
    digitalWrite(PIN_LED, LOW);
  }
  
  // Process Keys (Prevent double input)
  #ifdef DEBOUNCE_MODE
  unsigned long current = millis();
  char key;
  bool state;
  for (byte i = 0; i < pinsLength; i++) {
    key = keyMap[i];
    if (key == 0) {
      continue;
    }
    state = digitalRead(keyPins[i]) == LOW;
    if (state == true  && pressingStates[i] == false && current - stateChangedTime[i] >= DEBOUNCE_TIME_MS) {
      Keyboard.press(key);
      pressingStates[i] = true;
      stateChangedTime[i] = current;
    } else if (state == false && pressingStates[i] == true && current - stateChangedTime[i] >= DEBOUNCE_TIME_MS) {
      Keyboard.release(key);
      pressingStates[i] = false;
      stateChangedTime[i] = current;
    }
  }
  // Process Keys (Don't prevent double input)
  #else
  char key;
  int state;
  for (byte i = 0; i < pinsLength; i++) {
    key = keyMap[i];
    if (key == 0) {
      continue;
    }
    state = digitalRead(keyPins[i]) == LOW;
    if (state == true && pressingStates[i] == false) {
      Keyboard.press(key);
      pressingStates[i] = true;
    } else if (state == false && pressingStates[i] == true) {
      Keyboard.release(key);
      pressingStates[i] = false;
    }
  }
  #endif
}
