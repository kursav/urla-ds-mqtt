# Urla Digital Solutions MQTT Service

## How can be service created and subscribed?
    
    UrlaMQTTService mQTT = new UrlaMQTTService();
    mQTT.OnRelationCreated += (s, e) => { Console.WriteLine(e?.Relation?.AccountId.ToString() ?? "error"); };
    await mQTT.ConnectAsync("username", "password");
    await mQTT.SubscribeAsync("uuid");