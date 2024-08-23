using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspNet_EF.Pages.Calls
{
    public class EditModel : PageModel
    {
        private readonly IBaseRepository<Call> _callRepository;

        [BindProperty]
        public Call Call { get; set; }

        public EditModel(IBaseRepository<Call> callRepository)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine(Call);
            _callRepository.Update(Call);
            return RedirectToPage("/Calls/Index");
        }
    }
}