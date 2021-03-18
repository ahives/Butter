namespace Butter
{
    using System;
    using Specification;

    public interface IReadOnlyFieldList :
        IEquatable<IReadOnlyFieldList>
    {
        bool HasValues { get; }
        
        int Count { get; }
        
        PrimitiveField this[int index] { get; }
        
        PrimitiveField this[string id] { get; }

        bool TryGetValue(int index, out PrimitiveField field);

        bool TryGetValue(string id, out PrimitiveField field);

        bool Contains(PrimitiveField field);

        bool Contains(string id);

        void Sort();
    }
}