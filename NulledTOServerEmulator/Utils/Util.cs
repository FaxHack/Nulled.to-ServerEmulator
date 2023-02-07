using System.Diagnostics;

namespace NulledTOServerEmulator
{
    class Util
    {
        public static void Leave()
        {
            Program.Log("Press Enter To Stop Emulator", "LEAVE", ConsoleColor.Red);
            Console.ReadLine();
            Host.HostEditor.Remove();
            Process.GetCurrentProcess().Kill();
        }

        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string Logo = "\r\n  _   _       _ _          _   ____                            \r\n | \\ | |     | | |        | | |  _ \\                           \r\n |  \\| |_   _| | | ___  __| | | |_) |_   _ _ __   __ _ ___ ___ \r\n | . ` | | | | | |/ _ \\/ _` | |  _ <| | | | '_ \\ / _` / __/ __|\r\n | |\\  | |_| | | |  __/ (_| | | |_) | |_| | |_) | (_| \\__ \\__ \\\r\n |_| \\_|\\__,_|_|_|\\___|\\__,_| |____/ \\__, | .__/ \\__,_|___/___/\r\n                                      __/ | |                  \r\n                                     |___/|_|                  \r\n";
            Console.WriteLine(Logo);
            Console.ResetColor();
        }
    }
}
