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
		private bool PlayerTurn = true;
		private bool SidePicked = false;

		private string generalPath = Directory.GetCurrentDirectory();
		private string side;
		private string XPath;
		private string OPath;
		private string winner = "";

		private Button[,] ButtonGrid = new Button[3, 3];
		public TTTvsComputer()
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
		/// Makes the button's background image an X or O if clicked by user, side is picked and it is not computer's turn.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonClick(object sender, EventArgs e)
		{
			if (!SidePicked) return;

			Button b = sender as Button;

			if (PlayerTurn && b.Enabled)
			{
				if (side == "X")
				{
					b.BackgroundImage = Image.FromFile(XPath);
					b.Text = "X";
				}

				else
				{
					b.BackgroundImage = Image.FromFile(OPath);
					b.Text = "0";
				}

				b.TextAlign = ContentAlignment.TopCenter;
				b.BackgroundImageLayout = ImageLayout.Stretch;


				b.Enabled = false;
				PlayerTurn = !PlayerTurn;

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
		
		/// <summary>
		/// Checks the diagonals, rows and columns of the 3 x 3 matrix for '000' and 'XXX'.
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
		/// Makes the computer put the opposite image on any random available square.
		/// </summary>
		private void ComputerTurn()
		{
			List<Button> enabled = new List<Button>();

			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
				{
					if (ButtonGrid[i, j].Enabled) enabled.Add(ButtonGrid[i, j]);
				}


			Random rnd = new Random();
			int index = rnd.Next(enabled.Count);

			Button b = enabled[index];

			if (side == "O")
			{
				b.BackgroundImage = Image.FromFile(XPath);
				b.Text = "X";
			}

			else
			{
				b.BackgroundImage = Image.FromFile(OPath);
				b.Text = "0";
			}

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

			PlayerTurn = !PlayerTurn;

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
		
		/// <summary>
		/// Method that sets the symbol for the current player (and the opposite for the CPU).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SetPlayer(object sender, EventArgs e)
		{
			Button b = sender as Button;

			b.BackColor = Color.AliceBlue;
			side = b.Text[b.Text.Length - 1].ToString();

			AsX.Enabled = false;
			AsO.Enabled = false;

			SidePicked = true;
			
			if( side == "O")
			{
				PlayerTurn = false;
				ComputerTurn();
			}

		}
	}
}