using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CardGames
{
    [Serializable]
    public abstract class ClassExtension
    {
        private const string FileName = "SavedData.dat";

        protected ClassExtension()
        {
            AddToExtensions();
        }

        private static Dictionary<Type, List<ClassExtension>> _extensions = new Dictionary<Type, List<ClassExtension>>();

        private void AddToExtensions()
        {
            if (!_extensions.ContainsKey(GetType()))
            {
                _extensions.Add(GetType(), new List<ClassExtension>());
            }
            _extensions[GetType()].Add(this);
        }

        public static void SaveData()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = File.Create(FileName))
            {
                formatter.Serialize(fileStream, _extensions);
            }
        }

        public static void LoadData()
        {
            if (!File.Exists(FileName)) return;
            var formatter = new BinaryFormatter();
            using (var fileStream = File.OpenRead(FileName))
            {
                _extensions = (Dictionary<Type, List<ClassExtension>>)formatter.Deserialize(fileStream);
            }
        }

        public static List<T> GetAll<T>() where T : ClassExtension
        {
            return !_extensions.ContainsKey(typeof (T)) ? 
                new List<T>() : _extensions[typeof (T)].Select(c => c as T).ToList();
        }
    }
}
