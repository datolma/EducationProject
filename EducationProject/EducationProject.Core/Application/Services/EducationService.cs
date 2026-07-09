using EducationProject.Core.Application.Absractions;
using EducationProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProject.Core.Application.Services
{
    public class EducationService(IGoodRepositories goodRepositories)
    {
        public async Task<List<Good>> GetAllGoodsAsync()
        {
            return await goodRepositories.GetAllAsync();
        }

        public async Task<Good?> GetGoodByIdAsync(int id)
        {
            return await goodRepositories.GetByIdAsync(id);
        }

        public async Task<Good> AddGoodAsync(Good good)
        {
            if (string.IsNullOrWhiteSpace(good.Name))
                throw new ArgumentException("Название товара обязательно");

            if (good.Price < 0)
                throw new ArgumentException("Цена не может быть отрицательной");

            return await goodRepositories.AddAsync(good);
        }

        public async Task<Good> UpdateGoodAsync(Good good)
        {
            var existing = await goodRepositories.GetByIdAsync(good.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Товар с ID {good.Id} не найден");

            return await goodRepositories.UpdateAsync(good);
        }

        public async Task<bool> DeleteGoodAsync(int id)
        {
            return await goodRepositories.DeleteAsync(id);
        }

        public async Task<List<Good>> SearchGoodsByNameAsync(string name)
        {
            return await goodRepositories.SearchByNameAsync(name);
        }

        public async Task<decimal> GetFinalPriceAsync(int goodId)
        {
            var good = await goodRepositories.GetByIdAsync(goodId);

            if (good == null)
                throw new KeyNotFoundException($"Товар с ID {goodId} не найден");

            return good.FinalPrice;  
        }
    }
}
