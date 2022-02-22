using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GanhouExperienciaIssoSim.AspNet.Pages.PrizeDraw
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Domain.PrizeDraw PrizeDraw { get; set; }

        [BindProperty]
        public List<Domain.Bet> Bets { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IActionResult OnGet()
        {
            

            return Page();
        }
    }
}
