using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alexa.Skills.Api
{
    public class System
    {
        public static System FromJObject(JObject obj)
        {
            if (obj != null)
            {
                System system = new System();

                system.application = Application.FromJObject(obj.Value<JObject>("application"));
                system.user = User.FromJObject(obj.Value<JObject>("user"));
                system.device = Device.FromJObject(obj.Value<JObject>("device"));
                return system;
            }
            else return null;
        }
        public Application application { get; set; }
        public User user { get; set; }

        public Device device { get; set; }
    }
}
