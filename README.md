# Urla Digital Solutions MQTT Service

## How can be service created and subscribed?
    
    UrlaMQTTService mQTT = new UrlaMQTTService();
    mQTT.OnRelationCreated += (s, e) => { Console.WriteLine(e?.Relation?.AccountId.ToString() ?? "error"); };
    await mQTT.ConnectAsync("burak-erdogmus", "erdogmus1980");
    await mQTT.SubscribeAsync("70673550-b9f2-4477-98c9-e61dbb633c8b");
