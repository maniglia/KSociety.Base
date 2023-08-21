// Copyright � K-Society and contributors. All rights reserved. Licensed under the K-Society License. See LICENSE.TXT file in the project root for full license information.

namespace KSociety.Base.EventBus.Test.IntegrationEvent.Event;
using ProtoBuf;

[ProtoContract]
public class TestIntegrationEvent : BaseTestIntegrationEvent
{
    [ProtoMember(1)]
    public string TestName { get; set; }

    [ProtoMember(2)]
    public byte[] ByteArray { get; set; }

    public TestIntegrationEvent() { }

    public TestIntegrationEvent(
        string routingKey,
        string testName,
        byte[] byteArray
    )
        : base(routingKey)
    {
        this.TestName = testName;
        this.ByteArray = byteArray;
    }
}
