using System;
using System.Collections.Generic;
using System.Text;

namespace SmallHax.MessageBus
{
    public class Subscription
    {
        private Queue<object> Messages { get; set; } = new Queue<object>();

        public void EnqueueMessage(object message)
        {
            Messages.Enqueue(message);
        }

        public object DequeueMessage()
        {
            if (Messages.Count == 0)
            {
                return null;
            }
            var message = Messages.Dequeue();
            return message;
        }
    }
}
