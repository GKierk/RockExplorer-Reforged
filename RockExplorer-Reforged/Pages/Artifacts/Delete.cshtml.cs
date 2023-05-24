using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer_Reforged.Models;

namespace RockExplorer_Reforged.Pages.Artifacts
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Artifact artifact { get; set; }
        private ArtifactRepository repo;

        public DeleteModel()
        {
            repo = ArtifactRepository.Instance;
        }
        public IActionResult OnGet(int key)
        {
            artifact = repo.Read(key);
            return Page();
        }

        public IActionResult OnPost(int key)
        {
            repo.Delete(key);
            return RedirectToPage("Index");
        }
    }
}
