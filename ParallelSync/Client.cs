namespace ParallelSync
{
    abstract class Client
    {
        public Client()
        {
            Execute();
        }
        public abstract void Execute();
    }
}