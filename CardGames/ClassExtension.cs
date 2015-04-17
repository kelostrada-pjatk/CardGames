using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public abstract class ClassExtension
    {
        protected ClassExtension()
        {
            AddToExtensions();
        }

        private static readonly Dictionary<Type, List<ClassExtension>> Extensions = new Dictionary<Type, List<ClassExtension>>();

        private void AddToExtensions()
        {
            if (!Extensions.ContainsKey(GetType()))
            {
                Extensions.Add(GetType(), new List<ClassExtension>());
            }
            Extensions[GetType()].Add(this);
        }

        public static void SaveData()
        {
            
        }

        public static void LoadData()
        {
            
        }

    }
}
