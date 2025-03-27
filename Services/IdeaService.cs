using IdeaManager.Models;
using System.Text.Json;

namespace IdeaManager.Services
{
    public static class IdeaService
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ideas.json");

        public static List<Idea> LoadIdeas()
        {
            EnsureDataFileExists();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Idea>>(json) ?? new List<Idea>();
        }

        public static void SaveIdeas(List<Idea> ideas)
        {
            EnsureDataFileExists();

            var json = JsonSerializer.Serialize(ideas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private static void EnsureDataFileExists()
        {
            var directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                // Creamos un archivo vacío con lista vacía de ideas
                File.WriteAllText(filePath, "[]");
            }
        }
    }
}
