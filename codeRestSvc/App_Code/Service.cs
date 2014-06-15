using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml.Linq;

public class CodeRestSvc : ICodeRestSvc
{
    public void SetStatus(string state)
    {
        System.Configuration.Configuration config =
        System.Web.Configuration.WebConfigurationManager.
                OpenWebConfiguration("~/"); // Open Web.config file
        config.AppSettings.Settings.Remove("StatusKey");
        config.AppSettings.Settings.Add("StatusKey", state);
        config.Save(System.Configuration.ConfigurationSaveMode.Modified);

    }
    public void SetCode(String code_id, Stream code)
    {
        StreamReader reader = new StreamReader(code);
        string RequestData = reader.ReadToEnd();
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String mazeDir = Path.Combine(appPath, @"code");

        System.IO.File.WriteAllText(mazeDir + "/" + code_id + ".txt", RequestData);
    }

    public string GetStatus()
    {
        System.Collections.Specialized.NameValueCollection myKeys =
            System.Web.Configuration.WebConfigurationManager.AppSettings;
        string state = myKeys["StatusKey"];
        return string.Format("{0}", state);
    }

    public XElement GetCode(String code_id)
    {
        String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
        String codePath = Path.Combine(appPath, @"code/" + code_id + ".txt");
        if (File.Exists(codePath))
        {
            StreamReader codeReader = new StreamReader(codePath);
            String code = codeReader.ReadToEnd();

            XElement xml = new XElement("Code");
            xml.Add(new XCData(code));
            return xml;
        }

        return null;
    }
}
