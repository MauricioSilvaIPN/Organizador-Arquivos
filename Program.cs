using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Organizador;

public class DirOrganization
{
    string destinyPath = "";

    static void Main(string[] args)
    {
        var dirClass = new DirOrganization();

        dirClass.ShowAndGetInput();
    }

#region FILE LOGICS
    public void IdentifyFile()
    {
        List<String> fileTypes = [".png", ".pdf", ".txt", ".mp4", ".wav", ".jpg", ".jpeg"];
        List<String> dirNames = ["Documentos/", "Músicas/", "Vídeos/", "Imagens/"];

        string currentDir;
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string path;

        
        foreach (string file in fileTypes)
        {
            switch (file)
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                    currentDir = dirNames[3];
                    path = Path.Combine(userPath, currentDir);
                    break;

                case ".mp4":
                    currentDir = dirNames[2];
                    path = Path.Combine(userPath, currentDir);
                    break;
                
                case ".wav":
                    currentDir = dirNames[1];
                    path = Path.Combine(userPath, currentDir);
                    break;

                default:
                    currentDir = dirNames[0];
                    path = Path.Combine(userPath, currentDir);
                    break;
            }

            GetSpecificFiles(file, path);
        }

    }


    public void GetSpecificFiles(string fileType, string dirDirection)
    {
        string[] files = Directory.GetFiles(destinyPath, $"*{fileType}");

        

        foreach(string file in files)
        {
            string filename = Path.GetFileName(file);

            File.Move(file, Path.Combine(dirDirection, filename), overwrite:true);
        }
    }

    private void ShowAndGetInput()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("Insira um caminho válido");
        Console.WriteLine("=====================================");

        string? finalPath = Console.ReadLine();

        while (!Directory.Exists(finalPath) || finalPath.Length <= 0)
        {
            Console.WriteLine("Esse caminho é inválido, insira um correto:");
            finalPath = Console.ReadLine();
        }

        if (Directory.Exists(finalPath))
        {
            Console.WriteLine($"Obrigado por inserir o caminho {finalPath}");
            destinyPath = finalPath;
            IdentifyFile();
            Console.WriteLine($"Seus arquivos dentro da pasta {finalPath}, já foram organizados em suas respectivas pastas conforme extensão dos arquivos");
        }
    }
#endregion
}