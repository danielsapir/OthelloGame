using System;

namespace Ex05_Othelo
{
     public class Game
     {
          private Player m_Player1;
          private Player m_Player2;
          private Board m_Board;
          private bool m_IsVSComputer;
          private bool m_IsPlayer1Turn;
          private int m_Player1Points = 0;
          private int m_Player2Points = 0;

          public Board Board
          {
               get
               {
                    return m_Board;
               }
          }

          public Player Player1
          {
               get
               {
                    return m_Player1;
               }
          }

          public Player Player2
          {
               get
               {
                    return m_Player2;
               }
          }

          public bool IsPlayer1Turn
          {
               get
               {
                    return m_IsPlayer1Turn;
               }

               set
               {
                    m_IsPlayer1Turn = value;
               }
          }

          public bool IsVSComputer
          {
               get
               {
                    return m_IsVSComputer;
               }
          }

          public int Player1Points
          {
               get
               {
                    return m_Player1Points;
               }
          }

          public int Player2Points
          {
               get
               {
                    return m_Player2Points;
               }
          }

          public Game(int i_BoardSize, bool i_IsVSComputer)
          {
               m_Player1 = new Player("Black", 'X');
               m_Player2 = new Player("White", 'O');
               m_Board = new Board(i_BoardSize);
               m_IsVSComputer = i_IsVSComputer;
               m_IsPlayer1Turn = true;
               m_Player1.UpdatePossibleMovesArr(m_Player2.Coin, m_Board);
               m_Player2.UpdatePossibleMovesArr(m_Player1.Coin, m_Board);
          }

          public void PlayUserTurn(int i_Row, int i_Colum)
          {
               if (IsPlayer1Turn == true)
               {
                    PlayTurn(Player1, Player2, i_Row, i_Colum);
               }
               else
               {
                    PlayTurn(Player2, Player1, i_Row, i_Colum);
               }
          }

          public void PlayTurn(Player i_CurrentPlayer, Player i_RivalPlayer, int i_RowChossed, int i_ColumChoosed)
          {
               int rowForCoin = i_RowChossed;
               int columForCoin = i_ColumChoosed;

               if (i_CurrentPlayer.IsThereArePossibleMoves())
               {
                    if (m_IsVSComputer && !m_IsPlayer1Turn)
                    {
                         computerMove(out rowForCoin, out columForCoin);
                    }

                    m_Board.AddNewCoinToBoard(rowForCoin, columForCoin, i_CurrentPlayer.Coin, i_RivalPlayer.Coin);
                    m_Player1.UpdatePossibleMovesArr(m_Player2.Coin, m_Board);
                    m_Player2.UpdatePossibleMovesArr(m_Player1.Coin, m_Board);
               }

               m_IsPlayer1Turn = !m_IsPlayer1Turn;
          }

          private void computerMove(out int o_RowForCoin, out int o_ColumForCoin)
          {
               Random randomForGettingIndexOfMove = new Random();
               int indexOfComputerMoveFromPossibleMovesArr = randomForGettingIndexOfMove.Next(0, m_Player2.PossibleMovesArr.Count);
               o_RowForCoin = m_Player2.PossibleMovesArr[indexOfComputerMoveFromPossibleMovesArr].Row;
               o_ColumForCoin = m_Player2.PossibleMovesArr[indexOfComputerMoveFromPossibleMovesArr].Colum;
          }

          public Player GetCurrentPlayer()
          {
               Player currentPlayer;

               if(IsPlayer1Turn)
               {
                    currentPlayer = m_Player1;
               }
               else
               {
                    currentPlayer = m_Player2;
               }

               return currentPlayer;
          }

          public bool Player1DoesntHaveMoves()
          {
               return !m_Player1.IsThereArePossibleMoves();
          }

          public bool CheckIfPlayerCanPlayer()
          {
               if (IsPlayer1Turn)
               {
                    return Player1.IsThereArePossibleMoves();
               }
               else
               {
                    return Player2.IsThereArePossibleMoves();
               }
          }

          public bool GameIsOver()
          {
               return !Player1.IsThereArePossibleMoves() && !Player2.IsThereArePossibleMoves();
          }

          public void RestartGame()
          {
               m_Board.InitializeBoard();
               m_IsPlayer1Turn = true;
               m_Player1.UpdatePossibleMovesArr(m_Player2.Coin, m_Board);
               m_Player2.UpdatePossibleMovesArr(m_Player1.Coin, m_Board);
          }

          public Player GetTheGameWinner()
          {
               Player winner;

               if (m_Board.NumberOfX > m_Board.NumberOfO)
               {
                    m_Player1Points++;
                    winner = Player1;
               }
               else
               {
                    m_Player2Points++;
                    winner = Player2;
               }

               return winner;
          }
     }
}