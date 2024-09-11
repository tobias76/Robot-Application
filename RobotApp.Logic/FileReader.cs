namespace RobotApp.Utils
{
    public class FileReader<T> : ReaderSingleton<T> where T : class
    {
        protected FileReader(string[] filePath) : base(filePath)
        {

        }
    }
}
