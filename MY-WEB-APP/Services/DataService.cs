using MY_WEB_APP.Models;
using MY_WEB_APP.Repositories;

namespace MY_WEB_APP.Services
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;
        private readonly IDataTransformationService _dataTransformationService;

        public DataService(IDataRepository dataRepository, IDataTransformationService dataTransformationService)
        {
            _dataRepository = dataRepository;
            _dataTransformationService = dataTransformationService;
        }

        // Raw Data Methods
        public async Task<IEnumerable<RawData>> GetAllRawDataAsync()
        {
            return await _dataRepository.GetAllRawDataAsync();
        }

        public async Task<RawData> GetRawDataByIdAsync(int id)
        {
            return await _dataRepository.GetRawDataByIdAsync(id);
        }

        public async Task<RawData> AddRawDataAsync(RawData rawData)
        {
            return await _dataRepository.AddRawDataAsync(rawData);
        }

        public async Task<RawData> UpdateRawDataAsync(RawData rawData)
        {
            return await _dataRepository.UpdateRawDataAsync(rawData);
        }

        public async Task<bool> DeleteRawDataAsync(int id)
        {
            return await _dataRepository.DeleteRawDataAsync(id);
        }

        // Transformed Data Methods
        public async Task<IEnumerable<TransformedData>> GetAllTransformedDataAsync()
        {
            return await _dataRepository.GetAllTransformedDataAsync();
        }

        public async Task<TransformedData> GetTransformedDataByIdAsync(int id)
        {
            return await _dataRepository.GetTransformedDataByIdAsync(id);
        }

        public async Task<TransformedData> AddTransformedDataAsync(TransformedData transformedData)
        {
            return await _dataRepository.AddTransformedDataAsync(transformedData);
        }

        public async Task<TransformedData> UpdateTransformedDataAsync(TransformedData transformedData)
        {
            return await _dataRepository.UpdateTransformedDataAsync(transformedData);
        }

        public async Task<bool> DeleteTransformedDataAsync(int id)
        {
            return await _dataRepository.DeleteTransformedDataAsync(id);
        }

        
        public async Task TransformAndSaveDataAsync(RawData rawData)
        {
            // Transform the raw data
            var transformedData = await _dataTransformationService.TransformDataAsync(rawData);

            // Save the transformed data to the database
            await _dataRepository.SaveTransformedDataAsync(transformedData);
        }

        public async Task<List<TransformedData>> GetTransformedDataAsync()
        {
            // Retrieve the transformed data from the database
            return await _dataRepository.GetTransformedDataAsync();
        }
    }
}
