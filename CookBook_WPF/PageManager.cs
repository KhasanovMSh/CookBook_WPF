using System.Windows.Controls;

namespace CookBook_WPF
{
    public static class PageManager
    {
        private static Frame _frameMain;

        public static Frame FrameMain
        {
            get => _frameMain;
            set => _frameMain = value;
        }
    }
}
