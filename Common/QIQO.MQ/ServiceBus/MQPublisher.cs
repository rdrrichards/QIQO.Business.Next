
namespace QIQO.MQ
{
    public interface IMQPublisher
    {
        void Send(object thing, string routingKey);
    }
    public class MQPublisher : Publisher, IMQPublisher
    {
        public void Send(object thing, string routingKey)
        {
            SendMessage(thing, routingKey);
        }
    }

    //public interface IMQConsumer
    //{
    //    void Pull(string routingKey);
    //}
    //public class MQConsumer : Consumer, IMQConsumer
    //{
    //    public void Pull(string routingKey)
    //    {
    //        ReceiveMessage();
    //    }
    //}
}
