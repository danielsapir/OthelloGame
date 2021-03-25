namespace Ex05_Othelo
{
     public struct PositionPoint
     {
          private int m_Row;
          private int m_Colum;

          public PositionPoint(int i_Row, int i_Colum)
          {
               m_Row = i_Row;
               m_Colum = i_Colum;
          }
          
          public int Row
          {
               get
               {
                    return m_Row;
               }
          }

          public int Colum
          {
               get
               {
                    return m_Colum;
               }
          }
     }
}
