﻿using System;
using RabbitMQ.Client;

namespace Burrow
{
    public interface ITunnel : IDisposable
    {
        event Action OnOpened;

        event Action OnClosed;

        /// <summary>
        /// This event will be fired once a consumer is disconnected, for example you ack a msg with wrong delivery id (I blame RabbitMQ.Client guys)
        /// </summary>
        event Action<Subscription> ConsumerDisconnected;

        bool IsOpened { get; }

        void Publish<T>(T rabbit, Action<IBasicProperties> configure = null);

        void Publish<T>(T rabbit, string routingKey, Action<IBasicProperties> configure = null);
        
        /// <summary>
        /// Subscribe to queue by using subscriptionName, the message will be automatically acked once the callback executed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionName">SubscriptionName together with the type of Message can be used to define the queue name in IRouteFinder</param>
        /// <param name="onReceiveMessage">A callback method to process received message</param>
        void Subscribe<T>(string subscriptionName, Action<T> onReceiveMessage);

        /// <summary>
        /// Subscribe to queue by using subscriptionName, the message will be not automatically acked
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionName">SubscriptionName together with the type of Message can be used to define the queue name in IRouteFinder</param>
        /// <param name="onReceiveMessage">A callback method to process received message</param>
        /// <returns>Subscription object which can be used to send Ack or NoAck message to server by the delivery tag received in the callback</returns>
        Subscription Subscribe<T>(string subscriptionName, Action<T, MessageDeliverEventArgs> onReceiveMessage);

        /// <summary>
        /// Subscribe to queue by using subscriptionName, the message will be automatically acked once the callback executed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionName">SubscriptionName together with the type of Message can be used to define the queue name in IRouteFinder</param>
        /// <param name="onReceiveMessage">A callback method to process received message</param>
        /// <param name="batchSize">The number of threads to process messaages, Default is Global.DefaultConsumerBatchSize</param>
        void SubscribeAsync<T>(string subscriptionName, Action<T> onReceiveMessage, ushort? batchSize = null);

        /// <summary>
        /// Subscribe to queue by using subscriptionName, the message will be not automatically acked
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subscriptionName">SubscriptionName together with the type of Message can be used to define the queue name in IRouteFinder</param>
        /// <param name="onReceiveMessage">A callback method to process received message</param>
        /// <param name="batchSize">The number of threads to process messaages, Default is Global.DefaultConsumerBatchSize</param>
        /// <returns>Subscription object which can be used to send Ack or NoAck message to server by the delivery tag received in the callback</returns>
        Subscription SubscribeAsync<T>(string subscriptionName, Action<T, MessageDeliverEventArgs> onReceiveMessage, ushort? batchSize = null);

        void SetRouteFinder(IRouteFinder routeFinder);

        void SetSerializer(ISerializer serializer);

        void SetPersistentMode(bool persistentMode);
    }
}
