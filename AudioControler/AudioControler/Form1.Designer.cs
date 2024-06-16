
namespace AudioControler
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (device != null)
                {
                    device.AudioEndpointVolume.OnVolumeNotification -= AudioEndpointVolume_OnVolumeNotification;
                    device.Dispose();
                    device = null;
                }

                if (devEnum != null)
                {
                    devEnum.Dispose();
                    devEnum = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            volumeControl1 = new VolumeControl();
            lbl_volume = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            prg_Name = new Label();
            SuspendLayout();
            // 
            // volumeControl1
            // 
            volumeControl1.BackColor = Color.Black;
            volumeControl1.Bar_color = Color.Aqua;
            volumeControl1.Location = new Point(45, 222);
            volumeControl1.Max = 100;
            volumeControl1.Min = 0;
            volumeControl1.Name = "volumeControl1";
            volumeControl1.Size = new Size(438, 38);
            volumeControl1.TabIndex = 0;
            volumeControl1.Value = 40;
            volumeControl1.ValueChanged += volumeControl1_ValueChanged;
            // 
            // lbl_volume
            // 
            lbl_volume.AutoSize = true;
            lbl_volume.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbl_volume.Location = new Point(45, 191);
            lbl_volume.Name = "lbl_volume";
            lbl_volume.Size = new Size(135, 28);
            lbl_volume.TabIndex = 1;
            lbl_volume.Text = "Volume: 40%";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // prg_Name
            // 
            prg_Name.AutoSize = true;
            prg_Name.Font = new Font("Broadway", 25.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prg_Name.Location = new Point(117, 65);
            prg_Name.Name = "prg_Name";
            prg_Name.Size = new Size(297, 47);
            prg_Name.TabIndex = 2;
            prg_Name.Text = "ClearSound";
            prg_Name.Click += prg_Name_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 290);
            Controls.Add(prg_Name);
            Controls.Add(lbl_volume);
            Controls.Add(volumeControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AudioController";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void prg_Name_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private VolumeControl volumeControl1;
        private Label lbl_volume;
        private System.Windows.Forms.Timer timer1;
        private Label prg_Name;
    }
}
