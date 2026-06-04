
using System;
using System.Collections.Generic;
/*class StudentPerformance
{
   
    static void Main(string[] args)
{
    Console.WriteLine("enter the number of students:");
    int count=Convert.ToInt32(Console.ReadLine());
    Dictionary<string,int> students=new Dictionary<string,int>();
    int marks;
    string name;
    for (int i = 0; i < count; i++)
        {
            Console.WriteLine("enter the name of student:");
            name=Console.ReadLine();
            Console.WriteLine("enter the marks of student:");
             marks=Convert.ToInt32(Console.ReadLine());

            if(marks > 100 || marks < 0)
            {
                Console.WriteLine("invalid marks, please enter a value between 0 and 100.");
                i--; 
                continue; 
            }  
            
            students.Add(name,marks);
        }
       foreach(KeyValuePair<String,int> student in students)
        {
            Console.WriteLine(student.Key+ ":" +student.Value);
        }
var topStudents = students.Where(s => s.Value > 80);
Console.WriteLine("students with marks greater than 80:" + String.Join(", ", topStudents.Select(s => s.Key)));
}}
*/