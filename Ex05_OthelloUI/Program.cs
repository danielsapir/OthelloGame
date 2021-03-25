using System.Windows.Forms;

namespace Ex05_OtheloUI
{
     public static class Program
     {
          public static void Main()
          {
               Application.EnableVisualStyles();

               WindowsUI windows = new WindowsUI();
               windows.PlayGame();
          }               
     }
}
