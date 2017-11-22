using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Alexa.Skills.Api
{
    public class Device
    {
        public static Device FromJObject(JObject obj)
        {
            if (obj != null)
            {
                Device device = new Device();
                device.supportedInterfaces = obj.Value<JObject>("supportedInterfaces");
                device.deviceId = obj.Value<string>("deviceId");
                return device;
            }
            else
                return null;
        }

        public JObject supportedInterfaces { get; set; }
        public string deviceId { get; set; }

        public List<string> getInterfaces()
        {
            List<string> retval = new List<string>();
            foreach(var child in this.supportedInterfaces.Children())
            {
                retval.Add(child.Path);
            }
            return retval;
        }
    }
}
