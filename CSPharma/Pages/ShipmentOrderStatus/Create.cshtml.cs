using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Model;

namespace CSPharma.Pages.ShipmentOrderStatus
{
    public class CreateModel : PageModel
    {
        private readonly DAL.Model.CspharmaInformacionalContext _context;

        public CreateModel(DAL.Model.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TdcCatEstadosEnvioPedido TdcCatEstadosEnvioPedido { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TdcCatEstadosEnvioPedidos == null || TdcCatEstadosEnvioPedido == null)
            {
                return Page();
            }

            _context.TdcCatEstadosEnvioPedidos.Add(TdcCatEstadosEnvioPedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
