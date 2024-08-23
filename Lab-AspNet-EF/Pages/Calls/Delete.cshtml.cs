using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspNet_EF.Pages.Calls
{
    public class DeleteModel : PageModel
    {
        private readonly IBaseRepository<Call> _callRepository;

        [BindProperty]
        public Call Call { get; set; }

        public DeleteModel(IBaseRepository<Call> callRepository)
        {
            _callRepository = callRepository;
        }

        public IActionResult OnGet(int id)
        {
            Call = _callRepository.GetId(id);
            if (Call == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if ((Call = _callRepository.GetId(id)) == null)
            {
                return NotFound();
            }

            _callRepository.Remove(Call);
          
            return RedirectToPage("/Calls/Index");
        }
    }
}