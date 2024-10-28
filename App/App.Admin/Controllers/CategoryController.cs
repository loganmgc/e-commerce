using App.Admin.Models.ViewModels.Category;
using App.Service.Models.CategoryDtos;
using App.Service.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Route("/categories")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            var categoriesList = categories.Select(c => new CategoryListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                IconCssClass = c.IconCssClass,
                Color = c.Color,
            }).ToList();
            return View(categoriesList);
        }

        [Route("/categories/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/categories/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryViewModel newCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View(newCategoryModel);
            }
            var newCategory = new AddCategoryDto()
            {
                Name = newCategoryModel.Name,
                IconCssClass = newCategoryModel.IconCssClass,
                Color = newCategoryModel.Color
            };
            await _serviceManager.CategoryService.AddCategoryAsync(newCategory);
            TempData["SuccessMessage"] = "Category has been added successfully.";
            return RedirectToAction("Create");
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int categoryId)
        {
            var category = await _serviceManager.CategoryService.GetCategoryByIdAsync(categoryId);
            if (category == null)
            {
                ViewBag.Error = "Category not found";
            }
            var categoryViewModel = new EditCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                IconCssClass = category.IconCssClass,
                Color = category.Color
            };
            return View(categoryViewModel);
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int categoryId, [FromForm] EditCategoryViewModel editCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editCategoryModel);
            }
            var categoryDto = new UpdateCategoryDto()
            {
                Id = editCategoryModel.Id,
                Name = editCategoryModel.Name,
                IconCssClass = editCategoryModel.IconCssClass,
                Color = editCategoryModel.Color
            };
            await _serviceManager.CategoryService.UpdateCategoryAsync(categoryId, categoryDto);
            TempData["SuccessMessage"] = "Category has been updated successfully.";
            return RedirectToAction("Edit");
        }

        [Route("/categories/{categoryId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            var result = await _serviceManager.CategoryService.DeleteCategoryAsync(categoryId);
            if (result)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}