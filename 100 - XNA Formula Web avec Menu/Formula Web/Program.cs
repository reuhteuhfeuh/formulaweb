using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaWeb
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (MenuFormulaWeb game = new MenuFormulaWeb())
                game.Run();
        }
    }
#endif
}
