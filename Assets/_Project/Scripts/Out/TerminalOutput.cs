using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Out
{
    public class TerminalOutput : IMessageOutput
    {
        public void Display(string message)
        {
            if(message !=  null)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("tsisy ry ty a");
            }     
        }
    }
}
