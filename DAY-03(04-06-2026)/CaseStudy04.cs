using System;
using System.Text;

class HandsFour
{
    static void MainDisabled()
    {
        Console.Write("Enter first word: ");
        string word1 = Console.ReadLine();

        Console.Write("Enter second word: ");
        string word2 = Console.ReadLine();

        string vowels = "aeiouAEIOU";
        StringBuilder temp = new StringBuilder();

        // Remove common consonants
        foreach (char ch in word1)
        {
            bool isVowel = vowels.Contains(ch);

            if (isVowel)
            {
                temp.Append(ch);
            }
            else
            {
                bool found = false;

                foreach (char c in word2)
                {
                    if (char.ToLower(ch) == char.ToLower(c))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    temp.Append(ch);
            }
        }

        // Remove consecutive duplicate characters
        StringBuilder result = new StringBuilder();

        if (temp.Length > 0)
        {
            result.Append(temp[0]);

            for (int i = 1; i < temp.Length; i++)
            {
                if (char.ToLower(temp[i]) != char.ToLower(temp[i - 1]))
                {
                    result.Append(temp[i]);
                }
            }
        }

        Console.WriteLine("Final String: " + result);
    }
}