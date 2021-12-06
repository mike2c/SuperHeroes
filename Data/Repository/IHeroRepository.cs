using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IHeroRepository
    {
        Task<ICollection<HeroModel>> GetByNameAsync(string heroName);
        Task<HeroModel> GetAsync(int id);
    }
}
