using System;
using System.IO;
using Adamsone.Models;
using NETCore.Encrypt;
using Newtonsoft.Json;

namespace Adamsone.Infrastructure
{
    public class ConfigManager
    {
        public string Path { get; }

        public Config Config { get; private set; }

        private readonly string _key = "jVDzlw1wVFvy5CH52GAwBjtYT6Z5PXF9";
        public ConfigManager()
        {
            Path = System.IO.Path.Combine(Environment.CurrentDirectory, "store.json");
            Load();
        }

        public void Load()
        {
            if (!File.Exists(Path))
            {
                Config = new Config();
                Save();
            }

            Config = JsonConvert.DeserializeObject<Config>(EncryptProvider.AESDecrypt(File.ReadAllText(Path), _key));
        }

        public void Save()
        {
            File.WriteAllText(Path, EncryptProvider.AESEncrypt(JsonConvert.SerializeObject(Config), _key));
            Load();
        }
    }
}
