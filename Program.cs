using System;
using System.Collections;
using System.Collections.Generic;


var processList = new List<Process>
{
    new() { Name = "Process 1", Time = 10 },
    new() { Name = "Process 2", Time = 3 },
    new() { Name = "Process 3", Time = 2 },
    new() { Name = "Process 4", Time = 20 },
    new() { Name = "Process 5", Time = 8 },
    new() { Name = "Process 6", Time = 6 },
    new() { Name = "Process 7", Time = 5 }
};

RRQueue ar = new RRQueue(5, processList);
ar.Execute();


public class Process
{
    public string Name { get; set; }
    public int Time { get; set; }
}


public class RRQueue
{
    private int capacity;
    private Queue<Process> queueProcess;
    private List<Process> listProcess;

    public RRQueue(int capacity, List<Process> list)
    {
        this.capacity = capacity;
        queueProcess = new Queue<Process>(list);
    }
    
    public void Execute()
    {
        while (queueProcess.Count > 0)
        {
            //Remove and return the first element
            Process proc = queueProcess.Dequeue();

            if (proc.Time > capacity)
            {
                proc.Time -= capacity;

                //Add to end of queue
                queueProcess.Enqueue(proc);

                Console.WriteLine($"{proc.Name} run in {capacity} units");
            }
            else
            {
                Console.WriteLine($"{proc.Name} finish");
            }
        }
    }

}

