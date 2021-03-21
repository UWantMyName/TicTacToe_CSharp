using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class TicTacToeForm : Form
	{
		bool X = true;
		string generalPath = Directory.GetCurrentDirectory();
		string XPath;
		string OPath;
		Button[ , ] Grid = new Button[3, 3];
		public TicTacToeForm()
		{
			InitializeComponent();

			for (int i = 0; i < generalPath.Length - 9; i++)
			{
				XPath += generalPath[i];
				OPath += generalPath[i];
			}

			XPath += "X.png";
			OPath += "0.png";


			Grid[0, 0] = AA;
			Grid[0, 1] = AB;
			Grid[0, 2] = AC;

			Grid[1, 0] = BA;
			Grid[1, 1] = BB;
			Grid[1, 2] = BC;

			Grid[2, 0] = CA;
			Grid[2, 1] = CB;
			Grid[2, 2] = CC;
		}

		public void ButtonClick(object sender, EventArgs e)
		{
			Button b = sender as Button;

			if (!b.Enabled) return;
			if (X) b.BackgroundImage = Image.FromFile(XPath);
			else b.BackgroundImage = Image.FromFile(OPath);

			b.BackgroundImageLayout = ImageLayout.Stretch;

			b.Enabled = false;
			X = !X;

			Check();
		}

		public void Check()
		{

		}

	}
}
