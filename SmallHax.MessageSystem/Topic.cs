using System;
using System.Collections.Generic;

namespace SmallHax.MessageSystem
{
    public class Topic : Topic<object>
    {

    }

    public class Topic<TMessage> where TMessage : class
    {
        private Dictionary<object, Subscription<TMessage>> Subscriptions { get; set; } = new Dictionary<object, Subscription<TMessage>>();
        public Subscription<TMessage> Subscribe(object subscriber)
        {
            var subscription = new Subscription<TMessage>();
            Subscriptions.Add(subscriber, subscription);
            return subscription;
        }

        public void Unsubscribe(object subscriber)
        {
            Subscriptions.Remove(subscriber);
        }

        public Subscription<TMessage> GetSubscription(object subscriber)
        {
            if (Subscriptions.TryGetValue(subscriber, out var subscription))
            {
                return subscription;
            }
            return null;
        }

        public void PublishMessage(TMessage message)
        {
            foreach(var subscription in Subscriptions.Values)
            {
                subscription.EnqueueMessage(message);
            }
        }
    }
}
