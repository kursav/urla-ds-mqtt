using MQTTnet;
using MQTTnet.Client;
using System.Text;
using System.Text.Json;
using Urla.DS.MQTT.EArgs;
using Urla.DS.MQTT.Models;

namespace Urla.DS.MQTT
{
    public class UrlaMQTTService
    {
        IMqttClient client;
        string subscribedId;
        public UrlaMQTTService()
        {
            var factory = new MqttFactory();
            client = factory.CreateMqttClient();
            client.ConnectedAsync += OnMQTTConnected;
            client.ApplicationMessageReceivedAsync += OnMQTTMessageReceived;
            client.DisconnectedAsync += OnMQTTDisconnected;

        }

        public bool IsConnected { get { return client.IsConnected; } }
        public event EventHandler<MqttClientConnectedEventArgs> OnConnected = delegate { };
        public event EventHandler<RelationEventArgs> OnRelationCreated = delegate { };
        public event EventHandler<MqttClientDisconnectedEventArgs> OnDisconnected = delegate { };
        public event EventHandler<RelationEventArgs> OnRelationUpdated = delegate { };
        public event EventHandler<MqttApplicationMessageReceivedEventArgs> OnOtherMessagesReceived = delegate { };
        public event EventHandler<ParseFailedEventArgs> OnMessageParseFailed = delegate { };

        public async Task ConnectAsync(string user, string password)
        {
            var options = new MqttClientOptionsBuilder()
           .WithTcpServer("mqtt.urla.at", 1883)
           .WithCredentials(user, password)
           .WithCleanSession()
           .Build();

            await client.ConnectAsync(options);
        }

        public async Task SubscribeAsync(string id)
        {
            subscribedId = id;
            if (client.IsConnected)
            {
                var topicFilter = new MqttTopicFilterBuilder().WithTopic($"{subscribedId}/+").Build();
                await client.SubscribeAsync(topicFilter);
            }

        }

        Task OnMQTTConnected(MqttClientConnectedEventArgs e)
        {

            if (OnConnected != null)
            {
                OnConnected(this, e);
            }
            return Task.CompletedTask;
        }

        Task OnMQTTDisconnected(MqttClientDisconnectedEventArgs e)
        {
            if (OnDisconnected != null)
            {
                OnDisconnected(this, e);
            }
            return Task.CompletedTask;
        }

        Task OnMQTTMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                var res = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                if (e.ApplicationMessage.Topic == $"{subscribedId}/users-create")
                {
                    var relation = JsonSerializer.Deserialize<Relation>(res);
                    OnRelationCreated(this, new RelationEventArgs(relation));

                }
                else if (e.ApplicationMessage.Topic == $"{subscribedId}/users-update")
                {
                    var relation = JsonSerializer.Deserialize<Relation>(res);
                    OnRelationUpdated(this, new RelationEventArgs(relation));
                }
                else
                {
                    OnOtherMessagesReceived(this, e);
                }
            }
            catch (Exception ex)
            { OnMessageParseFailed(this, new ParseFailedEventArgs(ex, e)); }
            return Task.CompletedTask;
        }

    }

}