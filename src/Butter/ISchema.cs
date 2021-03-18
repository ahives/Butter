namespace Butter
{
    using System;
    using Specification;

    public interface ISchema
    {
        /// <summary>
        /// Read-only list of fields.
        /// </summary>
        IReadOnlyFieldList Fields { get; }

        /// <summary>
        /// Removes the first field matching the criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Remove<T>(Func<T, bool> criteria)
            where T : PrimitiveField;

        /// <summary>
        /// Removes all fields found matching the criteria.
        /// </summary>
        /// <param name="criteria"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IReadOnlyFieldList RemoveAll<T>(Func<T, bool> criteria)
            where T : PrimitiveField;

//        T Modify<T, TBuilder>(Func<T, bool> criteria, Func<TBuilder, T> builder)
//            where T : Field
//            where TBuilder : ISpecificationBuilder;

        string Report();
    }
}