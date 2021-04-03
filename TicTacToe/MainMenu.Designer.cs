﻿
namespace TicTacToe
{
	partial class MainMenu
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
			this.ExitGameButton = new System.Windows.Forms.Button();
			this.PlayWithComputerButton = new System.Windows.Forms.Button();
			this.PlayWithAnotherButton = new System.Windows.Forms.Button();
			this.TicTacToeTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ExitGameButton
			// 
			this.ExitGameButton.BackColor = System.Drawing.Color.White;
			this.ExitGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExitGameButton.Location = new System.Drawing.Point(12, 321);
			this.ExitGameButton.Name = "ExitGameButton";
			this.ExitGameButton.Size = new System.Drawing.Size(360, 28);
			this.ExitGameButton.TabIndex = 0;
			this.ExitGameButton.Text = "EXIT GAME";
			this.ExitGameButton.UseVisualStyleBackColor = false;
			this.ExitGameButton.Click += new System.EventHandler(this.ExitGameButton_Click);
			// 
			// PlayWithComputerButton
			// 
			this.PlayWithComputerButton.BackColor = System.Drawing.Color.White;
			this.PlayWithComputerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayWithComputerButton.Location = new System.Drawing.Point(12, 287);
			this.PlayWithComputerButton.Name = "PlayWithComputerButton";
			this.PlayWithComputerButton.Size = new System.Drawing.Size(360, 28);
			this.PlayWithComputerButton.TabIndex = 1;
			this.PlayWithComputerButton.Text = "Play With Computer";
			this.PlayWithComputerButton.UseVisualStyleBackColor = false;
			this.PlayWithComputerButton.Click += new System.EventHandler(this.PlayWithComputerButton_Click);
			// 
			// PlayWithAnotherButton
			// 
			this.PlayWithAnotherButton.BackColor = System.Drawing.Color.White;
			this.PlayWithAnotherButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayWithAnotherButton.Location = new System.Drawing.Point(12, 253);
			this.PlayWithAnotherButton.Name = "PlayWithAnotherButton";
			this.PlayWithAnotherButton.Size = new System.Drawing.Size(360, 28);
			this.PlayWithAnotherButton.TabIndex = 2;
			this.PlayWithAnotherButton.Text = "Play With 2nd Player";
			this.PlayWithAnotherButton.UseVisualStyleBackColor = false;
			this.PlayWithAnotherButton.Click += new System.EventHandler(this.PlayWithAnotherButton_Click);
			// 
			// TicTacToeTitle
			// 
			this.TicTacToeTitle.AutoSize = true;
			this.TicTacToeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TicTacToeTitle.Location = new System.Drawing.Point(92, 21);
			this.TicTacToeTitle.Name = "TicTacToeTitle";
			this.TicTacToeTitle.Size = new System.Drawing.Size(199, 39);
			this.TicTacToeTitle.TabIndex = 14;
			this.TicTacToeTitle.Text = "Tic Tac Toe";
			this.TicTacToeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(384, 361);
			this.Controls.Add(this.TicTacToeTitle);
			this.Controls.Add(this.PlayWithAnotherButton);
			this.Controls.Add(this.PlayWithComputerButton);
			this.Controls.Add(this.ExitGameButton);
			this.ForeColor = System.Drawing.Color.Black;
			this.Name = "MainMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tic Tac Toe";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ExitGameButton;
		private System.Windows.Forms.Button PlayWithComputerButton;
		private System.Windows.Forms.Button PlayWithAnotherButton;
		private System.Windows.Forms.Label TicTacToeTitle;
	}
}