using RockExplorer_Reforged.Models;
using System.Text.Json;

namespace RockExplorer_Reforged.Helpers
{
    public class JsonFileHandler
    {
        public static Dictionary<int, Artifact> ReadJson(string path)
        {
            if (!File.Exists(path))
            {
                Default(path);
            }

            using (var jsonFileReader = File.OpenText(path))
            {
                var json = jsonFileReader.ReadToEnd();
                return JsonSerializer.Deserialize<Dictionary<int, Artifact>>(json);
            }
        }

        public static void WriteToJson(string path)
        {
            ArtifactRepository repo = ArtifactRepository.Instance;

            if (File.Exists(path))
            {
                File.Delete(path);

                using (FileStream outputStream = File.OpenWrite(path))
                {
                    var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = false,
                        Indented = true
                    });

                    JsonSerializer.Serialize<Dictionary<int, Artifact>>(writer, repo.Artifacts);
                }
            }
            else
            {

                using (FileStream outputStream = File.OpenWrite(path))
                {
                    var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = false,
                        Indented = true
                    });

                    JsonSerializer.Serialize<Dictionary<int, Artifact>>(writer, repo.Artifacts);
                }
            }
        }

        private static void Default(string path)
        {
            Dictionary<int, Artifact> defaultValues = new Dictionary<int, Artifact>();

            defaultValues[1] = new Artifact
            {
                Name = "placeholder",
                Description = "placeholder",
                YearOfCreation = 2023,
                Artist = "placeholder",
                PathToAudioFile = "",
                PathToImageFile = ""
            };

            using (FileStream outputStream = File.OpenWrite(path))
            {
                var writer = new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = false,
                    Indented = true
                });

                JsonSerializer.Serialize<Dictionary<int, Artifact>>(writer, defaultValues);
            }
        }
    }
}
