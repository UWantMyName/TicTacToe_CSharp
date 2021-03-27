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
		bool XWon = true;
		Button[,] Grid = new Button[3, 3];
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
			
			if (Check())
			{
				string message = "Game Over! Tis game was won by ";
				if (XWon) message += "X.";
				else message += "O.";
			}
		}

		public bool Check()
		{
			MessageBox.Show("Checking.");

			for (int i = 0; i < 3; i++)
			{
				// Check Rows
				if (Grid[i, 0].Text == Grid[i, 1].Text && Grid[i, 1].Text == Grid[i, 2].Text)
				{
					if (Grid[i, 0].BackgroundImage == Image.FromFile(XPath)) MessageBox.Show("[" + i.ToString() + ", 0] is X");

					else if (Grid[i, 0].BackgroundImage == Image.FromFile(OPath)) XWon = false;
					if (Grid[i, 0].BackgroundImage != null) return true;
				}

				// Check Columns
				if (Grid[0, i].Text == Grid[1, i].Text && Grid[1, i].Text == Grid[2, i].Text)
				{
					if (Grid[0, i].BackgroundImage == Image.FromFile(XPath)) MessageBox.Show("[0, " + i.ToString() + "] is X");
					else if (Grid[0, i].BackgroundImage == Image.FromFile(OPath)) XWon = false;
					if (Grid[0, i].BackgroundImage != null) return true;
				}

				// Check Diagonals
				if (Grid[0, 0].Text == Grid[1, 1].Text && Grid[1, 1].Text == Grid[2, 2].Text)
				{
					if (Grid[1, 1].BackgroundImage == Image.FromFile(XPath)) MessageBox.Show("[1, 1] is X");
					else if (Grid[1, 1].BackgroundImage == Image.FromFile(OPath)) XWon = false;
					if (Grid[1, 1].BackgroundImage != null) return true;
				}

				if (Grid[2, 0].Text == Grid[1, 1].Text && Grid[1, 1].Text == Grid[0, 2].Text)
				{
					if (Grid[1, 1].BackgroundImage == Image.FromFile(XPath)) MessageBox.Show("[1, 1] is X");
					else if (Grid[1, 1].BackgroundImage == Image.FromFile(OPath)) XWon = false;
					if (Grid[1, 1].BackgroundImage != null) return true;
				}
			}

			return false;


		}
	}
}
