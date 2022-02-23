using GanhouExperienciaIssoSim.Domain.Services;
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

        private IGameServices gameServices;

        public IndexModel(IGameServices gameServices)
        {
            this.gameServices = gameServices;
        }

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Bets = gameServices.VerifyBets(SearchString, "");

                foreach (var bet in Bets)
                {
                    bet.GetFormatNumbers(",");
                }

                return Page();
            }

            Bets = gameServices.GetBets();
            return Page();
        }
    }
}
