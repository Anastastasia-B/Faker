using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    class PluginLoader
    {
        private static readonly string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugins");

        public static List<IGenerator> LoadPlugins(List<IGenerator> generatorsList)
        {
            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
            if (!pluginDirectory.Exists) pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                Assembly asm = Assembly.LoadFrom(file);
                var types = asm.GetTypes().
                                Where(t => t.GetInterfaces().
                                Where(i => i.FullName == typeof(IGenerator).FullName).Any());

                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IGenerator;
                    generatorsList.Add(plugin);
                }
            }
            return generatorsList;
        }
    }
}
