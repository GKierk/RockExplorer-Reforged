using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RockExplorer_Reforged.Models;

namespace RockExplorer_Reforged.Pages.Artifacts
{
    public class IndexModel : PageModel
    {
        private ArtifactRepository? repo;
        
        public IndexModel()
        {
            repo = ArtifactRepository.Instance;
        }

        public Dictionary<int, Artifact>? Artifacts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilterCriteria { get; set; }

        public IActionResult OnGet()
        {
            Artifacts = repo.ReadAll();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Artifacts = repo.FilterArtifact(FilterCriteria);
            }

            return Page();
        }
    }
}
