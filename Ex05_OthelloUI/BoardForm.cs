using System.Windows.Forms;
using System.Drawing;
using Ex05_Othelo;

namespace Ex05_OtheloUI
{
     public class BoardForm : Form
     {
          private const int k_ButtonSize = 50;
          private Button[,] m_BoardButtons;

          public Button[,] BoardButtons
          {
               get
               {
                    return m_BoardButtons;
               }
          }

          public BoardForm(int i_BoardSize, WindowsUI i_WindowsUI)
          {
               FormBorderStyle = FormBorderStyle.FixedSingle;
               MaximizeBox = false;
               MinimizeBox = false;
               SizeGripStyle = SizeGripStyle.Hide;
               StartPosition = FormStartPosition.CenterScreen;
               ClientSize = new Size((i_BoardSize * k_ButtonSize) + 20, (i_BoardSize * k_ButtonSize) + 20);
               m_BoardButtons = new Button[i_BoardSize + 1, i_BoardSize + 1];
               InitializeComponent(i_BoardSize, i_WindowsUI);
          }

          public void InitializeComponent(int i_BoardSize, WindowsUI i_WindowsUI)
          {
               for (int i = 1; i <= i_BoardSize; i++)
               {
                    for (int j = 1; j <= i_BoardSize; j++)
                    {
                         m_BoardButtons[i, j] = new Button();
                         m_BoardButtons[i, j].Left = ((j - 1) * k_ButtonSize) + 10;
                         m_BoardButtons[i, j].Top = ((i - 1) * k_ButtonSize) + 10;
                         m_BoardButtons[i, j].Size = new Size(k_ButtonSize, k_ButtonSize);
                         m_BoardButtons[i, j].Visible = true;
                         m_BoardButtons[i, j].Enabled = false;
                         m_BoardButtons[i, j].UseVisualStyleBackColor = true;
                         m_BoardButtons[i, j].Click += i_WindowsUI.BoardButtons_Click;
                         Controls.Add(m_BoardButtons[i, j]);
                    }
               }
          }

          public void UpdateBoard(Game i_OthelloGame)
          {
               for (int i = 1; i <= i_OthelloGame.Board.Size; i++)
               {
                    for (int j = 1; j <= i_OthelloGame.Board.Size; j++)
                    {
                         m_BoardButtons[i, j].Enabled = false;
                         m_BoardButtons[i, j].BackColor = Color.Gray;
                         m_BoardButtons[i, j].Text = string.Empty;
                         if (i_OthelloGame.Board.BoardMatrix[i, j] == 'X')
                         {
                              m_BoardButtons[i, j].BackColor = Color.Black;
                              m_BoardButtons[i, j].Text = "O";
                         }
                         else if (i_OthelloGame.Board.BoardMatrix[i, j] == 'O')
                         {
                              m_BoardButtons[i, j].BackColor = Color.White;
                              m_BoardButtons[i, j].Text = "O";
                         }
                    }
               }

               updateBoardPossibleMoves(i_OthelloGame);
          }

          private void updateBoardPossibleMoves(Game i_OthelloGame)
          {
               Player currentPlayer = i_OthelloGame.GetCurrentPlayer();

               Text = string.Format("Othello - {0}'s Turn", currentPlayer.Name);
               foreach (PositionPoint positionPoint in currentPlayer.PossibleMovesArr)
               {
                    m_BoardButtons[positionPoint.Row, positionPoint.Colum].BackColor = Color.Green;
                    m_BoardButtons[positionPoint.Row, positionPoint.Colum].Enabled = true;
               }
          }
     }
}
