using System;
using System.Collections.Generic;

namespace EncryptionBreaker
{
    class Program
    {
        //Make a function that takes in an encrypted string 
        //If the character is special (if it is a space, exclamation mark or anything that is not a letter, ignore it)
        //return a List<string> which represents all of the possible decryptions of the string'
        static string possibleDecryption(int jump, string encryption)
        {
            string decryption = "";
            foreach (char maybeLetter in encryption)
            {
                bool isLetterUppercase = maybeLetter >= 'A' && maybeLetter <= 'Z';
                bool isLetterLowercase = maybeLetter >= 'a' && maybeLetter <= 'z';
                bool isLetter = isLetterUppercase || isLetterLowercase;


                if (isLetter)
                {
                    char subtractMeThenAddMeBack = isLetterUppercase ? 'A' : 'a';

                    decryption += (char)((maybeLetter - subtractMeThenAddMeBack  + jump) % 26 + subtractMeThenAddMeBack);
                }
                else
                {
                    decryption += maybeLetter;
                }

            }
            return decryption;
        }

        static void Main(string[] args)
        {
            List<string> PossibleDecryptions = new List<string>();
            Console.WriteLine("Enter in a encryption where only each letter is shifted by x amount");
            string encryption = Console.ReadLine();
            for (int i = 0; i < 25; i++)
            {
                PossibleDecryptions.Add(possibleDecryption(i + 1, encryption));
            }
            foreach(var decryption in PossibleDecryptions)
            {
                var words = decryption.Split(' ');
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (var word in words)
                {
                    string checkWword = word.ToLower();
                    if(!checkWword.Contains('a') && !checkWword.Contains('e') && !checkWword.Contains('i') && !checkWword.Contains('o') && !checkWword.Contains('u') && !checkWword.Contains('y'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                }

                Console.WriteLine(decryption);
            }

            Console.ResetColor();
        }
    }
}
/*using System.Linq;
using System;
public class C {
    static void Main() {
        var sentence = "B pxgm mh max fhobxl pbma fr ykbxgwl";
        //var sentence = "T hpye ez esp xzgtpd htes xj qctpyod";        
        //var sentence = "I went to the movies with my friends";
        var result = sentence.Replace(" ", "")
                             .GroupBy(c => c)
                             .OrderBy(g => g.Count())
                             .ToDictionary(g => g.Key, g => g.Count());
        
        
        var words = sentence.Split(' ');
        foreach(var word in words)
        {
            Console.WriteLine(word);
        }
        
        foreach(var kvp in result)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
        
        Console.WriteLine(sentence.Replace(" ", "").Length);
        
    }
}
 */