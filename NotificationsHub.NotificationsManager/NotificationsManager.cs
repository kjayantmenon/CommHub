using NotificationManager.Contracts;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using NotificationsHub.Models;
using NotificationsHub.Contracts;
using NotificationsHub.Channels;
using Autofac;
using Email.Channel;
using Serilog;
using CommunicationsHub.Common;

namespace NotificationManager
{
    public class NotificationManager : INotificationManager
    {
        IContainer _container = null;
        ILogger _logger = null;
        public NotificationManager()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<NotificationHubChannel>().As<IChannel>();
            //_container = builder.Build();    
        }

        public NotificationManager(ILogger logger)
        {
            _logger = logger;
        }
        
        public async Task<string> NotifyAsync(Message message)
        {

            return await NotifyAsync(message, Guid.NewGuid().ToString());
        }

        

        public async Task<string> NotifyAsync(Message message, string ActivityId)
        {
            _logger.Information($"{ActivityId} Notification Manager - NotifyAsync - start");
            var publisherId = "1";
            var notificationId = Guid.NewGuid();
            var channels = new ChannelFactory(_logger)
                .GetChannelsForPublisher(publisherId);

            foreach (var channel in channels)
            {
                await channel.Send(message, ActivityId);
            }

            _logger.Information($"{ActivityId} Notification Manager - NotifyAsync - start");
            return notificationId.ToString();

        }

        public async Task<string> RegisterApplicationChannels(string appId, NotificationType[] notificationTypes)
        {
            _logger.Verbose($"{appId} - Application Registration started...");
            var regId = Guid.NewGuid();
            _logger.Information($"{appId} - Registration complete with registration Id {regId}.");
            return regId.ToString();
        }
    }

  
    public class ChannelFactory
    {
        IContainer _container = null;
        ILogger _logger = null;
        public ChannelFactory(ILogger logger)
        {
            _logger = logger;
                var builder = new ContainerBuilder();
                builder.RegisterType<NotificationHubChannel>()
                .WithParameter("logger", _logger)
                .Keyed<IChannel>(NotificationType.NotificationHub);
                builder.RegisterType<EmailChannel>()
                .WithParameter("logger", _logger)
                .Keyed<IChannel>(NotificationType.Email);

            //builder.Register<IChannel>(c => 
            //{
            //    var context = c.Resolve<IComponentContext>();
            //    return t => context.Resolve<IIndex<NotificationType, IChannel>>()[t];
            //});
            _container = builder.Build();

            }
        internal List<IChannel> GetChannelsForPublisher(string publisherId)
        {
            var channelList = new List<IChannel>();
            channelList.Add(_container.ResolveKeyed<IChannel>(NotificationType.Email));
            var channel = _container.ResolveKeyed<IChannel>(NotificationType.NotificationHub);

            channelList.Add(channel);
            channelList.Add(_container.ResolveKeyed<IChannel>(NotificationType.Email));
            return channelList;
        }
    }
    
}
