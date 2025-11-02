using Application.Services;
using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Moq;

namespace Tests.Services;

[TestClass]
public class IngredientServiceTests
{
    [TestMethod]
    public async Task GetIngredientsAsync_MapsCorrectValues()
    {
        var ingredients = new List<Ingredient>()
        {
            new Ingredient()
            {
                Id = 1,
                Name = "Rice",
                UnitOfMeasurement = Domain.Enums.UnitOfMeasurement.Cup
            },
            new Ingredient()
            {
                Id = 2,
                Name = "Mushroom",
                UnitOfMeasurement = Domain.Enums.UnitOfMeasurement.Gram
            }
        };

        var mockIngredientsRepository = new Mock<IIngredientsRepository>();

        mockIngredientsRepository.Setup(x => x.GetIngredientsAsync(CancellationToken.None)).ReturnsAsync(ingredients);

        var mockRecipesRepository = new Mock<IRecipesRepository>();

        var service = new IngredientsService(mockIngredientsRepository.Object, mockRecipesRepository.Object);

        var result = await service.GetIngredientsAsync(CancellationToken.None);

        var expectedResult = new List<IngredientDto>()
        {
            new IngredientDto()
            {
                Id = 1,
                Name = "Rice",
                UnitOfMeasurement = Domain.Enums.UnitOfMeasurement.Cup
            },
            new IngredientDto()
            {
                Id = 2,
                Name = "Mushroom",
                UnitOfMeasurement = Domain.Enums.UnitOfMeasurement.Gram
            }
        };

        Assert.IsTrue(
            expectedResult.Select(x => (x.Id, x.Name, x.UnitOfMeasurement))
            .SequenceEqual(result.Value!.Select(x => (x.Id, x.Name, x.UnitOfMeasurement)))
            );
    }
}
