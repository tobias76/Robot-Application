namespace RobotApp.Utils
{
    public class ReaderSingleton<T> where T : class
    {
        private static readonly object maximumSecurityGuard = new object();
        private static ReaderSingleton<string[]> _instance;

        public IEnumerable<string> fileContents = new List<string>();

        public ReaderSingleton()
        {

        }

        protected ReaderSingleton(string[] filePath)
        {
            fileContents = readFile(filePath[0]);
        }

        public static ReaderSingleton<string[]> Instance(params string[] filePath)
        {
            lock (maximumSecurityGuard)
            {

                if (_instance == null)
                {
                    _instance = new ReaderSingleton<string[]>(filePath);
                }

                return _instance;

            }

        }


        internal IEnumerable<string> readFile(string filePath)
        {

            string line;

            if (File.Exists(filePath))
            {
                using var reader = new StreamReader(filePath);

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
