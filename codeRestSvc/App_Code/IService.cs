using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Xml.Linq;

[ServiceContract]
public interface ICodeRestSvc
{
    [OperationContract]
    [WebGet(UriTemplate = "/setStatus/{state}", ResponseFormat = WebMessageFormat.Xml)]
    void SetStatus(string state);
    [OperationContract]
    [WebInvoke(UriTemplate = "/setCode/{code_id}", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
    void SetCode(String code_id, Stream code);


    [OperationContract]
    [WebGet(UriTemplate = "/getStatus", ResponseFormat = WebMessageFormat.Xml)]
    string GetStatus();
    [OperationContract]
    [WebGet(UriTemplate = "/getCode/{code_id}", ResponseFormat = WebMessageFormat.Xml)]
    XElement GetCode(String code_id);
}