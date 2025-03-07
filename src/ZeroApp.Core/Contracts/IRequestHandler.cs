namespace ZeroApp.Core.Contracts;

public interface IRequestHandler<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request);
}