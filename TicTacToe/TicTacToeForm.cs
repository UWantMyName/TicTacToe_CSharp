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
		bool XTurn = true;
		string generalPath = Directory.GetCurrentDirectory();
		string XPath;
		string OPath;
		string winner = "";
		Button[,] ButtonGrid = new Button[3, 3];
		public TicTacToeForm()
		{
			InitializeComponent();
			InitializeBoard();
		}

		/// <summary>
		/// Sets paths for the image for X and the image for O. It places each of the 9 buttons in a 3 x 3 matrix.
		/// </summary>
		private void InitializeBoard()
		{
			for (int i = 0; i < generalPath.Length - 9; i++)
			{
				XPath += generalPath[i];
				OPath += generalPath[i];
			}

			XPath += "X.png";
			OPath += "0.png";


			ButtonGrid[0, 0] = AA;
			ButtonGrid[0, 1] = AB;
			ButtonGrid[0, 2] = AC;

			ButtonGrid[1, 0] = BA;
			ButtonGrid[1, 1] = BB;
			ButtonGrid[1, 2] = BC;

			ButtonGrid[2, 0] = CA;
			ButtonGrid[2, 1] = CB;
			ButtonGrid[2, 2] = CC;
		}

		/// <summary>
		/// Makes the button's background image an X or O depending on whose turn it is.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonClick(object sender, EventArgs e)
		{
			Button b = sender as Button;

			if (!b.Enabled) return;

			if (XTurn)
			{
				b.BackgroundImage = Image.FromFile(XPath);
				b.Text = "X";
				b.TextAlign = ContentAlignment.TopCenter;
			}

			else
			{
				b.BackgroundImage = Image.FromFile(OPath);
				b.Text = "0";
				b.TextAlign = ContentAlignment.MiddleCenter;
			}

			b.BackgroundImageLayout = ImageLayout.Stretch;


			b.Enabled = false;
			XTurn = !XTurn;
			
			if (Check())
			{
				string message;

				if (winner == "-")
				{
					message = "Game was a draw.";
				}

				else
				{
					message = "This game was won by " + winner + ".";
				}

				MessageBox.Show(message);
				DisableAllButtons();
			}
		}

		/// <summary>
		///  Checks the diagonals, rows and columns of the 3 x 3 matrix for '000' and 'XXX'.
		/// </summary>
		/// <returns></returns>
		private bool Check()
		{
			bool GameFinished = false;
			string result = "";

			// Horizontal

			for (int j = 0; j < 3 && !GameFinished; j++)
			{
				result = "";

				for (int i = 0; i < 3; i++)
				{
					result += ButtonGrid[i, j].Text;
				}

				if (result == "000" || result == "XXX")
				{
					GameFinished = true;
					winner = result[0].ToString();
				}
			}

			// Vertical

			for (int j = 0; j < 3 && !GameFinished; j++)
			{
				result = "";

				for (int i = 0; i < 3; i++)
				{
					result += ButtonGrid[j, i].Text;
				}

				if (result == "000" || result == "XXX")
				{
					GameFinished = true;
					winner = result[0].ToString();
				}
			}

			// Primary Diagonal
			result = "";
			result += ButtonGrid[0, 0].Text + ButtonGrid[1, 1].Text + ButtonGrid[2, 2].Text;

			
			if (result == "000" || result == "XXX")
			{
				GameFinished = true;
				winner = result[0].ToString();
			}



			// Secondary Diagonal
			result = "";
			result += ButtonGrid[0, 2].Text + ButtonGrid[1, 1].Text + ButtonGrid[2, 0].Text;


			if (result == "000" || result == "XXX")
			{
				GameFinished = true;
				winner = result[0].ToString();
			}

			// Checking for Draw

			bool full = true;

			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
				{
					if (ButtonGrid[i, j].Text == "") full = false;
				}


			if (!GameFinished && full)
			{
				GameFinished = true;
				winner = "-";
			}

			return GameFinished;

		}

		/// <summary>
		/// Makes all buttons disabled.
		/// </summary>
		private void DisableAllButtons()
		{
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					ButtonGrid[i, j].Enabled = false;
		}
	}
}