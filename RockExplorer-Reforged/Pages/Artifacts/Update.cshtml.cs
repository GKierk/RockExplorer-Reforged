using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer_Reforged.Models;

namespace RockExplorer_Reforged.Pages.Artifacts
{
    public class UpdateModel : PageModel
    {
        public class Update : PageModel
        {
            private ArtifactRepository repo;

            public Update()
            {
                repo = ArtifactRepository.Instance;
            }

            [BindProperty]
            public Artifact? artifact { get; set; }

            public IActionResult OnGet(int key)
            {
                repo.key = key;
                artifact = repo.Read(key);
                return Page();
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
}
