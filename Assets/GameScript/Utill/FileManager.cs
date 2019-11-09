

using System.IO;

public class FileManager 
{

    static void CreatFolder(string path)
    {

        string folderPath = "./"+path;
        DirectoryInfo di = new DirectoryInfo(folderPath);
        if (di.Exists == false)
        {
            di.Create();
        }

    }


}
