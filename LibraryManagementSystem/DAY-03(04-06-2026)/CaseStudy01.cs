using System;

class handsone
{
    static void MainDisabled()
    {
        Console.Write("Enter marks for Type 1 question (X): ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter marks for Type 2 question (Y): ");
        int y = int.Parse(Console.ReadLine());

        Console.Write("Enter number of Type 1 questions (N1): ");
        int n1 = int.Parse(Console.ReadLine());

        Console.Write("Enter number of Type 2 questions (N2): ");
        int n2 = int.Parse(Console.ReadLine());

        Console.Write("Enter student's total marks (M): ");
        int m = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = n1; i >= 0; i--)
        {
            for (int j = 0; j <= n2; j++)
            {
                int total = (i * x) + (j * y);

                if (total == m)
                {
                    Console.WriteLine("\nValid");
                    Console.WriteLine("Marks from Type 1 Questions: " + (i * x));
                    Console.WriteLine("Marks from Type 2 Questions: " + (j * y));

                    found = true;
                    break;
                }
            }

            if (found)
                break;
        }

        if (!found)
        {
            Console.WriteLine("\nInvalid");
        }
    }
}