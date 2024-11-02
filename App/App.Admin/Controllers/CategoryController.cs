using App.Admin.Models.ViewModels.Category;
using App.Service.Models.CategoryDTOs;
using App.Service.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : BaseController
    {
        public CategoryController(IServiceManager serviceManager, IMapper mapper) : base(serviceManager, mapper)
        {
        }

        [Route("/categories")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategoriesAsync();
            var categoriesList = _mapper.Map<IEnumerable<CategoryListViewModel>>(categories);
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
            var newCategory = _mapper.Map<AddCategoryDto>(newCategoryModel);
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
            var categoryViewModel = _mapper.Map<EditCategoryViewModel>(category);
            return View(categoryViewModel);
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int categoryId, [FromForm] EditCategoryViewModel editCategoryModel)
        {

            if (!ModelState.IsValid)
            {
                return View(editCategoryModel);
            };
            editCategoryModel.CategoryId = categoryId;
            var categoryDto = _mapper.Map<UpdateCategoryDto>(editCategoryModel);
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