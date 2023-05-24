using RockExplorer_Reforged.Helpers;
using RockExplorer_Reforged.Interfaces;

namespace RockExplorer_Reforged.Models
{
    public class ArtifactRepository : ICRUD<Artifact>
    {
        private static ArtifactRepository? instance = null;

        private string filePath = @"Data/JsonArtifacts.json";

        public Dictionary<int, Artifact>? Artifacts { get; set; }

        public int key { get; set; }

        public static ArtifactRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArtifactRepository();
                }

                return instance;
            }
        }

        public void Create(Artifact entity)
        {
            int dictionarySize = ReadAll().Count();

            Artifacts.Add(++dictionarySize, entity);
            JsonFileHandler.WriteToJson(filePath);
        }

        public Artifact Read(int key)
        {
            return Artifacts[key];
        }

        public Dictionary<int, Artifact> ReadAll()
        {
            return JsonFileHandler.ReadJson(filePath);
        }

        public void Update(int key, Artifact entity)
        {
            ArtifactRepository repo = instance;

            if (entity != null && repo.Artifacts.ContainsKey(key))
            {
                repo.Artifacts[key].Name = entity.Name;
                repo.Artifacts[key].Description = entity.Description;
                repo.Artifacts[key].YearOfCreation = entity.YearOfCreation;
                repo.Artifacts[key].Artist = entity.Artist;
                repo.Artifacts[key].PathToImageFile = entity.PathToImageFile;
                repo.Artifacts[key].PathToAudioFile = entity.PathToAudioFile;
            }

            JsonFileHandler.WriteToJson(filePath);
        }

        public void Delete(int key)
        {
            ArtifactRepository repo = Instance;
            Dictionary<int, Artifact> tempDictionary = new Dictionary<int, Artifact>();
            int currentKeyNumber = 1;

            foreach (var kvp in repo.Artifacts)
            {

                if (currentKeyNumber <= repo.Artifacts.Count + 1)
                {
                    if (currentKeyNumber != key)
                    {
                        tempDictionary.Add(currentKeyNumber, repo.Artifacts[kvp.Key]);
                    }
                    else
                    {
                        currentKeyNumber--;
                        repo.Artifacts.Remove(key);
                    }
                }

                currentKeyNumber++;
            }

            repo.Artifacts.Clear();
            repo.Artifacts = tempDictionary;
            JsonFileHandler.WriteToJson(filePath);
        }

        public Dictionary<int, Artifact> FilterArtifact(string criteria)
        {
            Dictionary<int, Artifact> myArtifacts = new Dictionary<int, Artifact>();

            if (criteria != null)
            {
                foreach (KeyValuePair<int, Artifact> kvp in Artifacts)
                {
                    bool filter = kvp.Value.YearOfCreation != null;
                    if (kvp.Value.Name != null && kvp.Value.Name.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (kvp.Value.Description != null && kvp.Value.Description.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (kvp.Value.Artist != null && kvp.Value.Artist.ToLower().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                    else if (filter && kvp.Value.YearOfCreation.ToString().StartsWith(criteria.ToLower()))
                    {
                        myArtifacts.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            return myArtifacts;
        }
    }
}
