using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Infrastructure.Context;
using Chilli.Core.Product.Domain;
using MediatR;
using Chilli.API.Queries;
using Chilli.Application.MediatR.Queries;
using Chilli.Core.Product.Models.DBO;
using AutoMapper;

namespace Chilli.MVC.Controllers
{
    public class ProductEntitiesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductEntitiesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: ProductEntities
        public async Task<IActionResult> Index()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            List<ProductEntity> pl = new List<ProductEntity>();
            foreach (ProductModel pm in result.Products)
            {
                ProductEntity product = _mapper.Map<ProductEntity>(pm);
                pl.Add(product);
            }
            return View(pl);
        }

        // GET: ProductEntities/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            ProductEntity products = _mapper.Map<ProductEntity>(result.Products);
            return View(products);
        }
/*
        // GET: ProductEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Cost,Size")] ProductEntity productEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productEntity);
        }

        // GET: ProductEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }
            return View(productEntity);
        }

        // POST: ProductEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Cost,Size")] ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductEntityExists(productEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productEntity);
        }

        // GET: ProductEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEntity = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return View(productEntity);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }*/
    }
}
