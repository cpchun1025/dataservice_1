using MY_WEB_APP.Models;

namespace MY_WEB_APP.Services
{
    public interface IDataService
    {
        Task<IEnumerable<RawData>> GetAllRawDataAsync();
        Task<RawData> GetRawDataByIdAsync(int id);
        Task<RawData> AddRawDataAsync(RawData rawData);
        Task<RawData> UpdateRawDataAsync(RawData rawData);
        Task<bool> DeleteRawDataAsync(int id);

        Task<IEnumerable<TransformedData>> GetAllTransformedDataAsync();
        Task<TransformedData> GetTransformedDataByIdAsync(int id);
        Task<TransformedData> AddTransformedDataAsync(TransformedData transformedData);
        Task<TransformedData> UpdateTransformedDataAsync(TransformedData transformedData);
        Task<bool> DeleteTransformedDataAsync(int id);

        Task TransformAndSaveDataAsync(RawData rawData);
        Task<List<TransformedData>> GetTransformedDataAsync();
    }
}
