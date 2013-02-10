namespace CodeFiction.FastChat.Business.Services
{
    public interface IFileService
    {
        void SaveToFile(string data, string filePath);
        void SaveToFile(byte[] data, string filePath);

        string ReadTextFromFile(string filePath);
        byte[] ReadBinaryFromFile(string filePath);
        bool FileExists(string configurationFile);
    }
}
