using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePadConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press keys to type (like old mobile phones). Press # to finish.");
            OldPhonePad();

        }
        public static void OldPhonePad()
        {
            ConsoleKeyInfo lastKey = new ConsoleKeyInfo();            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Key mappings similar to old mobile keypads
            Dictionary<ConsoleKey, string> keyMappings = new Dictionary<ConsoleKey, string>
            {
                { ConsoleKey.D1, "&'()" }, // special character
                { ConsoleKey.D2, "ABC" },
                { ConsoleKey.D3, "DEF" },
                { ConsoleKey.D4, "GHI" },
                { ConsoleKey.D5, "JKL" },
                { ConsoleKey.D6, "MNO" },
                { ConsoleKey.D7, "PQRS" },
                { ConsoleKey.D8, "TUV" },
                { ConsoleKey.D9, "WXYZ" },
                { ConsoleKey.D0, " " } //space 


            };
            string result = "";
            //string tempresult = "";
            int tapIndex = 1;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    
                loop:  ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);
                    
                    string letters = "";
                    if (keyMappings.ContainsKey(keyInfo.Key))
                    {
                        if (!(keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift)))
                        {
                           
                            letters = keyMappings[keyInfo.Key];

                            if (keyInfo.Key == lastKey.Key && stopwatch.ElapsedMilliseconds < 1000)
                            {

                                tapIndex = (tapIndex + 1) % letters.Length;
                                
                            }
                            else
                            {
                                                    
                                tapIndex = 0;  // Reset to the first letter if the key is different or after timeout                          

                            }

                            if (tapIndex > 0)
                            {

                                if (result.Length > 0)
                                {
                                    result = result.Remove(result.Length - 1) + letters[tapIndex].ToString();
                                }
                                else
                                {

                                    result = letters[tapIndex].ToString();
                                }

                            }
                            else
                            {
                                result = result + letters[tapIndex].ToString();
                            }

                            lastKey = keyInfo;

                            stopwatch.Restart();

                        }
                    }

                    if (keyInfo.KeyChar == '#')
                    {

                        Console.WriteLine($"\nFinal Output: {result}");
                        
                        result = ""; //clear the prev result
                        
                        goto loop;
                    }

                }
            }
        
        }
    }
}
