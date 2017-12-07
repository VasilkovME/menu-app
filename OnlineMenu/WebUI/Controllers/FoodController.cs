using BusinessLogic.Contracts;
using BusinessLogic.Models;
using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Food;

namespace WebUI.Controllers
{
    public class FoodController : BaseController
    {
        protected IFoodService _foodService;
        protected IMapper<Food, FoodViewModel> _foodMapper;
        protected IMapper<FoodIngredientModel, FoodIngredientViewModel> _foodIngredientMapper;
        protected IMapper<FoodModel, FoodViewModel> _foodModelMapper;

        public FoodController(IFoodService foodService, 
                              IMapper<Food, FoodViewModel> foodMapper, 
                              IMapper<FoodIngredientModel, FoodIngredientViewModel> foodIngredientMapper,
                              IMapper<FoodModel, FoodViewModel> foodModelMapper)
        {
            _foodService = foodService;
            _foodMapper = foodMapper;
            _foodIngredientMapper = foodIngredientMapper;
            _foodModelMapper = foodModelMapper;
        }

        // GET: Food
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllFoods()
        {
            var allFoods = _foodService.GetAllFoods();
            return Json(allFoods.Select(food=> _foodMapper.Map(food)).ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Ingredients(int foodId)
        {
            var ingredients = _foodService.GetFoodIngredients(foodId);
            return Json(ingredients, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(FoodViewModel food)
        {
            var foodToCreate = _foodMapper.Map(food);
            _foodService.CreateFood(foodToCreate);

            return Json(_foodMapper.Map(foodToCreate));
        }

        [HttpPost]
        public ActionResult Edit(FoodViewModel food)
        {
            var foodToEditModel = _foodModelMapper.Map(food);
            foodToEditModel = _foodService.EditFood(foodToEditModel);

            return Json(_foodModelMapper.Map(foodToEditModel));
        }

        [HttpPost]
        public ActionResult CreateFoodIngredient(FoodIngredientViewModel food)
        {
            var foodIngredientToCreate = _foodIngredientMapper.Map(food);
            _foodService.AddFoodIngredient(foodIngredientToCreate);

            return Json(_foodIngredientMapper.Map(foodIngredientToCreate));
        }

    }
}