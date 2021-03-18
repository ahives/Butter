namespace Butter
{
    using System;
    using System.Collections.Generic;
    using Builders;
    using Notification;
    using Specification;

    public interface IFieldList :
        IObservable<NotificationContext>, IReadOnlyFieldList, IEquatable<IFieldList>
    {
        void Add(PrimitiveField field);

        void Add<TBuilder>(Func<TBuilder, PrimitiveField> criteria)
            where TBuilder : IFieldBuilder;

        void AddRange(params PrimitiveField[] fields);

        void AddRange(IList<PrimitiveField> field);

        PrimitiveField Remove(int index);

        PrimitiveField Remove(string id);

        bool TryRemove(int index, out PrimitiveField field);

        bool TryRemove(string id, out PrimitiveField field);

        PrimitiveField Replace(int index, PrimitiveField field);

        PrimitiveField Replace(string id, PrimitiveField field);

        bool TryReplace(int index, PrimitiveField field, out PrimitiveField replaced);

        bool TryReplace(string id, PrimitiveField field, out PrimitiveField replaced);
    }
}