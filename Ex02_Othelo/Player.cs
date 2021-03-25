using System.Collections.Generic;

namespace Ex05_Othelo
{
     public class Player
     {
          private string m_Name;
          private char m_Coin;
          private List<PositionPoint> m_PossibleMovesArr;

          public Player(string i_Name, char i_Coin)
          {
               m_Name = i_Name;
               m_Coin = i_Coin;
               m_PossibleMovesArr = new List<PositionPoint>();
          }

          public string Name
          {
               get
               {
                    return m_Name;
               }
          }

          public char Coin
          {
               get
               {
                    return m_Coin;
               }
          }

          public List<PositionPoint> PossibleMovesArr
          {
               get
               {
                    return m_PossibleMovesArr;
               }
          }

          public void UpdatePossibleMovesArr(char i_RivalCoin, Board i_Board)
          {
               m_PossibleMovesArr.Clear();
               for (int i = 1; i <= i_Board.Size; i++)
               {
                    for (int j = 1; j <= i_Board.Size; j++)
                    {
                         if (i_Board.BoardMatrix[i, j] == m_Coin) 
                         {
                              findPossibleMovesForThisCell(i, j, i_RivalCoin, i_Board);
                         }
                    }
               }
          }

          private void findPossibleMovesForThisCell(int i_Row, int i_Colum, char i_RivalCoin, Board i_Board)
          {
               const int k_RightDirection = 1;
               const int k_LeftDirection = -1;
               const int k_DownDirection = 1;
               const int k_UpDirection = -1;
               const int k_NoMoveOnDirection = 0;               

               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_NoMoveOnDirection, k_RightDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_NoMoveOnDirection, k_LeftDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_DownDirection, k_NoMoveOnDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_UpDirection, k_NoMoveOnDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_DownDirection, k_RightDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_UpDirection, k_RightDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_DownDirection, k_LeftDirection);
               searchForPossibleMoveInSpecificDirection(i_Row, i_Colum, i_RivalCoin, i_Board, k_UpDirection, k_LeftDirection);
          }

          private void searchForPossibleMoveInSpecificDirection(int i_Row, int i_Colum, char i_RivalCoin, Board i_Board, int i_UpOrDown, int i_LeftOrRight)
          {
               int stepWalkerRightOrLeft = i_LeftOrRight;
               int stepWalkerUpOrDown = i_UpOrDown;

               if (i_Board.IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
               {
                    if (i_Board.BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_RivalCoin)
                    {
                         while (i_Board.BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_RivalCoin)
                         {
                              stepWalkerRightOrLeft += i_LeftOrRight;
                              stepWalkerUpOrDown += i_UpOrDown;
                              if (!i_Board.IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
                              {
                                   break;
                              }
                         }

                         if (i_Board.IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
                         {
                              if (i_Board.BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == '\0')
                              {
                                   m_PossibleMovesArr.Add(new PositionPoint(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft));
                              }
                         }
                    }
               }
          }
          
          public bool IsLegalMove(int i_Row, int i_Colum)
          {
               bool isLegal = false;
               PositionPoint pointForChecking = new PositionPoint(i_Row, i_Colum);

               foreach(PositionPoint currentPossobleMove in m_PossibleMovesArr)
               {
                    if(currentPossobleMove.Equals(pointForChecking))
                    {
                         isLegal = true;
                    }
               }

               return isLegal;
          }

         public bool IsThereArePossibleMoves()
         {               
               return m_PossibleMovesArr.Count > 0;
         }
     }
}
