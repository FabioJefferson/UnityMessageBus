using AI_TictacToe_logic.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Scripts.Nantenaina.Data
{
    public class GameStateHandler
    {
        public GameState State = new(3,null,null);
        private static GameStateHandler _instance = new();

        public GameStateHandler( GameState state )
        { 
            State = state;
            _instance.State = state;
        }
        public GameStateHandler()
        {

        }

        public static GameStateHandler GetInstance()
        {
           
                return _instance;
            
        }

    }
}
