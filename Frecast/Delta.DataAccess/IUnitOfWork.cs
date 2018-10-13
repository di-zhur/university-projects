namespace Delta.DataAccess
{
    public interface IUnitOfWork
    {
        IRepository<Frecast> FrecastRepository { get; }

        IRepository<FrecastData> FrecastDataRepository { get; }

        IRepository<FrecastError> FrecastErrorRepository { get; }

        IRepository<FrecastParameters> FrecastParametersRepository { get; }

        IRepository<FrecastResult> FrecastResultRepository { get; }

        IRepository<FrecastState> FrecastStateRepository { get; }

        IQueryDatabase QueryDatabase { get; }

        void Dispose();
    }
}
