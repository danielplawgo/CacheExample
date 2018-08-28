using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CacheExample.Logic;
using CacheExample.ViewModels.Products;

namespace CacheExample.Controllers
{
    public class ProductsController : Controller
    {
        private Lazy<IProductLogic> _logic;

        protected IProductLogic Logic
        {
            get { return _logic.Value; }
        }

        private Lazy<IMapper> _mapper;

        protected IMapper Mapper
        {
            get { return _mapper.Value; }
        }

        public ProductsController(Lazy<IProductLogic> logic,
            Lazy<IMapper> mapper)
        {
            _logic = logic;
            _mapper = mapper;
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<ProductViewModel>>(Logic.GetAll()));
        }

        public ActionResult Details(int id)
        {
            var product = Logic.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<ProductViewModel>(product);

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var product = Logic.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<ProductViewModel>(product);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var product = Logic.GetById(viewModel.Id);

            if (product == null)
            {
                return HttpNotFound();
            }

            Mapper.Map(viewModel, product);

            Logic.Update(product);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = Logic.GetById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            Logic.Delete(product);

            return RedirectToAction("Index");
        }
    }
}