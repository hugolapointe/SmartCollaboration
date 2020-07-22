using System;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;

using MediatR.Pipeline;

using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours {

    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> {
        private readonly ILogger logger;
        private readonly ICurrentUserService currentUserService;
        private readonly IUserService identityService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService, IUserService identityService) {
            this.logger = logger;
            this.currentUserService = currentUserService;
            this.identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken) {
            var requestName = typeof(TRequest).Name;

            if (!currentUserService.IsAuthenticated) {
                logger.LogInformation("Request: {Name} {@Request}",
                    requestName, request);
                return;
            }

            var userId = currentUserService.UserId;
            var userName = await identityService.GetUserNameAsync(userId);

            logger.LogInformation("Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, request);
        }
    }
}
