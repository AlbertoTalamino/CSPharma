using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Model;

namespace CSPharma.Pages.StatusOrders
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.Model.CspharmaInformacionalContext _context;

        public DetailsModel(DAL.Model.CspharmaInformacionalContext context)
        {
            _context = context;
        }

      public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }

            var tdctchestadopedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcTchEstadoPedido = tdctchestadopedido;
            }
            return Page();
        }
    }
}
