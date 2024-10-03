namespace VoiceInspection.Tab.CL.Models
{
    public class WindowManager
    {
        private static WindowManager instance;

        public WindowManager()
        {
            
        }

        public MainWindow MainWindow { get; set; }

        public SubWindowView SubWindow { get; set; }

        public static WindowManager GetInstance()
        {
            if (instance == null)
            {
                instance = new WindowManager();
            }

            return instance;
        }
    }
}
