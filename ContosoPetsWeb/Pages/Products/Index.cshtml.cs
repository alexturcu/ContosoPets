using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoPetsWeb.Models;

namespace ContosoPetsWeb.Pages.Products
{
    using Products = Models.Products;

    public class IndexModel : PageModel
    {
        private readonly ContosoPetsWeb.Models.ContosoPetsContext _context;

        public IndexModel(ContosoPetsWeb.Models.ContosoPetsContext context)
        {
            _context = context;
        }

        public IList<Products> Products { get;set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
