using Microsoft.EntityFrameworkCore;

using MY_WEB_APP.Data;
using MY_WEB_APP.Models;

using System;

namespace MY_WEB_APP.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext _context;

        public DataRepository(AppDbContext context)
        {
            _context = context;
        }

        // Raw Data Methods
        public async Task<IEnumerable<RawData>> GetAllRawDataAsync()
        {
            return await _context.RawData.ToListAsync();
        }

        public async Task<RawData> GetRawDataByIdAsync(int id)
        {
            return await _context.RawData.FindAsync(id);
        }

        public async Task<RawData> AddRawDataAsync(RawData rawData)
        {
            _context.RawData.Add(rawData);
            await _context.SaveChangesAsync();
            return rawData;
        }

        public async Task<RawData> UpdateRawDataAsync(RawData rawData)
        {
            _context.Entry(rawData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rawData;
        }

        public async Task<bool> DeleteRawDataAsync(int id)
        {
            var rawData = await _context.RawData.FindAsync(id);
            if (rawData == null)
            {
                return false;
            }

            _context.RawData.Remove(rawData);
            await _context.SaveChangesAsync();
            return true;
        }

        // Transformed Data Methods
        public async Task<IEnumerable<TransformedData>> GetAllTransformedDataAsync()
        {
            return await _context.TransformedData.ToListAsync();
        }

        public async Task<TransformedData> GetTransformedDataByIdAsync(int id)
        {
            return await _context.TransformedData.FindAsync(id);
        }

        public async Task<TransformedData> AddTransformedDataAsync(TransformedData transformedData)
        {
            _context.TransformedData.Add(transformedData);
            await _context.SaveChangesAsync();
            return transformedData;
        }

        public async Task<TransformedData> UpdateTransformedDataAsync(TransformedData transformedData)
        {
            _context.Entry(transformedData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return transformedData;
        }

        public async Task<bool> DeleteTransformedDataAsync(int id)
        {
            var transformedData = await _context.TransformedData.FindAsync(id);
            if (transformedData == null)
            {
                return false;
            }

            _context.TransformedData.Remove(transformedData);
            await _context.SaveChangesAsync();
            return true;
        }

        // Data transformation specific methods
        public async Task SaveTransformedDataAsync(TransformedData transformedData)
        {
            _context.TransformedData.Add(transformedData);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TransformedData>> GetTransformedDataAsync()
        {
            return await _context.TransformedData.ToListAsync();
        }
    }
}
