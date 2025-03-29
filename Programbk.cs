using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldPhonePadConsole
{
    class Programbk
    {
        static void Main(string[] args)
        {           

            Console.WriteLine("Press keys to type (like old mobile phones). Press # to finish.");           
            OldPhonePad();            

        }
        public static void OldPhonePad()
        {
            // Key mappings similar to old mobile keypads
            Dictionary<ConsoleKey, string> keyMappings = new Dictionary<ConsoleKey, string>
            {
                { ConsoleKey.D2, "ABC" },
                { ConsoleKey.D3, "DEF" },
                { ConsoleKey.D4, "GHI" },
                { ConsoleKey.D5, "JKL" },
                { ConsoleKey.D6, "MNO" },
                { ConsoleKey.D7, "PQRS" },
                { ConsoleKey.D8, "TUV" },
                { ConsoleKey.D9, "WXYZ" }

            };


            Dictionary<int, string> newkeyMappings = new Dictionary<int, string>
            {
                { 2, "ABC" },
                { 3, "DEF" },
                { 4, "GHI" },
                { 5, "JKL" },
                { 6, "MNO" },
                { 7, "PQRS" },
                { 8, "TUV" },
                { 9, "WXYZ" }

            };

            string result = "";
            string tempresult = "";
            string tempresult1 = "";
            string input = "";
            string letters = "";
            List<string> dynamicList = new List<string>();
            List<Dictionary<ConsoleKey, string>> listOfkey = new List<Dictionary<ConsoleKey, string>>();

            ConsoleKeyInfo lastKey = new ConsoleKeyInfo();
            int tapIndex = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                loop: ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: false);
                    //input += keyInfo.Key;

                    //if (keyMappings.ContainsKey(keyInfo.Key))
                    //{

                        if (!(keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift)))
                        {
                            //check if 1 and 2 array same , if yes , check third is same or space
                            //if same go index , if space restart to 0                           

                            if (keyInfo.Key == lastKey.Key)
                            {
                                if(stopwatch.ElapsedMilliseconds < 1000)
                                {
                                    dynamicList.Add(keyInfo.KeyChar.ToString());                                    
                                }
                                else
                                {
                                    dynamicList.Add(keyInfo.KeyChar.ToString());
                                    dynamicList.Add(" ");
                                }
                                lastKey = keyInfo;
                                goto loop;
                            }
                            else
                            {
                                dynamicList.Add(keyInfo.KeyChar.ToString());
                                lastKey = keyInfo;
                                goto loop;
                            }
                        if (keyInfo.Key == lastKey.Key)
                        {
                            //&& stopwatch.ElapsedMilliseconds < 1000
                            tapIndex = (tapIndex + 1) % letters.Length;
                            //tapIndex = letters.Length-1;
                            //result = result.TrimEnd() + letters[tapIndex];

                        }
                        else
                        {
                            tapIndex = 0;
                            result += " ";
                            //result = result.TrimEnd() + letters[tapIndex];
                        }
                        if (tapIndex > 0)
                            result = result.TrimEnd() + letters[tapIndex];

                        stopwatch.Restart();
                            lastKey = keyInfo;
                        }
                    //}
                   
                   


                    if (keyInfo.KeyChar == '#')
                    {
                        if(dynamicList.Count > 0)
                        {
                            
                            for (int i = 0;i < dynamicList.Count-1; i++)
                            {
                                if (dynamicList[i] == dynamicList[i + 1])
                                {

                                }
                                else
                                {
                                    letters = newkeyMappings[int.Parse(dynamicList[i])];
                                    
                                }
                            }
                        }
                        //Console.WriteLine(dynamicList[0].ToString());
                        //Console.WriteLine($"\n{letters.Length}");
                        
                        Console.WriteLine($"\nOldPhonePad({input}) => Output: {letters}");
                        
                         result = "";
                         tempresult = "";
                         tempresult1 = "";
                         input = "";
                        //break;
                        
                    }
                }


            }

        }
    }
}
