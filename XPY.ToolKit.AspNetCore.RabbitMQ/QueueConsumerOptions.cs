using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.RabbitMQ
{
    /// <summary>
    /// Rabbit Queue Consumer參數
    /// </summary>
    /// <typeparam name="TConsumer">Queue Consumer類型</typeparam>
    public class QueueConsumerOptions<TConsumer>
        where TConsumer : QueueConsumerBase
    {
        /// <summary>
        /// Queue名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 持續性
        /// </summary>
        public bool Durable { get; set; }

        /// <summary>
        /// 單一連線
        /// </summary>
        public bool Exclusive { get; set; }

        /// <summary>
        /// 自動刪除
        /// </summary>
        public bool AutoDelete { get; set; }

        /// <summary>
        /// 自動ACK
        /// </summary>
        public bool AutoAck { get; set; }
        public IDictionary<string, object> Arguments { get; set; }
    }
}
