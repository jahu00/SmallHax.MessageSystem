using System;
using System.Collections.Generic;

namespace SmallHax.MessageBus
{
    public class Topic
    {
        private Dictionary<object, Subscription> Subscriptions { get; set; } = new Dictionary<object, Subscription>();
        public Subscription Subscribe(object subscriber)
        {
            var subscription = new Subscription();
            Subscriptions.Add(subscriber, subscription);
            return subscription;
        }

        public void Unsubscribe(object subscriber)
        {
            Subscriptions.Remove(subscriber);
        }

        public Subscription GetSubscription(object subscriber)
        {
            if (Subscriptions.TryGetValue(subscriber, out var subscription))
            {
                return subscription;
            }
            return null;
        }

        public void PublishMessage(object message)
        {
            foreach(var subscription in Subscriptions.Values)
            {
                subscription.EnqueueMessage(message);
            }
        }
    }
}
