using FluentAssertions;
using System;
using Xunit;

namespace SmallHax.MessageSystem.Tests
{
    public class SubscriptionTests
    {
        [Fact]
        public void EnqueueAndDequeueMessageTest()
        {
            // Arrange
            var subscription = new Subscription();
            var message = new Object();

            // Act
            subscription.EnqueueMessage(message);
            var dequeuedMessage = subscription.DequeueMessage();

            // Assert
            dequeuedMessage.Should().Be(message);
        }

        [Fact]
        public void DequeueMessageRemovesMessageFromSubscriptionTest()
        {
            // Arrange
            var subscription = new Subscription();
            var message = new Object();

            // Act
            subscription.EnqueueMessage(message);
            subscription.DequeueMessage();
            var dequeuedMessage = subscription.DequeueMessage();

            // Assert
            dequeuedMessage.Should().BeNull();
        }
    }
}
