using DataMock.Behaviors;
using DataMock.Handlers;
using System;
using System.Collections.Generic;

namespace DataMock.Configuration
{
    public class Configure : IConfigure
    {
        private readonly Dictionary<Type, IHandler> handlers = new Dictionary<Type, IHandler>();
        private readonly Dictionary<Type, IBehavior> behaviors = new Dictionary<Type, IBehavior>();

        private static readonly Lazy<Configure> obj = new Lazy<Configure>(() => new Configure());

        private Configure() { }

        public static Configure Current
        {
            get
            {
                return obj.Value;
            }
        }
        
        public void RegisterHandle(Type type, IHandler handler)
        {
            if (!handlers.ContainsKey(type))
            {
                handlers.Add(type, handler);
            }
        }

        public bool TryGetHandler(Type type, out IHandler handler)
        {
            return handlers.TryGetValue(type, out handler);
        }

        //Decommenta e se aggiungi un elemento già presente lo deve aggiornare
        public void RegisterBehavior<T>(IBehavior behaviorConfiguration) where T : IBehavior
        {
            if (behaviors.ContainsKey(typeof(T)))
            {
                behaviors.Remove(typeof(T));
            }
            behaviors.Add(typeof(T), behaviorConfiguration);
        }

        public bool TryGetBehavior<T>(out IBehavior behaviorConfiguration) where T : IBehavior
        {
            return behaviors.TryGetValue(typeof(T), out behaviorConfiguration);
        }
    }
}
