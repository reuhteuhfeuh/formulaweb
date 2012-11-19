using System;

namespace XNA_FormulaWeb
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FormulaWeb game = new FormulaWeb())
            {
                game.Run();
            }
        }
    }
#endif
}

