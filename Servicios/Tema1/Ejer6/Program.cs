class Program
{
    static int counter = 0;
    static void increment()
    {
        counter++;
        Console.WriteLine(counter);
    }
    static void Main(string[] args)
    {
        MyTimer t = new MyTimer(increment);
        t.interval = 1000;
        string op = "";
        do
        {
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            t.run();
            Console.WriteLine("Press any key to pause.");
            Console.ReadKey();
            t.pause();
            Console.WriteLine("Press 1 to restart or Enter to end.");
            op = Console.ReadLine();
        } while (op == "1");
    }
}

class MyTimer
{
    static readonly private object k = new object();
    public delegate void MyDelegate();
    bool working = false;

    private int INTERVAL;
    public int interval
    {
        set => INTERVAL = value;
        get => INTERVAL;
    }

    private void loop(Object function)
    {
        do
        {
            lock (k)
            {
                if (!working)
                {

                    Monitor.Wait(k);
                }

                // while (working)

                ((MyDelegate)function)();
                Thread.Sleep(interval);


            }
        } while (working);
    }
    public void run()
    {
        lock (k)
        {
            working = true;
            Monitor.Pulse(k);
        }
    }

    public void pause()
    {
        lock (k)
            working = false;
    }
    public MyTimer(MyDelegate function)
    {
        interval = 1000;
        Thread hilo = new Thread(loop);
        hilo.IsBackground = true;
        hilo.Start(function);
    }
}