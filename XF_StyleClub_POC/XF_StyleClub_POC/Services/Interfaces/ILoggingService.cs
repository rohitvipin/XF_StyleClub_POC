using System;

namespace XF_StyleClub_POC.Services.Interfaces
{
    public interface ILoggingService
    {
        void Error(Exception exception);
    }
}