using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace XmlWebService
{
    public class XmlWebService : IXmlWebService
    {
        public IEnumerable<XElement> getLessonPlan(string xmlId)
        {
            String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            String lpFile = Path.Combine(appPath, @"lessonplans/" + xmlId + ".xml");
            if(File.Exists(lpFile))
            {
                StreamReader loadoutReader = new StreamReader(lpFile);
                String lpXml = loadoutReader.ReadToEnd();
                XDocument doc = XDocument.Parse(lpXml);
                IEnumerable<XElement> fullAPI = doc.Descendants();
                return fullAPI;
            }
            else
            {
                return null;
            }
        }

        public String[] listLessonPlans()
        {
            String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            String lpDir = Path.Combine(appPath, @"lessonplans");

            String[] files = Directory.GetFiles(lpDir, "*.xml");
            List<String> fileNames = new List<String>();
            foreach (String filePath in files)
            {
                String fileName = Path.GetFileName(filePath).Replace(".xml", "");
                fileNames.Add(fileName);
            }

            return fileNames.ToArray();
        }
    }
}
