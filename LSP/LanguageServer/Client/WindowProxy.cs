﻿using LanguageServer.Parameters;
using LanguageServer.Parameters.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageServer.Client
{
    public sealed class WindowProxy
    {
        private readonly Connection _connection;

        internal WindowProxy(Connection connection)
        {
            _connection = connection;
        }

        public void ShowMessage(ShowMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<ShowMessageParams>
            {
                method = "window/showMessage",
                @params = @params
            });
        }

        public Task<Result<MessageActionItem, ResponseError>> ShowMessageRequest(ShowMessageRequestParams @params)
        {
            var tcs = new TaskCompletionSource<Result<MessageActionItem, ResponseError>>();
            _connection.SendRequest(
                new RequestMessage<ShowMessageRequestParams>
                {
                    id = IdGenerator.Instance.Next(),
                    method = "window/showMessageRequest",
                    @params = @params
                },
                (ResponseMessage<MessageActionItem> res) => tcs.TrySetResult(Message.ToResult(res)));
            return tcs.Task;
        }

        public void LogMessage(LogMessageParams @params)
        {
            _connection.SendNotification(new NotificationMessage<LogMessageParams>
            {
                method = "window/logMessage",
                @params = @params
            });
        }

        public void Event(dynamic @params)
        {
            _connection.SendNotification(new NotificationMessage<dynamic>
            {
                method = "telemetry/event",
                @params = @params
            });
        }
    }
}
