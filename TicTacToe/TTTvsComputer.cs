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
	public partial class TTTvsComputer : Form
	{
		bool X = true;
		string generalPath = Directory.GetCurrentDirectory();
		string XPath;
		string OPath;
		string winner = "";
		Button[,] Grid = new Button[3, 3];
		public TTTvsComputer()
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

			if (X && b.Enabled)
			{
				b.BackgroundImage = Image.FromFile(XPath);
				b.Text = "X";
				b.TextAlign = ContentAlignment.TopCenter;


				b.BackgroundImageLayout = ImageLayout.Stretch;


				b.Enabled = false;
				X = !X;

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

				else ComputerTurn();
			}
		}

		public bool Check()
		{
			bool GameFinished = false;
			string result = "";

			// Horizontal

			for (int j = 0; j < 3 && !GameFinished; j++)
			{
				result = "";

				for (int i = 0; i < 3; i++)
				{
					result += Grid[i, j].Text;
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
					result += Grid[j, i].Text;
				}

				if (result == "000" || result == "XXX")
				{
					GameFinished = true;
					winner = result[0].ToString();
				}
			}

			// Primary Diagonal
			result = "";
			result += Grid[0, 0].Text + Grid[1, 1].Text + Grid[2, 2].Text;


			if (result == "000" || result == "XXX")
			{
				GameFinished = true;
				winner = result[0].ToString();
			}



			// Secondary Diagonal
			result = "";
			result += Grid[0, 2].Text + Grid[1, 1].Text + Grid[2, 0].Text;


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
					if (Grid[i, j].Text == "") full = false;
				}


			if (!GameFinished && full)
			{
				GameFinished = true;
				winner = "-";
			}

			return GameFinished;

		}

		private void ComputerTurn()
		{
			List<Button> enabled = new List<Button>();

			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
				{
					if (Grid[i, j].Enabled) enabled.Add(Grid[i, j]);
				}


			Random rnd = new Random();
			int index = rnd.Next(enabled.Count);

			Button b = enabled[index];

			b.BackgroundImage = Image.FromFile(OPath);
			b.Text = "0";
			b.TextAlign = ContentAlignment.MiddleCenter;
			b.BackgroundImageLayout = ImageLayout.Stretch;
			b.Enabled = false;

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

			X = !X;

		}
		public void DisableAllButtons()
		{
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					Grid[i, j].Enabled = false;
		}
	}
}