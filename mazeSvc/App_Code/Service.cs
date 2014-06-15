using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml.Linq;

public class GenostSvc : IGenostSvc
{
    public XElement getMaze(String maze_id)
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String mazePath = Path.Combine(appPath, @"mazes/" + maze_id + ".xml");
        if (File.Exists(mazePath))
        {
            StreamReader mazeReader = new StreamReader(mazePath);
            String mazeXml = mazeReader.ReadToEnd();
            XDocument doc = XDocument.Parse(mazeXml);
            XElement root = doc.Root;
            return root;
        }

        return null;
    }

    public String[] listMazes()
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String mazeDir = Path.Combine(appPath, @"mazes");

        String[] files = Directory.GetFiles(mazeDir, "*.xml");
        List<String> fileNames = new List<String>();
        foreach (String filePath in files)
        {
            String fileName = Path.GetFileName(filePath).Replace(".xml", "");
            fileNames.Add(fileName);
        }

        return fileNames.ToArray();
    }

    public XElement getLoadout(String loadout_id)
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String loadoutPath = Path.Combine(appPath, @"loadouts/" + loadout_id + ".xml");
        if (File.Exists(loadoutPath))
        {
            StreamReader loadoutReader = new StreamReader(loadoutPath);
            String loadoutXml = loadoutReader.ReadToEnd();
            XDocument doc = XDocument.Parse(loadoutXml);
            XElement root = doc.Root;
            return root;
        }

        return null;
    }

    public String[] listLoadouts()
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String loadoutDir = Path.Combine(appPath, @"loadouts");

        String[] files = Directory.GetFiles(loadoutDir, "*.xml");
        List<String> fileNames = new List<String>();
        foreach (String filePath in files)
        {
            String fileName = Path.GetFileName(filePath).Replace(".xml", "");
            fileNames.Add(fileName);
        }

        return fileNames.ToArray();
    }

    public XElement getTheme(String theme_id)
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String themePath = Path.Combine(appPath, @"themes/" + theme_id + "/theme.xml");
        if (File.Exists(themePath))
        {
            StreamReader themeReader = new StreamReader(themePath);
            String themeXml = themeReader.ReadToEnd();
            XDocument doc = XDocument.Parse(themeXml);
            XElement root = doc.Root;
            return root;
        }

        return null;
    }

    public String[] listThemes()
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String themeDir = Path.Combine(appPath, @"themes");

        String[] themeDirs = Directory.GetDirectories(themeDir);
        List<String> dirNames = new List<String>();
        foreach (String dirPath in themeDirs)
        {
            String dirName = Path.GetFileName(dirPath);
            dirNames.Add(dirName);
        }

        return dirNames.ToArray();
    }

    public Stream getThemeImage(String theme_id, String image_id)
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String themeDir = Path.Combine(appPath, @"themes");
        String themeImagePath = Path.Combine(appPath, @"themes/" + theme_id + "/" + image_id + ".png");
        if (File.Exists(themeImagePath))
        {
            FileStream fs = File.OpenRead(themeImagePath);
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
            return fs;
        }

        return null;
    }

    public void saveMaze(String maze_id, Stream maze_xml)
    {
        StreamReader reader = new StreamReader(maze_xml);
        string RequestData = reader.ReadToEnd();
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String mazeDir = Path.Combine(appPath, @"mazes");
        System.IO.File.WriteAllText(mazeDir + "/" + maze_id + ".xml", RequestData);
    }
}
