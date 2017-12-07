using BusinessLogic.Contracts;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.Ingredient;

namespace WebUI.Controllers
{
    public class IngredientController : BaseController
    {
        IIngredientService _ingredientService;
        IMapper<Ingredient, IngredientViewModel> _ingredientMapper;

        public IngredientController(IIngredientService ingredientService, IMapper<Ingredient, IngredientViewModel> ingredientMapper)
        {
            this._ingredientService = ingredientService;
            this._ingredientMapper = ingredientMapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllIngredients()
        {
            var ingredients = _ingredientService.GetAllIngridients();
            return Json(ingredients.Select(i=> _ingredientMapper.Map(i)).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(IngredientViewModel newIngredientNodel)
        {
            var newIngredient = _ingredientMapper.Map(newIngredientNodel);
            var ingredients = _ingredientService.CreateIngredient(newIngredient);
            return Json(_ingredientMapper.Map(newIngredient));
        }

        [HttpPost]
        public ActionResult Edit(IngredientViewModel editedIngredientModel)
        {
            var editedIngredient = _ingredientMapper.Map(editedIngredientModel);
            var ingredients = _ingredientService.EditIngredient(editedIngredient);
            return Json(editedIngredient);
        }

        [HttpPost]
        public ActionResult Delete(int ingredientId)
        {
            var deletionResult = _ingredientService.DeleteIngredient(ingredientId);
            return Json(new { Success = deletionResult });
        }

        public ActionResult GetById(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            return Json(_ingredientMapper.Map(ingredient), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FindByName(string searchTerm, SearchOption searchOption = SearchOption.Contains)
        {
            var ingredients = _ingredientService.GetByName(searchTerm, searchOption);
            var ingredientViewModels = ingredients.Select(ingredient => _ingredientMapper.Map(ingredient));
            return Json(ingredientViewModels, JsonRequestBehavior.AllowGet);
        }
    }
}