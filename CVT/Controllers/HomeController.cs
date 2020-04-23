using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CVT.Models;
using BL.Services.Interfaces;
using AutoMapper;
using BL.DataModels;

namespace CVT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMainService _mainService;
        private readonly IMapper _mapper;

        public HomeController(IMainService mainService, IMapper mapper)
        {
            _mainService = mainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Главная страница (список контактов)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync()
        {
            var personDataList = await _mainService.GetPersonListAsync();

            List<PersonViewModel> personViewList = personDataList.Select(i => _mapper.Map<PersonViewModel>(i)).ToList();

            IndexViewModel model = new IndexViewModel(personViewList);

            return View(model);
        }

        /// <summary>
        /// Страница создания/редактирования контакта
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<IActionResult> PersonFormAsync(int? personId)
        {
            PersonViewModel model = new PersonViewModel();

            if (!personId.HasValue)
                return View(model);

            PersonDataModel person = await _mainService.GetPersonAsync(personId.Value);

            if (person != null)
                model = _mapper.Map<PersonViewModel>(person);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PersonSaveAsync(PersonViewModel model)
        {
            if (!ModelState.IsValid)
                return View("PersonForm", model);

            PersonDataModel dataModel = _mapper.Map<PersonDataModel>(model);

            try
            {
                if (model.Id > 0)
                    await _mainService.EditPersonAsync(dataModel);
                else
                    await _mainService.AddPersonAsync(dataModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(model.Surname), ex.Message);

                return View("PersonForm", model);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePersonAsync(int personId)
        {
            try
            {
                await _mainService.DeletePersonAsync(personId);
            }
            catch (Exception ex)
            {
                var personList = await _mainService.GetPersonListAsync();

                List<PersonViewModel> personViewList = personList.Select(i => _mapper.Map<PersonViewModel>(i)).ToList();

                IndexViewModel model = new IndexViewModel(personViewList);

                ModelState.AddModelError(nameof(model.PersonList), ex.Message);

                return View("Index", model);

            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
