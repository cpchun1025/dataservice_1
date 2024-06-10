using MY_WEB_APP.Models;

namespace MY_WEB_APP.Repositories
{
    public interface IDataRepository
    {
        // Raw Data Methods
        Task<IEnumerable<RawData>> GetAllRawDataAsync();
        Task<RawData> GetRawDataByIdAsync(int id);
        Task<RawData> AddRawDataAsync(RawData rawData);
        Task<RawData> UpdateRawDataAsync(RawData rawData);
        Task<bool> DeleteRawDataAsync(int id);

        // Transformed Data Methods
        Task<IEnumerable<TransformedData>> GetAllTransformedDataAsync();
        Task<TransformedData> GetTransformedDataByIdAsync(int id);
        Task<TransformedData> AddTransformedDataAsync(TransformedData transformedData);
        Task<TransformedData> UpdateTransformedDataAsync(TransformedData transformedData);
        Task<bool> DeleteTransformedDataAsync(int id);

        // Methods for specific data transformation requirements
        Task SaveTransformedDataAsync(TransformedData transformedData);
        Task<List<TransformedData>> GetTransformedDataAsync();
    }
}
