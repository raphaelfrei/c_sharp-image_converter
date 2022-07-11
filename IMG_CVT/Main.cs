using System.Drawing.Imaging;

namespace IMG_CVT {
    public partial class Form1 : Form {

        FileDialog fds = new OpenFileDialog {
            Filter = "",
            Title = "Open Image"
        };

        public Form1() {
            InitializeComponent();

        }

        private void button1_Click_1(object sender, EventArgs e) {
            ImageCodecInfo[] imf = ImageCodecInfo.GetImageEncoders();

            fds.Filter = String.Format("All Files|*.*");

            fds.DefaultExt = "*.*";

            fds.ShowDialog();

            textBox1.Text = fds.FileName;
        }

        private void button3_Click(object sender, EventArgs e) {
            if(textBox1.Text == "") {
                MessageBox.Show("Please select a valid file.", "Invalid File");

                return;
            }

            SaveFileDialog fd = new SaveFileDialog {
                Filter = "PNG Image|*.png|JPEG Image|*.jpeg|ICON Image|*.ico",
                Title = "Save Image"
            };


            ImageCodecInfo[] imf = ImageCodecInfo.GetImageEncoders();

            fd.DefaultExt = ".png";

            fd.ShowDialog();

            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            try {
                if (fd.FileName != "") {
                    Bitmap bmp = new Bitmap(textBox1.Text);

                    FileStream fs = new FileStream(fd.FileName, FileMode.Create);

                    switch (fd.FilterIndex) {
                        case 1:
                            bmp.Save(fs, ImageFormat.Png);
                            break;

                        case 2:
                            bmp.Save(fs, ImageFormat.Jpeg);
                            break;

                        case 3:
                            bmp.Save(fs, ImageFormat.Icon);
                            break;

                    }

                    fs.Close();

                    MessageBox.Show("File converted successfully!", "Operation Complete");

                }

            }catch(Exception f) {
                MessageBox.Show($"An error has occurred: {(char)13}{f}");

            }
        }
    }
}