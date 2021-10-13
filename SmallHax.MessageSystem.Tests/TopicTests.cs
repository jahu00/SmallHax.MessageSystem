using FluentAssertions;
using System;
using Xunit;

namespace SmallHax.MessageSystem.Tests
{
    public class TopicTests
    {
        [Fact]
        public void SubscribeAndGetSubscriberTest()
        {
            // Arrange
            var topic = new Topic();
            var subscriber = new Object();

            // Act
            var subscriptionFromSubscribe = topic.Subscribe(subscriber);
            var subscriptionFromGetSubscription = topic.GetSubscription(subscriber);

            // Assert
            subscriptionFromSubscribe.Should().NotBeNull();
            subscriptionFromGetSubscription.Should().NotBeNull();
            subscriptionFromGetSubscription.Should().Be(subscriptionFromSubscribe);
        }

        [Fact]
        public void UnsubscribeTest()
        {
            // Arrange
            var topic = new Topic();
            var subscriber = new Object();
            var message = new Object();

            // Act
            var subscriptionFromSubscribe = topic.Subscribe(subscriber);
            topic.Unsubscribe(subscriber);
            var subscriptionFromGetSubscription = topic.GetSubscription(subscriber);
            topic.PublishMessage(message);
            var dequeuedMessage = subscriptionFromSubscribe.DequeueMessage();

            // Assert
            subscriptionFromGetSubscription.Should().BeNull();
            dequeuedMessage.Should().BeNull();
        }

        [Fact]
        public void PublishMessageTest()
        {
            // Arrange
            var topic = new Topic();
            var subscriber1 = new Object();
            var subscriber2 = new Object();
            var message = new Object();

            // Act
            var subscription1 = topic.Subscribe(subscriber1);
            var subscription2 = topic.Subscribe(subscriber2);
            topic.PublishMessage(message);
            var dequeuedMessage1 = subscription1.DequeueMessage();
            var dequeuedMessage2 = subscription2.DequeueMessage();

            // Assert
            dequeuedMessage1.Should().Be(message);
            dequeuedMessage2.Should().Be(message);
        }
    }
}
