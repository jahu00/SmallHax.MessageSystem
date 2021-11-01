using System;
using System.Collections.Generic;
using System.Text;

namespace SmallHax.MessageSystem
{
    public class Subscription
    {
        private Queue<object> Messages { get; set; } = new Queue<object>();
        public bool HasMessage => Messages.Count > 0;

        public void EnqueueMessage(object message)
        {
            Messages.Enqueue(message);
        }

        public object DequeueMessage()
        {
            if (!HasMessage)
            {
                return null;
            }
            var message = Messages.Dequeue();
            return message;
        }

        public TMessage DequeueMessage<TMessage>()
        {
            return (TMessage)DequeueMessage();
        }

        public void Clear()
        {
            Messages.Clear();
        }
    }
}
