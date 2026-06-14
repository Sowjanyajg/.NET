using System;
using System.Collections.Generic;

class Handstwo
{
    static void MainDisabled()
    {
        Console.Write("Enter the target number: ");
        int n = int.Parse(Console.ReadLine());

        Queue<int> q = new Queue<int>();
        Dictionary<int, int> steps = new Dictionary<int, int>();

        q.Enqueue(10);
        steps[10] = 0;

        while (q.Count > 0)
        {
            int current = q.Dequeue();

            if (current == n)
            {
                Console.WriteLine("Minimum Operations: " + steps[current]);
                return;
            }

            int[] nextNumbers = { current + 2, current - 1, current * 3 };

            foreach (int next in nextNumbers)
            {
                if (next >= 0 && next <= 100000 && !steps.ContainsKey(next))
                {
                    q.Enqueue(next);
                    steps[next] = steps[current] + 1;
                }
            }
        }
    }
}