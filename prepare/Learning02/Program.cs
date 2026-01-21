using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2004;
        job1._endYear = 2009;

        Job job2 = new();
        job2._company = "Apple";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 1999;
        job2._endYear = 2004;

        Resume resume = new();
        resume._name = "Daniel Loveless";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        Console.Clear();
        resume.Display();
    }
}