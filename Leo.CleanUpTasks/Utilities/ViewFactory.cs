namespace Leo.CleanUpTasks.Utilities
{
    using Dialogs;
    using System;

    public static class ViewFactory
    {
        public static T Create<T>(ICleanUpConversionSettings settings, ConversionFileViewMode viewMode, BatchTaskMode taskMode)
        {
            if (typeof(T) == typeof(IConversionFileView))
            {
                IConversionFileView view = new ConversionFileView(settings);
                view.SetPresenter(new ConversionFileViewPresenter(view, new FileDialog(), viewMode, taskMode));
                
                return (T)view;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}