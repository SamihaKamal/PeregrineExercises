namespace MovieRank.Services
{
    public interface ISetupService
    {
        Task CreatDynamoDbTable(string tablename);
        Task DeleteDynamoDbTable(string tablename);
    }
}
