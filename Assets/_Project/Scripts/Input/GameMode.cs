using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace input
{
    public class GameMode
    {
        public int Mode = 0;
        public  int SetGameMode()
        {
            Console.WriteLine("choose game Mode:\n[0 -> AI vs PLayer\n 1 -> Human vs Human]");
            InputManager inputManager = new (Console.ReadLine());
            this.Mode = inputManager.InputResult;
            return this.Mode;
        }
    }
}
