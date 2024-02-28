# SPZ_CP_Pryimak_Y_KI-306

КП з предмету Системне програмне забезпечення
на тему "Розробка програмного забезпечення для керування звуковими
пристроями. Розробка програми, що дозволяє керувати параметрами звукових
пристроїв та виконувати різні дії з їх управлінням."

1)Зчитування доступних звукових пристроїв:
void readAvailableDevices();

2)Відображення інформації про кожен звуковий пристрій:
void displayDeviceInfo(DeviceInfo device);

3)Зміна гучності звукових пристроїв:
void setVolume(DeviceInfo device, int volume);

4)Вибір активного виведення звуку на зовнішні пристрої:
void setActiveOutput(DeviceInfo device);

5)Встановлення еквалайзера для налаштування звучання:
void setEqualizerSettings(DeviceInfo device, EqualizerSettings settings);

6)Керування відтворенням звуку:
void playAudio(DeviceInfo device, AudioFile file);
void pauseAudio(DeviceInfo device);
void stopAudio(DeviceInfo device);

7)Налаштування звукових ефектів:
void setAudioEffects(DeviceInfo device, AudioEffects effects);

8)Управління записом звуку:
void startRecording(DeviceInfo device);
void pauseRecording(DeviceInfo device);
void stopRecording(DeviceInfo device);

9)Визначення вхідного аудіопотоку для обробки:
void setInputSource(DeviceInfo device, InputSource source);

10)Збереження налаштувань звукових пристроїв:
void saveSettings(DeviceInfo device, Settings settings);
