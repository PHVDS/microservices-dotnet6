using GeekShopping.MessageBus;

namespace GeekShopping.CartAPI.Model.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        public void SendMEssage(BaseMessage baseMessage, string queueName);
    }
}
