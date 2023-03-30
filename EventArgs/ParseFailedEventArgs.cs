using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Urla.DS.MQTT.Models;

namespace Urla.DS.MQTT.EArgs
{
    public class ParseFailedEventArgs : EventArgs
    {
        public Exception Exception { get; set; }
        public MqttApplicationMessageReceivedEventArgs MessageReceivedventArgs { get; set; }

        public ParseFailedEventArgs(Exception exception, MqttApplicationMessageReceivedEventArgs e)
        {
            Exception = exception;
            MessageReceivedventArgs = e;
        }

    }
}
