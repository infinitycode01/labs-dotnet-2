using Lab3_AspNet_EF.Models;
using Lab3_AspNet_EF.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3_AspNet_EF.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBaseRepository<Call> _callRepository;

        public List<Call> Calls { get; private set; }

        public IndexModel(IBaseRepository<Call> callRepository)
        {
            _callRepository = callRepository;
        }

        public void OnGet()
        {
            Calls = _callRepository.GetAll().ToList();
        }
    }
}