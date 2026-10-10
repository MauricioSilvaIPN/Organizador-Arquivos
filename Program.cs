using System;
using System.IO;
using System.Linq;

namespace Organizador;

public class DirOrganization
{
    static void Main(string[] args)
    {
        var func = new DirOrganization();

        func.IdentifyFolder();
    }

    public void IdentifyFolder()
    {
        string[] folders = Directory.GetDirectories(@"/home/mauricio/", "D*", SearchOption.TopDirectoryOnly);
        
        foreach(string folder in folders)
        {
            Console.WriteLine(folder);
        }
    }
}