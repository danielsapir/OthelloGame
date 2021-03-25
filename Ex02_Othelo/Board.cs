namespace Ex05_Othelo
{
     public class Board
     {
          private int m_Size;
          private char[,] m_BoardMatrix;
          private int m_NumberOfX = 0;
          private int m_NumberOfO = 0;

          public int Size
          {
               get
               {
                    return m_Size;
               }         
          }

          public char[,] BoardMatrix
          {
               get
               {
                    return m_BoardMatrix;
               }
          }

          public int NumberOfX
          {
               get
               {
                    CountNumberOfXAndO();
                    return m_NumberOfX;
               }
          }

          public int NumberOfO
          {
               get
               {
                    CountNumberOfXAndO();
                    return m_NumberOfO;
               }
          }

          public Board(int i_Size)
          {
               m_Size = i_Size;
               m_BoardMatrix = new char[m_Size + 1, m_Size + 1];
               InitializeBoard();
          }   

          public void InitializeBoard()
          {
               int middleOfBoardUpLeft = m_Size / 2;
               int middleOfBoardDownRight = (m_Size / 2) + 1;

               for (int i = 0; i <= m_Size; i++)
               {
                    for (int j = 0; j <= m_Size; j++)
                    {
                         m_BoardMatrix[i, j] = '\0';
                    }
               }

               m_BoardMatrix[middleOfBoardUpLeft, middleOfBoardUpLeft] = 'O';
               m_BoardMatrix[middleOfBoardUpLeft, middleOfBoardDownRight] = 'X';
               m_BoardMatrix[middleOfBoardDownRight, middleOfBoardUpLeft] = 'X';
               m_BoardMatrix[middleOfBoardDownRight, middleOfBoardDownRight] = 'O';
          }

          public bool IsInTheBoardBorders(int i_Row, int i_Colum)
          {
               return (i_Row <= m_Size) && (i_Row >= 1) && (i_Colum <= m_Size) && (i_Colum >= 1);
          }

          public void AddNewCoinToBoard(int i_Row, int i_Colum, char i_Coin, char i_RivalCoin)
          {
               const int k_RightDirection = 1;
               const int k_LeftDirection = -1;
               const int k_DownDirection = 1;
               const int k_UpDirection = -1;
               const int k_NoMoveOnDirection = 0;

               m_BoardMatrix[i_Row, i_Colum] = i_Coin;
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_NoMoveOnDirection, k_RightDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_NoMoveOnDirection, k_LeftDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_DownDirection, k_NoMoveOnDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_UpDirection, k_NoMoveOnDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_DownDirection, k_RightDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_UpDirection, k_RightDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_DownDirection, k_LeftDirection);
               updateBoardAfterAddingNewCoin(i_Row, i_Colum, i_Coin, i_RivalCoin, k_UpDirection, k_LeftDirection);               
          }

          private void updateBoardAfterAddingNewCoin(int i_Row, int i_Colum, char i_Coin, char i_RivalCoin, int i_UpOrDown, int i_LeftOrRight)
          {
               int stepWalkerRightOrLeft = i_LeftOrRight;
               int stepWalkerUpOrDown = i_UpOrDown;

               if (IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
               {
                    if (m_BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_RivalCoin)
                    {
                         while (m_BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_RivalCoin) 
                         {
                              stepWalkerRightOrLeft += i_LeftOrRight;
                              stepWalkerUpOrDown += i_UpOrDown;
                              if (!IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
                              {
                                   break;
                              }
                         }

                         if (IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
                         {
                              if (m_BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_Coin)
                              {                                   
                                   flipCoins(i_Row, i_Colum, i_Coin, i_RivalCoin, i_UpOrDown, i_LeftOrRight);
                              }
                         }
                    }
               }
          }

          private void flipCoins(int i_Row, int i_Colum, char i_Coin, char i_RivalCoin, int i_UpOrDown, int i_LeftOrRight)
          {
               int stepWalkerRightOrLeft = i_LeftOrRight;
               int stepWalkerUpOrDown = i_UpOrDown;

               while (m_BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] == i_RivalCoin)
               {
                    m_BoardMatrix[i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft] = i_Coin;
                    stepWalkerRightOrLeft += i_LeftOrRight;
                    stepWalkerUpOrDown += i_UpOrDown;
                    if (!IsInTheBoardBorders(i_Row + stepWalkerUpOrDown, i_Colum + stepWalkerRightOrLeft))
                    {
                         break;
                    }
               }
          }
                   
          public void CountNumberOfXAndO()
          {
               m_NumberOfO = 0;
               m_NumberOfX = 0;

               foreach(char currentCell in m_BoardMatrix)
               {
                    if (currentCell == 'X')
                    {
                         m_NumberOfX++;
                    }
                    else if (currentCell == 'O')
                    {
                         m_NumberOfO++;
                    }
               }
          }
     }
}
