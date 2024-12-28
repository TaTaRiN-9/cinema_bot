namespace audit.FileService
{
    public interface IFileAction
    {
        bool Write(string content);
        Task<string> Read(Guid chat_id);
    }
}