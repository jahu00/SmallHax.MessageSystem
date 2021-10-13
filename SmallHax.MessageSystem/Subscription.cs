using System;
using System.Collections.Generic;
using System.Text;

namespace SmallHax.MessageSystem
{
    public class Subscription : Subscription<object>
    {
    }

    public class Subscription<TMessage> where TMessage : class
    {
        private Queue<TMessage> Messages { get; set; } = new Queue<TMessage>();

        public void EnqueueMessage(TMessage message)
        {
            Messages.Enqueue(message);
        }

        public TMessage DequeueMessage()
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
