using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FixHomoglyphs
{
    class Program
    {
        static void Main(string[] args)
        {
            string backslash = @"\";
            var EditFileName = @"names-result.txt";
            string value = Console.ReadLine();
            string[] array = new string[] {};
            
             array = value.Split(' ');
             var FilePath = (array[0]);

            //This is necessary if the user doesn't do a space after dragging a file in command prompt
            //Otherwise it causes an index out of exception
            if(array.Length == 1)
            {
                Array.Resize(ref array, array.Length + 1);
                array[1] = "";
            }
            
            var EditedFile = (array[1]);
            //If the user does a space and its empty, or if whats right above happens.
            //This would grab the directory that the file is being used to change
            //the homoglyphs to normal characters.
            if (array[1] == "")
            {
                EditedFile = "" + Path.GetDirectoryName(FilePath);
            }
            //This is necessary if you decide to have the edited file be created in C:\
            //Otherwise when placed in a folder there isn't a backslash.
            if (!EditedFile.EndsWith(backslash))
            {
                EditedFile += @"\";
            }

            using (var fixedFile = new StreamWriter($"{EditedFile}" + $"{EditFileName}"))
            {
                List<string> records = File.ReadAllLines($"{FilePath}", Encoding.GetEncoding(1252)).ToList();
                Decipher name = new Decipher();
                string correctFormatName = "";

                foreach (string NextLine in records)
                {
                    correctFormatName = name.ConvertString(NextLine);
                    fixedFile.WriteLine(correctFormatName);
                }
            }
        }
        class Decipher
        {
            Dictionary<char, char> homoglyphs = new Dictionary<char, char>();
            public Decipher()
            {
                homoglyphs.Add('Ä', 'A');
                homoglyphs.Add('Å', 'A');
                homoglyphs.Add('Á', 'A');
                homoglyphs.Add('Â', 'A');
                homoglyphs.Add('À', 'A');
                homoglyphs.Add('Ã', 'A');
                homoglyphs.Add('â', 'a');
                homoglyphs.Add('ä', 'a');
                homoglyphs.Add('à', 'a');
                homoglyphs.Add('å', 'a');
                homoglyphs.Add('á', 'a');
                homoglyphs.Add('ã', 'a');
                homoglyphs.Add('ß', 'B');
                homoglyphs.Add('þ', 'b');
                homoglyphs.Add('Þ', 'b');
                homoglyphs.Add('Ç', 'C');
                homoglyphs.Add('ç', 'c');
                homoglyphs.Add('Ð', 'D');
                homoglyphs.Add('É', 'E');
                homoglyphs.Add('Ê', 'E');
                homoglyphs.Add('Ë', 'E');
                homoglyphs.Add('È', 'E');
                homoglyphs.Add('é', 'e');
                homoglyphs.Add('ê', 'e');
                homoglyphs.Add('ë', 'e');
                homoglyphs.Add('è', 'e');
                homoglyphs.Add('ƒ', 'f');
                homoglyphs.Add('Í', 'I');
                homoglyphs.Add('Î', 'I');
                homoglyphs.Add('Ï', 'I');
                homoglyphs.Add('ï', 'i');
                homoglyphs.Add('î', 'i');
                homoglyphs.Add('ì', 'i');
                homoglyphs.Add('í', 'i');
                homoglyphs.Add('ı', 'i');
                homoglyphs.Add('Ñ', 'N');
                homoglyphs.Add('ñ', 'n');
                homoglyphs.Add('Ö', 'O');
                homoglyphs.Add('Ó', 'O');
                homoglyphs.Add('Ô', 'O');
                homoglyphs.Add('Ò', 'O');
                homoglyphs.Add('Õ', 'O');
                homoglyphs.Add('ô', 'o');
                homoglyphs.Add('ö', 'o');
                homoglyphs.Add('ò', 'o');
                homoglyphs.Add('ó', 'o');
                homoglyphs.Add('ø', 'o');
                homoglyphs.Add('ð', 'o');
                homoglyphs.Add('õ', 'o');
                homoglyphs.Add('Ü', 'U');
                homoglyphs.Add('Ú', 'U');
                homoglyphs.Add('Û', 'U');
                homoglyphs.Add('Ù', 'U');
                homoglyphs.Add('ü', 'u');
                homoglyphs.Add('û', 'u');
                homoglyphs.Add('ù', 'u');
                homoglyphs.Add('ú', 'u');
                homoglyphs.Add('µ', 'u');
                homoglyphs.Add('Ý', 'Y');
                homoglyphs.Add('ÿ', 'y');
                homoglyphs.Add('ý', 'y');
                homoglyphs.Add('Ø', '0');
            }
            public string ConvertString(string input)
            {
                string output = "";
                foreach (var letter in input)
                {
                    if (homoglyphs.ContainsKey(letter))
                    {
                        output += homoglyphs[letter];
                    }
                    else
                    {
                        output += letter;
                    }
                }
                return output;
            }
        }
    }
}       




