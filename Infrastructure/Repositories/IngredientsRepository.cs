using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return new List<Ingredient>()
        {
            new Ingredient()
            {
                Name = "Rice",
                Id = 1,
            },
            new Ingredient()
            {
                Name = "Beans",
                Id = 2,
            }
        };
    }
}
