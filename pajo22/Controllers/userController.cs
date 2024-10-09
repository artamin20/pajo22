using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pajo22.Data;
using pajo22.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pajo22.Controllers
{
    public class userController : Controller
    {
        private readonly pajo22Context _context;

        public userController(pajo22Context context)
        {
            _context = context;
        }

        public IActionResult Index(string subgroupName, string nameFilter, decimal? minPriceFilter, decimal? maxPriceFilter)
        {
            var viewModel = new IndexViewModel(_context, nameFilter, minPriceFilter, maxPriceFilter);

            // If a subgroupName is provided, filter products based on the subgroup
            if (!string.IsNullOrEmpty(subgroupName))
            {
                viewModel.Products = viewModel.GetSubgroupProducts(subgroupName);
            }

            return View(viewModel);
        }

        public IActionResult AttributeSearch(string attributeName, string attributeValue)
        {
            var viewModel = new IndexViewModel(_context, null, null, null);

            var attributeId = _context.Attributes
                .Where(attr => attr.AttributeName == attributeName)
                .Select(attr => attr.AttributeID)
                .FirstOrDefault();

            if (attributeId != 0)
            {
                var attributeValues = _context.AttributeValues
                    .Include(av => av.ProductModel)
                    .Where(av => av.AttributeID == attributeId && av.Value.Contains(attributeValue))
                    .ToList();

                var productIds = attributeValues.Select(av => av.ProductModelId).ToList();

                viewModel.Products = _context.ProductModels
                    .Where(p => productIds.Contains(p.Id))
                    .ToList();
            }

            return View("Index", viewModel);
        }
    }

    public class IndexViewModel
    {
        public List<ProductModels> Products;
        public List<GroupModels> MainGroups;
        public List<string> AttributeNames;
        private readonly pajo22Context _context;

        public IndexViewModel(pajo22Context context, string nameFilter, decimal? minPriceFilter, decimal? maxPriceFilter)
        {
            _context = context;
            LoadData(nameFilter, minPriceFilter, maxPriceFilter);
        }

        private void LoadData(string nameFilter, decimal? minPriceFilter, decimal? maxPriceFilter)
        {
            var products = _context.ProductModels.AsQueryable();
            MainGroups = _context.GroupModels
                .Include(g => g.Subgroups)
                .ToList();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.Name.Contains(nameFilter));
            }

            decimal? minPrice = products.Min(p => p.Price);
            decimal? maxPrice = products.Max(p => p.Price);

            if (minPriceFilter != null)
            {
                minPrice = Math.Max(minPrice ?? 0, minPriceFilter.Value);
            }

            if (maxPriceFilter != null)
            {
                maxPrice = Math.Min(maxPrice ?? decimal.MaxValue, maxPriceFilter.Value);
            }

            products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            AttributeNames = _context.Attributes
                .Select(a => a.AttributeName)
                .Distinct()
                .ToList();

            Products = products.ToList();
        }

        public List<ProductModels> GetSubgroupProducts(string subgroupName)
        {
            return _context.ProductModels
                .Where(p => p.Subgroup.Name == subgroupName)
                .ToList();
        }

    }
}
