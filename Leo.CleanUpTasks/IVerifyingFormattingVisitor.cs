namespace Leo.CleanUpTasks
{
    using Sdl.FileTypeSupport.Framework.Formatting;

    public interface IVerifyingFormattingVisitor : IFormattingVisitor
    {
        bool ShouldRemoveTag();
    }
}