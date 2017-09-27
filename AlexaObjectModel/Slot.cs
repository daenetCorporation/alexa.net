using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alexa.Skills.Api
{

    public class Slot

    {

        /// <summary>

        /// 

        /// </summary>

        /// <param name="json"></param>

        /// <returns></returns>

        public static Slot FromJson(JObject json)
        {

            if (json != null)
            {
                return new Slot
                {

                    Name = json.Value<string>("name"),

                    Value = json.Value<string>("value")

                };
            }
            else
                return null;

        }



        public virtual string Name
        {

            get;

            set;

        }

        public virtual string Value
        {

            get;

            set;

        }
    }
}
