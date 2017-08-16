using EF2.Api.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EF2.Api.Data.Extensions
{
    static class ModelBuilderExtensions
    {
        private static readonly Assembly EntitiesAssembly = typeof(AdventureWorksDbContext).Assembly;
        private static readonly Type EntityActiveableType = typeof(IEntityActiveable);
        private static readonly MethodInfo EntityMethod = typeof(ModelBuilder).GetTypeInfo().GetMethods().Single(x => x.Name == "Entity" && x.IsGenericMethod && x.GetParameters().Length == 0);

        private static IList<Type> _activeablesTypes;
        private static IList<Type> ActiveablesTypes
        {
            get { return _activeablesTypes ?? (_activeablesTypes = EntitiesAssembly.ExportedTypes.Where(t => t.IsClass && t.IsPublic && EntityActiveableType.IsAssignableFrom(t)).ToList()); }
        }

        internal static void SetActiveableQueryFilters(this ModelBuilder modelBuilder)
        {
            foreach (Type type in ActiveablesTypes)
            {
                dynamic entityTypeBuilder = EntityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[0]);

                SetActiveableQueryFilter(entityTypeBuilder);
            }
        }

        private static void SetActiveableQueryFilter<T>(this EntityTypeBuilder<T> entityTypeBuilder)
            where T : class, IEntityActiveable
        {
            entityTypeBuilder.HasQueryFilter(q => q.IsActive);
        }
    }
}