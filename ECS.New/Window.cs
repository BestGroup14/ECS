using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.New
{
    public class Window : IWindow
    {
        public void OpenWindow()
        {
            System.Console.WriteLine("Window is open");
        }

        public void CloseWindow()
        {
            System.Console.WriteLine("Window is closed");
        }
    }
}
