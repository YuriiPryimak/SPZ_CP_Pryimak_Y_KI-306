using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AudioControler
{
    public partial class Form1 : Form
    {
        private MMDeviceEnumerator devEnum;
        private MMDevice device;

        public Form1()
        {
            InitializeComponent();
            devEnum = new MMDeviceEnumerator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                volumeControl1.Value = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                volumeControl1.ValueChanged += volumeControl1_ValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing audio device: " + ex.Message);
            }
        }

        private void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateVolumeControl(data.MasterVolume)));
            }
            else
            {
                UpdateVolumeControl(data.MasterVolume);
            }
        }

        private void UpdateVolumeControl(float volume)
        {
            if (volumeControl1 != null && !volumeControl1.IsDisposed)
            {
                volumeControl1.Value = (int)(volume * 100);
            }
        }

        private void volumeControl1_ValueChanged(object sender, EventArgs e)
        {
            if (device != null)
            {
                device.AudioEndpointVolume.MasterVolumeLevelScalar = volumeControl1.Value / 100.0f;
                lbl_volume.Text = "Volume : " + volumeControl1.Value.ToString() + "%";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_volume.Text = "Volume : " + volumeControl1.Value.ToString() + "%";
        }
    }
}
