using AutoMapper;
using AutoMapper.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MeetMe.Web.Infrastructure.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            var AllTypes = AppDomain
                .CurrentDomain.
                GetAssemblies()
                .Where(a => a.GetName().Name.Contains("MeetMe"))
                .SelectMany(a => a.GetTypes());
            AllTypes
                .Where(t => t.IsClass && !t.IsAbstract &&
                t.GetInterfaces()
                .Where(i => i.IsGenericType)
                .Select(i => i.GetGenericTypeDefinition())
                .Contains(typeof(IMapFrom<>)))
                .Select(t => new
                {
                    Destination = t,
                    Source = t
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Select(i => new
                {
                    Definition = i.GetGenericTypeDefinition(),
                    Arguments = i.GetGenericArguments()

                })
                .Where(i => i.Definition == typeof(IMapFrom<>))
                .SelectMany(i => i.Arguments)
                .First(),
                }).ToList()
                .ForEach(mapping => this.CreateMap(mapping.Source, mapping.Destination));

            AllTypes
                .Where(t => t.IsClass
                && !t.IsAbstract
                && typeof(IHaveCustomMapping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMapping>()
                .ToList()
                .ForEach(mapping =>mapping.ConfigureMapping(this));
        }
    }
}
