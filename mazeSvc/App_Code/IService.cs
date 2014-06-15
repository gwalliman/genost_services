using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IGenostSvc
{
    // LIST METHODS
    [OperationContract]
    [WebGet(UriTemplate = "/listMazes/", ResponseFormat = WebMessageFormat.Json)]
    String[] listMazes();

    [OperationContract]
    [WebGet(UriTemplate = "/listLoadouts/", ResponseFormat = WebMessageFormat.Json)]
    String[] listLoadouts();

    [OperationContract]
    [WebGet(UriTemplate = "/listThemes/", ResponseFormat = WebMessageFormat.Json)]
    String[] listThemes();

    //GET METHODS
    [OperationContract]
    [WebGet(UriTemplate = "/getMaze/{maze_id}", ResponseFormat = WebMessageFormat.Xml)]
    XElement getMaze(String maze_id);

    [OperationContract]
    [WebGet(UriTemplate = "/getLoadout/{loadout_id}", ResponseFormat = WebMessageFormat.Xml)]
    XElement getLoadout(String loadout_id);

    [OperationContract]
    [WebGet(UriTemplate = "/getTheme/{theme_id}", ResponseFormat = WebMessageFormat.Xml)]
    XElement getTheme(String theme_id);

    [OperationContract]
    [WebGet(UriTemplate = "/getThemeImage/{theme_id}/{image_id}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
    Stream getThemeImage(String theme_id, String image_id);

    [OperationContract]
    [WebInvoke(UriTemplate = "/saveMaze/{maze_id}", RequestFormat = WebMessageFormat.Xml)]
    void saveMaze(String maze_id, Stream maze_xml);
}