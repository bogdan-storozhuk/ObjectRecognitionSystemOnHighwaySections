using Accord.Video.FFMPEG;
using Accord.Video.DirectShow;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Imaging.Filters;
using System.Collections.Generic;
using Accord.Vision.Tracking;
using Alturos.Yolo;
using System.IO;
using Alturos.Yolo.Model;
using System.Threading;

namespace Bootcamp.CompVis.Traffic
{
    public partial class MainForm : Form
    {
        private YoloWrapper _yoloWrapper;

        private bool _useCamera = false;
        private string _filePath;

        public MainForm()
        {
            InitializeComponent();
        }

    
        private void SetCamera()
        {
  
            var deviceName = (from d in new FilterInfoCollection(FilterCategory.VideoInputDevice)
                              select d).FirstOrDefault();
            var captureDevice = new VideoCaptureDevice(deviceName.MonikerString);

 
            captureDevice.VideoResolution = (from r in captureDevice.VideoCapabilities
                                             where r.FrameSize.Width == 1280
                                             select r).First();

            videoPlayer.VideoSource = captureDevice;
        }

       
        private void SetVideo(string fileName)
        {
            var source = new VideoFileSource(fileName);
            videoPlayer.VideoSource = source;
        }

        private void DrawLabel(Bitmap frame, YoloItem item)
        {
            using (Graphics g = Graphics.FromImage(frame))
            {
                string name = item.Type;
                Font fnt = new Font("Verdana", 50, GraphicsUnit.Pixel);
                Brush brs = new SolidBrush(Color.DarkOrange);
                var stringSize = g.MeasureString(name, fnt);
                g.DrawRectangle(new Pen(Color.CornflowerBlue, 3), item.X, item.Y, item.Width, item.Height);

                
                g.DrawString(name, fnt, brs, item.X, item.Y + 10);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            /*Initialize(".");
            if (USE_CAMERA)
                SetCamera();
            else
                SetVideo("./input.mp4");

            // start the player
            videoPlayer.Start();*/
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            videoPlayer.Stop();
            _yoloWrapper?.Dispose();
        }


        private void Initialize(string path)
        {
            var configurationDetector = new YoloConfigurationDetector();
            try
            {
                var config = configurationDetector.Detect(path);
                if (config == null)
                {
                    return;
                }

                this.Initialize(config);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Cannot found a valid dataset {exception}", "No Dataset available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Initialize(YoloConfiguration config)
        {
            try
            {
                if (this._yoloWrapper != null)
                {
                    this._yoloWrapper.Dispose();
                }

                var gpuConfig = new GpuConfig();
                var useOnlyCpu = false;
                if (useOnlyCpu)
                {
                    gpuConfig = null;
                }

                this._yoloWrapper = new YoloWrapper(config.ConfigFile, config.WeightsFile, config.NamesFile, gpuConfig);
            

                var action = new MethodInvoker(delegate ()
                {
                    var deviceName = this._yoloWrapper.GetGraphicDeviceName(gpuConfig);
                   
                });

           
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{nameof(Initialize)} - {exception}", "Error Initialize", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void videoPlayer_NewFrame(object sender, ref Bitmap frame)
        {

            using (var stream = new MemoryStream())
            {
                frame.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                var detectedObjects = _yoloWrapper.Detect(stream.ToArray()).ToList();
                if (detectedObjects.Count == 0)
                {
                    return; 
                }
                var outputFrame = frame.Clone() as Bitmap;
                detectedObjects
                    .ForEach(t => DrawLabel(outputFrame, t));
                frame = outputFrame;
            }
            
        }

        private void useCameraCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useCameraCheckBox.Checked)
            {
                _useCamera = true;
                ChooseVideoFileButton.Visible = false;
                FilePathLabel.Visible = false;
                StartButton.Visible = true;
            }
            else
            {
                _useCamera = false;
                ChooseVideoFileButton.Visible = true;
                FilePathLabel.Visible = true;
                StartButton.Visible = false;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _yoloWrapper?.Dispose();
            Initialize(".");

            if (_useCamera)
                SetCamera();
            else
                SetVideo(_filePath);

          //  StartButton.Visible = false;
           // useCameraCheckBox.Visible = false;
            videoPlayer.Start();
        }

        private void ChooseVideoFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openVideoFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                var filePath = openVideoFileDialog.FileName;
                var fileName = Path.GetFileName(filePath);
                FilePathLabel.Text = fileName;
                _filePath = filePath;
                StartButton.Visible = true;
            }
            else
            {
                MessageBox.Show("File was not selected");
                FilePathLabel.Text = String.Empty;
                StartButton.Visible = false;
            }
        }

        private void videoPlayer_Click(object sender, EventArgs e)
        {

        }
    }
}
