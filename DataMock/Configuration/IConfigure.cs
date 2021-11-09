using DataMock.Behaviors;
using DataMock.Handlers;
using System;

namespace DataMock.Configuration
{
    public interface IConfigure
    {
        void RegisterHandle(Type type, IHandler handler);
        bool TryGetHandler(Type type, out IHandler handler);

        void RegisterBehavior<T>(IBehavior behaviorConfiguration) where T : IBehavior;
        bool TryGetBehavior<T>(out IBehavior behaviorConfiguration) where T : IBehavior;
    }
}