using System;

class HandsThree
{
    static void MainDisabled()
    {
        Console.Write("Enter substring length: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter the string: ");
        string str = Console.ReadLine();

        if (n > str.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }

        bool lucky = false;

        for (int i = 0; i <= str.Length - n; i++)
        {
            string sub = str.Substring(i, n);

            bool validChars = true;

            foreach (char ch in sub)
            {
                if (ch != 'P' && ch != 'S' && ch != 'G')
                {
                    validChars = false;
                    break;
                }
            }

            if (validChars)
            {
                int count = 1;

                for (int j = 1; j < sub.Length; j++)
                {
                    if (sub[j] == sub[j - 1])
                    {
                        count++;

                        if (count >= n / 2)
                        {
                            lucky = true;
                            break;
                        }
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }

            if (lucky)
                break;
        }

        if (lucky)
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");
    }
}