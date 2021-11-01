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
            var message = new object();

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

        [Fact]
        public void HasMessageTest()
        {
            // Arrange
            var subscription = new Subscription();
            var message = new object();

            // Act
            subscription.EnqueueMessage(message);
            var hasMessage = subscription.HasMessage;

            // Assert
            hasMessage.Should().BeTrue();
        }

        [Fact]
        public void HasMessageNegativeTest()
        {
            // Arrange
            var subscription = new Subscription();

            // Act
            var hasMessage = subscription.HasMessage;

            // Assert
            hasMessage.Should().BeFalse();
        }

        [Fact]
        public void ClearMessagesTest()
        {
            // Arrange
            var subscription = new Subscription();
            var message = new object();

            // Act
            subscription.EnqueueMessage(message);
            subscription.Clear();
            var hasMessage = subscription.HasMessage;

            // Assert
            hasMessage.Should().Be(false);
        }
    }
}
