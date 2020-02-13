using Glass.Mapper.IoC;
using Glass.Mapper.Maps;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AlexVanWolferen.CustomSitecore.PerformanceCounters.Extensions
{
    public static class MapsConfigFactoryExtension
    {
        public static void AddFluentMaps(this IConfigFactory<IGlassMap> mapsConfigFactory, params string[] assemblyFilters)
        {
            Log.Info($"Glass.Mapper Fluent Mapping loading assemblies by filter {string.Join(",", assemblyFilters)}", new object());
            Assembly[] assemblies = GetAssembliesByFilter(assemblyFilters);

            AddFluentMaps(mapsConfigFactory, assemblies);
        }

        public static void AddFluentMaps(this IConfigFactory<IGlassMap> mapsConfigFactory, params Assembly[] assemblies)
        {
            Log.Info($"Glass.Mapper Fluent Mapping starting!", new object());

            assemblies.ToList().ForEach(assembly =>
            {
                if (assembly.GetReferencedAssemblies().Any(refAssembly => refAssembly.Name.Equals("Glass.Mapper", StringComparison.InvariantCultureIgnoreCase)))
                {
                    Log.Info($"Fluent Mapping Load: {assembly.FullName}", new object());
                    var mappings = assembly.GetTypes().Where(x => typeof(IGlassMap).IsAssignableFrom(x));

                    foreach (var map in mappings)
                    {
                        mapsConfigFactory.Add(() => Activator.CreateInstance(map) as IGlassMap);
                        Log.Info($"Fluent Mapping Loaded: {map.FullName}", new object());
                    }
                }
                else
                {
                    Log.Info($"Skipping {assembly.FullName} it has no Glass.Mapper reference at all.", new object());
                }
            });

            Log.Info($"Glass.Mapper Fluent Mapping completed!", new object());
        }

        private static Assembly[] GetAssembliesByFilter(string[] assemblyFilters)
        {
            List<Assembly> assemblies = new List<Assembly>();

            assemblyFilters.ToList().ForEach(filter => assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.IndexOf(filter.Replace("*", string.Empty), StringComparison.OrdinalIgnoreCase) >= 0)));

            return assemblies.ToArray();
        }
    }
}