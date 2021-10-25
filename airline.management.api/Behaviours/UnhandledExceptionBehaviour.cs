using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace airline.management.api.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch(Exception ex) 
            {
                var requestName = typeof(TRequest).Name;

                Console.WriteLine($"--> Unhandled Exception for Request {requestName} {request}. Exception: {ex}");

                throw;
            }
        }
    }
}
