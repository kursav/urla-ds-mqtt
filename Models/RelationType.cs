using System;
using System.Collections.Generic;
using System.Text;

namespace Urla.DS.MQTT.Models
{
    [Flags]
    public enum RelationType : long
    {
        None = 0,
        Employee = 1,
        Customer = 2,
        Supplier = 4,
        Friend = 8,
        RegularCustomer = 16,
        Manager = 32,
        All = 64,
    }
}
