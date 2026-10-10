using System;
using System.IO;
using System.Linq;

namespace Organizador;

public class DirOrganization
{
    static void Main(string[] args)
    {
        var dirClass = new DirOrganization();

        //dirClass.GetSpecificFiles(".png", "/home/mauricio/Documentos/");
    }

    public void IdentifyFile()
    {
        List<String> fileTypes = [".png", ".pdf", ".txt", ".mp4", ".wav"];
        List<String> dirNames = ["Documentos", "Downloads", "Músicas", "Vídeos", "Imagens"];

        

    }

    public void GetSpecificFiles(string fileType, string dirDirection)
    {
        string[] files = Directory.GetFiles(@"/home/mauricio/Documentos/teste/", $"*{fileType}");


        foreach(string file in files)
        {
            //Console.WriteLine(file);
            File.Move(file, $"{dirDirection} {fileType}", overwrite:false);
        }
    }
}