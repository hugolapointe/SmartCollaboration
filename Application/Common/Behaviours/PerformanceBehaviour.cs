using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours {

    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
        private const int REQUEST_TIME_THREASHOLD_MS = 500;
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly ICurrentUserService currentUserService;
        private readonly IUserService identityService;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentUserService currentUserService,
            IUserService identityService) {
            timer = new Stopwatch();

            this.logger = logger;
            this.currentUserService = currentUserService;
            this.identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
            timer.Start();
            var response = await next();
            timer.Stop();

            var elapsedMilliseconds = timer.ElapsedMilliseconds;
            var requestName = typeof(TRequest).Name;

            if (elapsedMilliseconds < REQUEST_TIME_THREASHOLD_MS) {
                return response;
            }

            if (!currentUserService.IsAuthenticated) {
                logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    requestName, elapsedMilliseconds, request);
                return response;
            }

            var userId = currentUserService.UserId;
            var userName = await identityService.GetUserNameAsync(userId);

            logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);

            return response;
        }
    }
}
