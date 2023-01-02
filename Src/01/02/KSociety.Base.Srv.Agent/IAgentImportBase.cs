﻿using System.Threading;

namespace KSociety.Base.Srv.Agent
{
    public interface IAgentImportBase<in TImportReq, out TImportRes>
        where TImportReq : class
        where TImportRes : class
    {
        TImportRes ImportData(TImportReq importReq, CancellationToken cancellationToken = default);
    }
}