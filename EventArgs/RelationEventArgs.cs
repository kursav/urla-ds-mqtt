using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Urla.DS.MQTT.Models;

namespace Urla.DS.MQTT.EArgs
{
    public class RelationEventArgs : EventArgs
    {
        public Relation Relation { get; set; }
        public RelationEventArgs(Relation relation)
        {
            Relation = relation;
        }

    }
}
