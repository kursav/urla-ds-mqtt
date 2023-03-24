using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Urla.DS.MQTT.Models
{
    public enum Languages
    {
        None = 0,
        [Description("Deutsch")] de = 83,
        [Description("Türkçe")] tr = 228,
        //[Description("Serbia")] rs = 197,
        [Description("English")] en = 235,
    }
}
