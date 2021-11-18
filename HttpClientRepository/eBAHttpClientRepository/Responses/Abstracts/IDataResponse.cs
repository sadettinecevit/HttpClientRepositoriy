namespace eBAHttpClientRepository.Responses.Abstracts
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
    }
}
