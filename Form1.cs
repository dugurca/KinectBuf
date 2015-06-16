using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using KinectBuf.Properties;

namespace KinectBuf
{
	public partial class Form1 : Form
	{
		public static string FilePath = "";

		public Form1()
		{
			InitializeComponent();
			textBox1.ReadOnly = true;
			textBox2.ReadOnly = true;
			button2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var diagResult =  openFileDialog1.ShowDialog();
			var fileName = openFileDialog1.FileName;

			if (diagResult == DialogResult.OK)
			{
				FilePath = fileName;
				textBox1.Text = fileName;

				if (Path.GetExtension(FilePath) != ".xml")
				{
					textBox2.Text = Resources.Form1_button1_Click_File_doesn_t_have_xml_extension_;
					textBox2.Text += " File extension is: " + Path.GetExtension(FilePath);
					button2.Enabled = false;
					return;
				}
				button2.Enabled = true;
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			const string frameName = "KinectSkeletalAnimation";
			if (textBox1.Text == null)
			{
				textBox2.Text = Resources.Form1_button2_Click_File_path_is_null;
				return;
			}
			var frames = XmlReader.GetKinect1Frames(textBox1.Text, frameName);

			Kinect1Contract kinect1Contract = new Kinect1Contract(frames);

			string fileName = Path.GetFileNameWithoutExtension(FilePath);
			kinect1Contract.Serialize(fileName + ".bin");

			textBox2.Text = Resources.Form1_button2_Click_Binary_file_created_succesfully_;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			
		}
	}
}
