﻿using System;

namespace FridgeManager.FridgesMicroService.Services.Options
{
    public class RedisOptions
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string LeaderBoardKey { get; set; }

        public TimeSpan LeaderBoardExpire { get; set; }
    }
}
