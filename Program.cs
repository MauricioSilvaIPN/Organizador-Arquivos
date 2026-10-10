using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Organizador;

public class DirOrganization
{
    static void Main(string[] args)
    {
        var dirClass = new DirOrganization();

        dirClass.IdentifyFile();
    }

#region FILE LOGICS
    public void IdentifyFile()
    {
        List<String> fileTypes = [".png", ".pdf", ".txt", ".mp4", ".wav", ".jpg", ".jpeg"];
        List<String> dirNames = ["Documentos/", "Músicas/", "Vídeos/", "Imagens/"];

        string currentDir;
        string path;

        
        foreach (string file in fileTypes)
        {
            switch (file)
            {
                case ".png":
                case ".jpg":
                case ".jpeg":
                    currentDir = dirNames[3];
                    path = @$"/home/mauricio/{currentDir}";
                    break;

                case ".mp4":
                    currentDir = dirNames[2];
                    path = @$"/home/mauricio/{currentDir}";
                    break;
                
                case ".wav":
                    currentDir = dirNames[1];
                    path = @$"/home/mauricio/{currentDir}";
                    break;

                default:
                    currentDir = dirNames[0];
                    path = @$"/home/mauricio/{currentDir}";
                    break;
            }

            GetSpecificFiles(file, path);
        }

    }


    public void GetSpecificFiles(string fileType, string dirDirection)
    {
        string[] files = Directory.GetFiles("destinofinal", $"*{fileType}");


        foreach(string file in files)
        {
            File.Move(file, $"{dirDirection} {fileType}", overwrite:true);
        }
    }
#endregion
}