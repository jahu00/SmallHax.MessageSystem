using System;
using System.Collections.Generic;

namespace SmallHax.MessageSystem
{
    public class Topic
    {
        private Dictionary<(object subscriber, Type subscriberMessageType), Subscription> Subscriptions { get; set; } = new Dictionary<(object subscriber, Type type), Subscription>();

        public Subscription Subscribe(object subscriber)
        {
            return Subscribe<object>(subscriber);
        }

        public Subscription Subscribe<TSubscriptionMessage>(object subscriber) where TSubscriptionMessage : class
        {
            var subscriberMessageType = typeof(TSubscriptionMessage);
            var subscription = new Subscription();
            Subscriptions.Add((subscriber: subscriber, subscriberMessageType: subscriberMessageType), subscription);
            return subscription;
        }

        public void Unsubscribe(object subscriber)
        {
            Unsubscribe<object>(subscriber);
        }

        public void Unsubscribe<TSubscriptionMessage>(object subscriber)
        {
            var subscriberMessageType = typeof(TSubscriptionMessage);
            Subscriptions.Remove((subscriber: subscriber, subscriberMessageType: subscriberMessageType));
        }

        public Subscription GetSubscription(object subscriber)
        {
            return GetSubscription<object>(subscriber);
        }

        public Subscription GetSubscription<TSubscriptionMessage>(object subscriber) where TSubscriptionMessage : class
        {
            var subscriberMessageType = typeof(TSubscriptionMessage);
            if (Subscriptions.TryGetValue((subscriber: subscriber, subscriberMessageType: subscriberMessageType), out var subscription))
            {
                return subscription;
            }
            return null;
        }

        public void PublishMessage(object message)
        {
            foreach(var subscriptionPair in Subscriptions)
            {
                var subscriptionKey = subscriptionPair.Key;
                var messageType = message.GetType();
                if (!subscriptionKey.subscriberMessageType.IsAssignableFrom(messageType))
                {
                    continue;
                }
                var subscription = subscriptionPair.Value;
                subscription.EnqueueMessage(message);
            }
        }
    }
}
