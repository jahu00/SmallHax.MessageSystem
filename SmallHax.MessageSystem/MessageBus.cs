using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallHax.MessageSystem
{
    public class MessageBus<TTopicKey> where TTopicKey : Enum
    {
        private Dictionary<TTopicKey, Topic> Topics { get; set; } = new Dictionary<TTopicKey, Topic>();

        public MessageBus()
        {
            Initialize();
        }

        private void Initialize()
        {
            var topicKeyType = typeof(TTopicKey);
            var keys = Enum.GetValues(topicKeyType).Cast<TTopicKey>();
            foreach (var key in keys)
            {
                Topics[key] = new Topic();
            }
        }

        public Topic this[TTopicKey topicKey]
        {
            get
            {
                return Topics[topicKey];
            }
        }
    }
}
