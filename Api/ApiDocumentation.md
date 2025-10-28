# Ingredients

## List ingredients

`GET /api/ingredients`

**Response**

``` JSON
[
    {
        "id": 1,
        "name": "Rice",
        "unitOfMeasurement": "Cup"
    }
]
```

## Create new ingredient

`POST /api/ingredients`

**Request**

``` JSON
{
    "name": "Rice",
    "unitOfMeasurement": "Cup"
}
```

**Response**

``` JSON
{
    "id": 1,
    "name": "Rice",
    "unitOfMeasurement": "Cup"
}
```

## Get list of aggregated ingredients of a given array of recipes

`GET /api/ingredients?recipeIds=1,2,3,4,5`

**Response**

``` JSON
[
    {
        "id": 1,
        "name": "Rice",
        "unitOfMeasurement": "Cup",
        "quantity": 4
    }
]
```

# Recipes

## List all recipes

`GET /api/recipes`

**Response**

``` JSON
[
    {
        "id": 1,
        "name": "Risotto"
    }
]
```

## Get recipe by id

`GET /api/recipes/:id`

**Response**

``` JSON
{
    "id": 1,
    "name": "Risotto",
    "ingredients": 
    [
        {
            "id": 1,
            "name": "Rice",
            "unitOfMeasurement": "Cup",
            "quantity": 1
        }
    ]
}
```

## Create new recipe

`POST /api/recipes`

**Request**

``` JSON
{
    "name": "Risotto"
}
```

**Response**

``` JSON
{
    "id": 1,
    "name": "Risotto"
}
```

## Add ingredient to recipe

`POST /api/recipes/addIngredient`

**Request**

``` JSON
{
    "recipeId": 1,
    "ingredientId": 1,
    "quantity": 500
}
```

**Response**

``` JSON
{
    "id": 1,
    "name": "Risotto",
    "ingredients": 
    [
        {
            "id": 1,
            "name": "Rice",
            "unitOfMeasurement": "Cup",
            "quantity": 1
        }
    ]
}
```
