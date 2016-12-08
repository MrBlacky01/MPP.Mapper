using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    public class Mapper : IMapper
    {
        private readonly IMapperCache _mapperCache;
        private readonly IMapperFunctionCreator _mappingFunctionCreator;
        private readonly MapperConfiguration _mapperConfiguration;

        public Mapper(IMapperCache cash, IMapperFunctionCreator creator)
        {
            if (cash == null)
            {
                throw new ArgumentNullException(nameof(cash));
            }
            if (creator == null)
            {
                throw new ArgumentNullException(nameof(creator));
            }
            _mapperCache = cash;
            _mappingFunctionCreator = creator;
        }

        public Mapper(MapperConfiguration configuration) : this(new MapperCache(), new MapperFunctionCreator())
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            _mapperConfiguration = configuration;
        }

        public Mapper(IMapperCache cash, IMapperFunctionCreator creator, MapperConfiguration configuration) : this(cash, creator)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            _mapperConfiguration = configuration;
        }
        

        public Mapper() : this(new MapperCache(), new MapperFunctionCreator())
        {

        }

        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var mappingInfo = new MappingPair()
            {
                Source = typeof(TSource),
                Destination = typeof(TDestination)
            };
        
            var mappingFunc = GetMappingFunction<TSource, TDestination>(mappingInfo);

            return mappingFunc(source);
        }

        private Func<TSource, TDestination> GetMappingFunction<TSource, TDestination>(MappingPair mappingInfo)
            where TDestination : new()
        {
            Func<TSource, TDestination> result;
            if (_mapperCache.Contains(mappingInfo))
            {
                result = ((Func<TSource, TDestination>)_mapperCache.GetCache(mappingInfo));
            }
            else
            {
                List<MappingPropertyInfoPair> mappingProperties = GetMappingProperties(mappingInfo);

                result = _mappingFunctionCreator.CreateFunction<TSource, TDestination>(mappingProperties);
                _mapperCache.Add(mappingInfo, result);
            }

            return result;
        }

        private static List<MappingPropertyInfoPair> GetMappingProperties(MappingPair mappingInfo)
        {   
            return (from sourceProperty in mappingInfo.Source.GetProperties()
                    join destinationProperty in mappingInfo.Destination.GetProperties()
                    on sourceProperty.Name equals destinationProperty.Name
                    where destinationProperty.CanWrite && TypeChecker.Check(sourceProperty.PropertyType, destinationProperty.PropertyType)
                    select new MappingPropertyInfoPair(sourceProperty,destinationProperty)).ToList();
        }
    }
}
