using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NulledTOServerEmulator.Host
{
    internal class HostEditor
    {
        const string Path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        const string Match = "127.0.0.1 www.nulled.to";

        public static bool Edit()
        {
            try
            {
                foreach (var item in File.ReadLines(Path))
                {
                    if (item == Match)
                    {
                        return true;
                    }
                }
                File.AppendAllText(Path, $"\n{Match}\n");
                return true;
            }
            catch (Exception ex)
            {
                Program.Log($"Could not edit/read Hosts File. Please try running Server Emulator with Administrator Perms.\nError: {ex.Message}", "ERROR", ConsoleColor.Red);
                return false;
            }
        }

        public static void Remove()
        {
            try
            {
                var lines = File.ReadLines(Path).Where(l => l != Match).ToList();
                File.WriteAllLines(Path, lines);
            }
            catch (Exception ex)
            {
                Program.Log($"Could not remove from Hosts File.\nError: {ex.Message}", "ERROR", ConsoleColor.Red);
            }
        }
    }
}
