using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace XmlWebService
{
    [ServiceContract]
    public interface IXmlWebService
    {
        [OperationContract]
        String[] listLessonPlans();

        [OperationContract]
        IEnumerable<XElement> getLessonPlan(string xmlUrl);
    }
}
