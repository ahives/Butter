namespace Butter
{
    using System;
    using System.Linq;
    using Builders;

    public static class Field
    {
        /// <summary>
        /// Returns a field builder from cache memory.
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <returns></returns>
        /// <exception cref="FieldBuilderMissingException"></exception>
        public static TBuilder Builder<TBuilder>()
            where TBuilder : IFieldBuilder
        {
            Type type = typeof(TBuilder)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => typeof(TBuilder).IsAssignableFrom(x) && !x.IsInterface);
            
            if (type == null)
                throw new FieldBuilderMissingException($"Failed to find implementation for builder '{typeof(TBuilder)}'");

            return (TBuilder)Activator.CreateInstance(type);
        }
    }
}