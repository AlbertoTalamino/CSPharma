using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Model;

namespace CSPharma.Pages.ShipmentOrderStatus
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Model.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Model.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcCatEstadosEnvioPedido TdcCatEstadosEnvioPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosenviopedido = await _context.TdcCatEstadosEnvioPedidos.FirstOrDefaultAsync(m => m.CodEstadoEnvio == id);

            if (tdccatestadosenviopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadosenviopedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);

            if (tdccatestadosenviopedido != null)
            {
                TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
                _context.TdcCatEstadosEnvioPedidos.Remove(TdcCatEstadosEnvioPedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
