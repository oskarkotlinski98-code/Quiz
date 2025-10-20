using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Labb3_NET22.DataModels;

namespace Labb3_NET22.Files
{


    // Full ChatGPT here, no way in hell i would come up with this myself LMAO. i spent a bunch time learning how it works tho.
    public static class SaveQuizToFile
    {
        private static readonly string Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Labb3-NET22");

        static SaveQuizToFile()
        {
            Directory.CreateDirectory(Folder);
        }

        public static void SaveQuizJson(Quiz quiz)
        {
            string filePath = Path.Combine(Folder, $"{quiz.Title}.json");
            string jsonString = JsonSerializer.Serialize(quiz);
            File.WriteAllText(filePath, jsonString);
        }

        public static Quiz LoadQuizFromFile(string title)
        {
            string filePath = Path.Combine(Folder, $"{title}.json");
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Quiz>(jsonString)!;
        }

        public static IEnumerable<string> GetAllQuizTitles()
        {
            foreach(var file in Directory.GetFiles(Folder, "*.json"))
            {
                yield return Path.GetFileNameWithoutExtension(file);
            }
        }
    }
}
