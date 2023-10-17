using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Utils
{
    public class GameMode
    {
        public GameModeType Mode = 0;
        public GameModeType SetGameMode()
        {
            Console.WriteLine("choose _game Mode:\n[0 -> AI vs PLayer\n 1 -> Human vs Human]");
            //InputManager inputManager = new (Console.ReadLine());
            var input = 0;
            switch(input)
            {
                case 0:
                    return GameModeType.HumanVsHuman;
                case 1:
                    return GameModeType.AI;
                default: return GameModeType.HumanVsHuman;
            }
            
        }
    }
    public enum GameModeType
    {
        AI,
        HumanVsHuman,
    }
}
