// Copyright © K-Society and contributors. All rights reserved. Licensed under the K-Society License. See LICENSE.TXT file in the project root for full license information.

namespace KSociety.Base.EventBus.Abstractions.EventBus
{
    using System.Threading;
    using System.Threading.Tasks;
    using Handler;

    public interface IEventBusRpcClient<TIntegrationEventReply> : IEventBus
        where TIntegrationEventReply : IIntegrationEventReply, new()
        //where TIntegrationEvent : IIntegrationEvent, new()
        //where TIntegrationEventReply : IIntegrationEventReply, new()
    {
        //Task<TIntegrationEventReply> CallAsync<TIntegrationEventReply>(T @event,
        //    CancellationToken cancellationToken = default)
        //    where TIntegrationEventReply : IIntegrationEventReply;

        void Initialize(CancellationToken cancel = default);

        Task<TIntegrationEventReply> CallAsync<TIntegrationEventRpc>(TIntegrationEventRpc @event, CancellationToken cancellationToken = default)
            where TIntegrationEventRpc : IIntegrationEventRpc, new();

        //IIntegrationRpcClientHandler<TIntegrationEventReply> GetIntegrationRpcClientHandler<TIntegrationEventReply>()
        //    where TIntegrationEventReply : IIntegrationEventReply;

        IIntegrationRpcClientHandler<TIntegrationEventReply> GetIntegrationRpcClientHandler();

        //ValueTask SubscribeRpcClient<TIntegrationEventReply, TH>(string replyRoutingKey)
        //    where TIntegrationEventReply : IIntegrationEventReply
        //    where TH : IIntegrationRpcClientHandler<TIntegrationEventReply>;

        ValueTask SubscribeRpcClient<TIntegrationEventHandler>(string replyRoutingKey, bool asyncMode = true)
            where TIntegrationEventHandler : IIntegrationRpcClientHandler<TIntegrationEventReply>;

        //void UnsubscribeRpcClient<TIntegrationEventReply, TH>(string routingKey)
        //    where TIntegrationEventReply : IIntegrationEventReply
        //    where TH : IIntegrationRpcClientHandler<TIntegrationEventReply>;

        void UnsubscribeRpcClient<TIntegrationEventHandler>(string routingKey)
            where TIntegrationEventHandler : IIntegrationRpcClientHandler<TIntegrationEventReply>;
    }
}
