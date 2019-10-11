using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.RabbitMQ
{
    /// <summary>
    /// Rabbit Queue Consumer基礎類別
    /// </summary>
    public abstract class QueueConsumerBase
    {
        /// <summary>
        /// RabbitMQ.Client套件的Consumer實例
        /// </summary>
        public EventingBasicConsumer Consumer { get; }

        /// <summary>
        /// Queue Consumer基礎類別建構子
        /// </summary>
        /// <param name="consumer">Consumer實例</param>
        public QueueConsumerBase(
            EventingBasicConsumer consumer)
        {
            Consumer = consumer;
        }
    }
}