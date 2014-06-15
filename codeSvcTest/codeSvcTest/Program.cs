using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;

namespace codeSvcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string ServiceUri = "http://localhost:64402/codeRestSvc/Service.svc/setCode/gtest";

            String PostData = "{ \n loopfor -1 \n { \n method drive(string \"f\"); \n waituntil ([method getSonars(int 1) < int 20] or [method getSonars(int 3) > int 50]); \n if ([method getSonars(int 3) > int 50]) \n { \n waitfor 1; \n method turnAngle(int 90); \n method drive(string \"f\"); \n waitfor 2; \n } \n elseif ([method getSonars(int 1) < int 20]) \n { \n method turnAngle(int -90); \n } \n } \n }";
            Console.Write(PostData);
            HttpWebRequest request = WebRequest.Create(new Uri(ServiceUri)) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = PostData.Length;

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(PostData);
            sw.Close();

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
              StreamReader reader = new StreamReader(response.GetResponseStream());
              string ResponseText = reader.ReadToEnd();
            }

            WebRequest req = WebRequest.Create(@"http://localhost:64402/codeRestSvc/Service.svc/getCode/asdf123");

            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine(string.Format("Status Code: {0}, Status Description: {1}", resp.StatusCode, resp.StatusDescription));
            }
            Console.Read();
          }*/

            xmlSvc.XmlWebServiceClient client = new xmlSvc.XmlWebServiceClient();
            String[] lessonPlans = client.listLessonPlans();
            IEnumerable<XElement> lp = client.getLessonPlan("1-1_intro_to_driving");
        }
    }
}
