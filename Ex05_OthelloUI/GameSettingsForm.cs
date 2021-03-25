using System;
using System.Windows.Forms;

namespace Ex05_OtheloUI
{
     public partial class GameSettingsForm : Form
     {
          private const int k_MinBoardSize = 6;
          private const int k_MaxBoardSize = 12;
          private const int k_BoardSizeChangeFactor = 2;
          private int m_BoardSize = k_MinBoardSize;
          private bool m_IsVSComputer;

          public GameSettingsForm()
          {
               InitializeComponent();
          }

          public int BoardSize
          {
               get
               {
                    return m_BoardSize;
               }
          }

          public bool IsVSComputer
          {
               get
               {
                    return m_IsVSComputer;
               }
          }

          public int BoardMinSize
          {
               get
               {
                    return k_MinBoardSize;
               }
          }

          private void buttonBoarsSize_Click(object i_Sender, EventArgs i_EventArgs)
          {
               if(m_BoardSize != k_MaxBoardSize)
               {
                    m_BoardSize += k_BoardSizeChangeFactor;
               }
               else
               {
                    m_BoardSize = k_MinBoardSize;
               }

               buttonBoardSize.Text = string.Format("Board Size: {0}x{0} (click to increase)", m_BoardSize);
          }

          private void buttonPlayAgainstComputer_Click(object i_Sender, EventArgs i_EventArgs)
          {
               m_IsVSComputer = true;
               DialogResult = DialogResult.OK;
          }

          private void buttonPlayAgainstFrined_Click(object sender, EventArgs e)
          {
               m_IsVSComputer = false;
               DialogResult = DialogResult.OK;
          }
     }
}
