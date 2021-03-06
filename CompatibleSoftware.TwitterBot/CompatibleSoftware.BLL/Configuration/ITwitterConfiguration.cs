﻿namespace CompatibleSoftware.BLL.Configuration
{
    public interface ITwitterConfiguration
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
        string Token { get; }
        string TokenSecret { get; }
        string UserName { get; }
    }
}