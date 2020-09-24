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

    public class DetailsModel : PageModel
    {
        private readonly ContosoPetsWeb.Models.ContosoPetsContext _context;

        public DetailsModel(ContosoPetsWeb.Models.ContosoPetsContext context)
        {
            _context = context;
        }

        public Products Products { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Products = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);

            if (Products == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
