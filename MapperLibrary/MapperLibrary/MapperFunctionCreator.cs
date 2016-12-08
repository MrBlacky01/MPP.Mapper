using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MapperLibrary
{
    internal class MapperFunctionCreator : IMapperFunctionCreator
    {
        public Func<TSource, TDestination> CreateFunction <TSource, TDestination> (IEnumerable<MappingPropertyInfoPair> properties)
            where TDestination : new()
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            Type creatingType = typeof(TDestination);
            var sourceParameter = Expression.Parameter(typeof(TSource), "source");
            var creator = Expression.New(creatingType);
            var valuesAssignments = new List<MemberBinding>();

            foreach (var propertyPair in properties)
            {
                Expression expressionProperty = Expression.Property(sourceParameter, propertyPair.SourceProperty);
                expressionProperty = Expression.Convert(expressionProperty, propertyPair.DestinationProperty.PropertyType);
                valuesAssignments.Add(Expression.Bind(propertyPair.DestinationProperty, expressionProperty));
            }

            var memberInit = Expression.MemberInit(creator, valuesAssignments);
            return Expression.Lambda<Func<TSource, TDestination>>(memberInit, sourceParameter).Compile();
        }     
    }
}

