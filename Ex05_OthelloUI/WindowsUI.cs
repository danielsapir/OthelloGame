using System;
using System.Windows.Forms;
using Ex05_Othelo;

namespace Ex05_OtheloUI
{
     public class WindowsUI
     {
          private Game m_OthelloGame;
          private GameSettingsForm m_GameSettingsForm = new GameSettingsForm();
          private BoardForm m_BoardForm;

          public void PlayGame()
          {
               m_GameSettingsForm.ShowDialog();
               if(m_GameSettingsForm.DialogResult == DialogResult.OK)
               {
                    m_OthelloGame = new Game(m_GameSettingsForm.BoardSize, m_GameSettingsForm.IsVSComputer);
                    m_BoardForm = new BoardForm(m_GameSettingsForm.BoardSize, this);
                    Start();
               }
               else
               {
                    Application.Exit();
               }
          }

          public void BoardButtons_Click(object sender, EventArgs e)
          {
               for (int i = 1; i <= m_OthelloGame.Board.Size; i++)
               {
                    for (int j = 1; j <= m_OthelloGame.Board.Size; j++)
                    {
                         if ((sender as Button) == m_BoardForm.BoardButtons[i, j])
                         {
                              m_OthelloGame.PlayUserTurn(i, j);
                         }
                    }
               }

               if (m_OthelloGame.IsVSComputer)
               {
                    playComputerTurn();
               }

               if (!m_OthelloGame.CheckIfPlayerCanPlayer())
               {
                    m_OthelloGame.IsPlayer1Turn = !m_OthelloGame.IsPlayer1Turn;
               }

               if(m_OthelloGame.GameIsOver())
               {
                    m_BoardForm.DialogResult = DialogResult.OK;
               }

               m_BoardForm.UpdateBoard(m_OthelloGame);
          }

          private void playComputerTurn()
          {
               bool computerHasAnotherTurn = true;

               while (computerHasAnotherTurn)
               {
                    m_BoardForm.Text = "Othello - Computer's turn";
                    System.Threading.Thread.Sleep(500);
                    m_OthelloGame.PlayTurn(m_OthelloGame.Player2, m_OthelloGame.Player1, 0, 0);
                    m_BoardForm.UpdateBoard(m_OthelloGame);
                    computerHasAnotherTurn = m_OthelloGame.Player1DoesntHaveMoves();
                    if (m_OthelloGame.GameIsOver())
                    {
                         break;
                    }
               }
          }

          public void Start()
          {
               DialogResult dialogResult;

               do
               {
                    m_OthelloGame.RestartGame();
                    m_BoardForm.UpdateBoard(m_OthelloGame);
                    m_BoardForm.ShowDialog();
                    if (m_BoardForm.DialogResult == DialogResult.OK)
                    {
                         string winnerName = m_OthelloGame.GetTheGameWinner().Name;
                         int numberOfX = m_OthelloGame.Board.NumberOfX;
                         int numberOfO = m_OthelloGame.Board.NumberOfO;
                         int player1Points = m_OthelloGame.Player1Points;
                         int player2Points = m_OthelloGame.Player2Points;
                         string winningMsg = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})\nWould you like another round?", winnerName, numberOfX, numberOfO, player1Points, player2Points);

                         dialogResult = MessageBox.Show(winningMsg, "Othello", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                    else
                    {
                         dialogResult = DialogResult.Cancel;
                    }
               }
               while (dialogResult == DialogResult.Yes);
          }
     }
}
