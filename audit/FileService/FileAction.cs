using System.Text;

namespace audit.FileService
{
    public class FileAction : IFileAction
    {
        private readonly string filename = "text.txt";
        private readonly string path;
        private readonly ILogger<FileAction> _logger;

        public FileAction(ILogger<FileAction> logger)
        {
            path = Directory.GetCurrentDirectory();
            _logger = logger;
        }

        public bool Write(string content)
        {
            try
            {
                _logger.LogInformation("Запись в файл.");
                FileStream fs = File.OpenWrite(Path.Combine(path, filename));
                byte[] buffer = Encoding.Default.GetBytes(content);
                fs.WriteAsync(buffer);

                buffer = Encoding.Default.GetBytes("next");
                fs.WriteAsync(buffer);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Что-то пошло не так при записи в файл: " + DateTime.Now);
                return false;
            }
        }

        public async Task<string> Read(Guid chat_id)
        {
            string id_string = chat_id.ToString();

            string content = await File.ReadAllTextAsync(Path.Combine(path + filename));

            _logger.LogInformation("Чтение из файла: " +  id_string);

            StringBuilder result = new StringBuilder();

            foreach (var item in content.Split("next"))
            {
                if (item.Contains(id_string))
                {
                    result.Append(item);
                }
            }

            return result.ToString();
        }
    }
}
