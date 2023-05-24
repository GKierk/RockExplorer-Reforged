using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer_Reforged.Models;

namespace RockExplorer_Reforged.Pages.Artifacts
{
    public class CreateModel : PageModel
    {
        private ArtifactRepository? repo;

        public CreateModel()
        {
            repo = ArtifactRepository.Instance;
        }

        [BindProperty]
        public Artifact? Artifact { get; set; }

        public IActionResult OnGet()
        {

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.Create(Artifact);
            return RedirectToPage("Index");
        }
    }
}
