using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspNet_EF.Pages.Calls
{
    public class CreateModel : PageModel
    {
        private readonly IBaseRepository<Call> _callRepository;

        [BindProperty]
        public Call Call { get; set; }

        public CreateModel(IBaseRepository<Call> callRepository)
        {
            _callRepository = callRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _callRepository.Add(Call);
            return RedirectToPage("/Calls/Index");
        }
    }
}