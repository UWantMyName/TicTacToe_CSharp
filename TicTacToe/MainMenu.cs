using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class MainMenu : Form
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void PlayWithAnotherButton_Click(object sender, EventArgs e)
		{
			ComputerTicTacToeForm form = new ComputerTicTacToeForm();
			form.Show();
		}

		private void PlayWithComputerButton_Click(object sender, EventArgs e)
		{
			TicTacToeForm form = new TicTacToeForm();
			form.Show();
		}

		private void ExitGameButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
