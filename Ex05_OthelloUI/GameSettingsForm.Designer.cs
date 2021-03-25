namespace Ex05_OtheloUI
{
     public partial class GameSettingsForm
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
               this.buttonBoardSize = new System.Windows.Forms.Button();
               this.buttonPlayAgainstComputer = new System.Windows.Forms.Button();
               this.buttonPlayAgainstFrined = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // buttonBoardSize
               // 
               this.buttonBoardSize.Location = new System.Drawing.Point(10, 15);
               this.buttonBoardSize.Name = "buttonBoardSize";
               this.buttonBoardSize.Size = new System.Drawing.Size(275, 33);
               this.buttonBoardSize.TabIndex = 0;
               this.buttonBoardSize.Text = "Board size: 6X6 (click to increase)";
               this.buttonBoardSize.UseVisualStyleBackColor = true;
               this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoarsSize_Click);
               // 
               // buttonPlayAgainstComputer
               // 
               this.buttonPlayAgainstComputer.Location = new System.Drawing.Point(10, 54);
               this.buttonPlayAgainstComputer.Name = "buttonPlayAgainstComputer";
               this.buttonPlayAgainstComputer.Size = new System.Drawing.Size(134, 37);
               this.buttonPlayAgainstComputer.TabIndex = 2;
               this.buttonPlayAgainstComputer.Text = "Play against the computer";
               this.buttonPlayAgainstComputer.UseVisualStyleBackColor = true;
               this.buttonPlayAgainstComputer.Click += new System.EventHandler(this.buttonPlayAgainstComputer_Click);
               // 
               // buttonPlayAgainstFrined
               // 
               this.buttonPlayAgainstFrined.Location = new System.Drawing.Point(151, 54);
               this.buttonPlayAgainstFrined.Name = "buttonPlayAgainstFrined";
               this.buttonPlayAgainstFrined.Size = new System.Drawing.Size(134, 37);
               this.buttonPlayAgainstFrined.TabIndex = 3;
               this.buttonPlayAgainstFrined.Text = "Play against your firend";
               this.buttonPlayAgainstFrined.UseVisualStyleBackColor = true;
               this.buttonPlayAgainstFrined.Click += new System.EventHandler(this.buttonPlayAgainstFrined_Click);
               // 
               // GameSettingsForm
               // 
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
               this.ClientSize = new System.Drawing.Size(297, 108);
               this.Controls.Add(this.buttonPlayAgainstFrined);
               this.Controls.Add(this.buttonPlayAgainstComputer);
               this.Controls.Add(this.buttonBoardSize);
               this.ForeColor = System.Drawing.SystemColors.ControlText;
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "GameSettingsForm";
               this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Othello - Game Settings";
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Button buttonBoardSize;
          private System.Windows.Forms.Button buttonPlayAgainstComputer;
          private System.Windows.Forms.Button buttonPlayAgainstFrined;
     }
}