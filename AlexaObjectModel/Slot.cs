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
                    Value = json.Value<string>("value"),
                    ConfirmationStatus = json.Value<string>("confirmationStatus"),
                    Resolutions = Resolutions.FromJObject(json.Value<JObject>("resolutions"))
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

        public virtual string ConfirmationStatus { get; set; }

        public virtual Resolutions Resolutions { get; set; }
    }

    public class Resolutions
    {
        public IList<Resolutionsperauthority> ResolutionsPerAuthority { get; set; }

        internal static Resolutions FromJObject(JObject jObject)
        {
            if (jObject == null)
                return null;

            Resolutions resolutions = new Resolutions();

            if (jObject["resolutionsPerAuthority"] != null)
            {
                resolutions.ResolutionsPerAuthority = new List<Resolutionsperauthority>();

                foreach (var resolution in jObject["resolutionsPerAuthority"].Children())
                {
                    resolutions.ResolutionsPerAuthority.Add(Resolutionsperauthority.FromJObject(resolution.Value<JObject>()));
                }
            }

            return resolutions;
        }
    }

    public class Resolutionsperauthority
    {
        public string Authority { get; set; }
        public Status Status { get; set; }
        public IList<Value> Values { get; set; }

        internal static Resolutionsperauthority FromJObject(JObject jObject)
        {
            if (jObject == null)
                return null;

            IList<Value> values = null;

            if (jObject["values"] != null)
            {
                values = new List<Value>();

                foreach (var value in jObject.Value<JArray>("values").Children())
                {
                    var valueToAdd = new Value
                    {
                        Id = value.FirstOrDefault()?.FirstOrDefault()?.Value<string>("id"),
                        Name = value.FirstOrDefault()?.FirstOrDefault()?.Value<string>("name")
                    };
                    values.Add(valueToAdd);
                }
            }

            return new Resolutionsperauthority
            {
                Authority = jObject.Value<string>("authority"),
                Status = Status.FromJObject(jObject.Value<JObject>("status")),
                Values = values
        };
        }
    }

    public class Status
    {
        public string Code { get; set; }

        internal static Status FromJObject(JObject jObject)
        {
            if (jObject == null)
                return null;

            return new Status
            {
                Code = jObject.Value<string>("code")
            };
        }
    }

    public class Value
    {
        public string Name { get; set; }
        public string Id { get; set; }

        internal static Value FromJObject(JObject jObject)
        {
            if (jObject == null)
                return null;

            return new Value
            {
                Name = jObject.Value<string>("name"),
                Id = jObject.Value<string>("id")
            };
        }
    }
}
