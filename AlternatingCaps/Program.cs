using System;
using System.IO;

namespace AlternatingCaps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int counter = 1;                                                        //Declaring a Counter
                string outputsatz = "", inputsatz;                                      //Declaring two Stings
                if (!File.Exists("input.txt"))                                          //lookin if the input.txt exists if not creating one
                {
                    StreamWriter sw = File.CreateText("input.txt");
                    Console.WriteLine("Created Input.txt pls put your Text in there!\r\n\r\nThen press Enter!");
                    sw.Close();
                    Console.ReadLine();
                }
                StreamReader sr = new StreamReader("input.txt");                        //New Streamreader from input.txt
                while (sr.EndOfStream == false)                                         //while loop wich ends the programm if there is no new line to read
                {
                    inputsatz = sr.ReadLine().ToString();                               //reading one line of the input.txt and saving it in one of the strings
                    foreach (char c in inputsatz)                                       //getting every letter in the string
                    {
                        string s = c.ToString();                                        //converting the char into a string
                        if (counter % 2 != 0)                                           //deciding based on if the counter is odd or even if you write the letter upper or lower case
                        {
                            s = s.ToUpper();                                            //setting to uppercase
                            outputsatz += s;                                            //adding the uppercase letter to the output string
                            counter++;                                                  //adding one to the counter
                        }
                        else
                        {
                            s = s.ToLower();                                            //setting to lowercase
                            outputsatz += s;                                            //adding the lowercase letter to the output string
                            counter++;                                                  //adding one to the counter
                        }
                    }
                    outputsatz += "\r\n";                                               //adding a line break at the end of the string
                    if (!File.Exists("output.txt"))                                     //looking if the output.txt exist if not creating one
                    {
                        StreamWriter sw = File.CreateText("output.txt");
                        sw.WriteLine(outputsatz);
                        sw.Close();
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter("output.txt"))        //declaring a new Streamwriter for output.txt
                        {
                            sw.WriteLine(outputsatz);                                   //using the Streamwriter to write the line in the output.txt file
                        }
                    }
                }
            }
            catch (Exception e)                                                         //try catch if there is a problem
            {
                Console.WriteLine("There was a Problem :( : " + e.Message);
            }
        }
    }
}