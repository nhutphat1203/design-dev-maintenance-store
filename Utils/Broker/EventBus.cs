using System;
using System.Collections.Generic;

namespace CuahangNongduoc.Utils.Broker
{
    public class EventBus
    {
        private readonly Dictionary<string, List<Delegate>> _subscribers = new Dictionary<string, List<Delegate>>();

        private static EventBus _instance;
        public static EventBus Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventBus();
                }
                return _instance;
            }
        }

        public void Subscribe<T>(string topic, Action<T> handler)
        {
            if (!_subscribers.ContainsKey(topic))
                _subscribers[topic] = new List<Delegate>();
            _subscribers[topic].Add(handler);
        }


        public void Unsubscribe<T>(string topic, Action<T> handler)
        {
            if (_subscribers.ContainsKey(topic))
                _subscribers[topic].Remove(handler);
        }


        public void Publish<T>(string topic, T data)
        {
            if (_subscribers.ContainsKey(topic))
            {
                foreach (var handler in _subscribers[topic])
                {
                    if (handler is Action<T> typedHandler)
                        typedHandler.Invoke(data);
                }
            }
        }
    }
}
