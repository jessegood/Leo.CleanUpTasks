namespace Leo.CleanUpTasks
{
    using Contracts;
    using Sdl.FileTypeSupport.Framework.BilingualApi;
    using System.Diagnostics.Contracts;

    [ContractClass(typeof(ISegmentHandlerContract))]
    public interface ISegmentHandler : IMarkupDataVisitor
    {
    }
}