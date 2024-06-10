using MY_WEB_APP.Models;

namespace MY_WEB_APP.Services
{
    public interface IDataTransformationService
    {
        Task<TransformedData> TransformDataAsync(RawData rawData);
    }

    public class DataTransformationService : IDataTransformationService
    {
        public async Task<TransformedData> TransformDataAsync(RawData rawData)
        {
            // Simulate data transformation
            var transformedData = new TransformedData
            {
                RawDataId = rawData.Id,
                ProcessedData = rawData.Data.ToUpper()  // Example transformation
            };

            return await Task.FromResult(transformedData);
        }
    }
}
