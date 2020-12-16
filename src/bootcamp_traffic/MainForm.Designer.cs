namespace Bootcamp.CompVis.Traffic
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.videoPlayer = new Accord.Controls.VideoSourcePlayer();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.useCameraCheckBox = new System.Windows.Forms.CheckBox();
            this.ChooseVideoFileButton = new System.Windows.Forms.Button();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.openVideoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // videoPlayer
            // 
            this.videoPlayer.Location = new System.Drawing.Point(18, 11);
            this.videoPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.Size = new System.Drawing.Size(913, 495);
            this.videoPlayer.TabIndex = 0;
            this.videoPlayer.Text = "videoSourcePlayer1";
            this.videoPlayer.VideoSource = null;
            this.videoPlayer.NewFrame += new Accord.Controls.VideoSourcePlayer.NewFrameHandler(this.videoPlayer_NewFrame);
            this.videoPlayer.Click += new System.EventHandler(this.videoPlayer_Click);
            // 
            // useCameraCheckBox
            // 
            this.useCameraCheckBox.AutoSize = true;
            this.useCameraCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.useCameraCheckBox.Location = new System.Drawing.Point(48, 524);
            this.useCameraCheckBox.Name = "useCameraCheckBox";
            this.useCameraCheckBox.Size = new System.Drawing.Size(122, 24);
            this.useCameraCheckBox.TabIndex = 1;
            this.useCameraCheckBox.Text = "Use camera";
            this.useCameraCheckBox.UseVisualStyleBackColor = true;
            this.useCameraCheckBox.CheckedChanged += new System.EventHandler(this.useCameraCheckBox_CheckedChanged);
            // 
            // ChooseVideoFileButton
            // 
            this.ChooseVideoFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChooseVideoFileButton.Location = new System.Drawing.Point(176, 519);
            this.ChooseVideoFileButton.Name = "ChooseVideoFileButton";
            this.ChooseVideoFileButton.Size = new System.Drawing.Size(192, 32);
            this.ChooseVideoFileButton.TabIndex = 2;
            this.ChooseVideoFileButton.Text = "Choose video file";
            this.ChooseVideoFileButton.UseVisualStyleBackColor = true;
            this.ChooseVideoFileButton.Click += new System.EventHandler(this.ChooseVideoFileButton_Click);
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilePathLabel.Location = new System.Drawing.Point(390, 525);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(75, 20);
            this.FilePathLabel.TabIndex = 3;
            this.FilePathLabel.Text = "File Path";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(703, 516);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(228, 32);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // openVideoFileDialog
            // 
            this.openVideoFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1012, 599);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.ChooseVideoFileButton);
            this.Controls.Add(this.useCameraCheckBox);
            this.Controls.Add(this.videoPlayer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Diploma project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Accord.Controls.VideoSourcePlayer videoPlayer;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.CheckBox useCameraCheckBox;
        private System.Windows.Forms.Button ChooseVideoFileButton;
        public System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.OpenFileDialog openVideoFileDialog;
    }
}

