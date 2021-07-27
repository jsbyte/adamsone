using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Adamsone.Models;
using Newtonsoft.Json;

namespace Adamsone.Infrastructure
{
    public class ConfigManager
    {
        public string Path { get; }

        public Config Config { get; private set; }

        public ConfigManager()
        {
            Path = System.IO.Path.Combine(Environment.CurrentDirectory, "store.json");
            Load();
            Save();
        }

        public void Load()
        {
            if (!File.Exists(Path))
                File.Create(Path).Close();

            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path));
        }

        public void Save()
        {
            File.WriteAllText(Path, JsonConvert.SerializeObject(Config));
        }
    }
}
