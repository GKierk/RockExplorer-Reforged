using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer_Reforged.Models;

namespace RockExplorer_Reforged.Pages.Artifacts
{
    public class UpdateModel : PageModel
    {
        private ArtifactRepository repo;

        public UpdateModel()
        {
            repo = ArtifactRepository.Instance;
        }

        [BindProperty]
        public Artifact? artifact { get; set; }

        public void OnGet(int key)
        {
            repo.key = key;
            artifact = repo.Read(key);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.Update(repo.key, artifact);
            return RedirectToPage("Read");
        }
    }
}
