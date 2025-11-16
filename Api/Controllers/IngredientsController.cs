using Api.RequestModels;
using Api.ResponseModels;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IngredientResponseModel>> GetIngredientById(int id, CancellationToken cancellationToken)
        {
            var result = await ingredientsService.GetIngredientByIdAsync(id, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var ingredientDto = result.Value!;

            var ingredientResponseModel = new IngredientResponseModel()
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                UnitOfMeasurement = ingredientDto.UnitOfMeasurement
            };

            return Ok(ingredientResponseModel);
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientResponseModel>>> GetIngredients(CancellationToken cancellationToken)
        {
            var result = await ingredientsService.GetIngredientsAsync(cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var ingredientsDtos = result.Value!;

            var ingredientsResponseModels = ingredientsDtos.Select(x => new IngredientResponseModel()
            {
                Id = x.Id,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement
            });

            return Ok(ingredientsResponseModels);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientResponseModel>> AddIngredient(IngredientRequestModel ingredientRequestModel, CancellationToken cancellationToken)
        {
            var ingredientDto = new IngredientDto()
            {
                Name = ingredientRequestModel.Name,
                UnitOfMeasurement = ingredientRequestModel.UnitOfMeasurement
            };

            var result = await ingredientsService.AddIngredientAsync(ingredientDto, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIngredient(IngredientRequestModel ingredientRequestModel, CancellationToken cancellationToken)
        {
            var ingredientDto = new IngredientDto()
            {
                Id = ingredientRequestModel.Id,
                Name = ingredientRequestModel.Name,
                UnitOfMeasurement = ingredientRequestModel.UnitOfMeasurement
            };

            var result = await ingredientsService.UpdateIngredientAsync(ingredientDto, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteIngredient(int id, CancellationToken cancellationToken)
        {
            var result = await ingredientsService.DeleteIngredientAsync(id, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return NoContent();
        }
    }
}
