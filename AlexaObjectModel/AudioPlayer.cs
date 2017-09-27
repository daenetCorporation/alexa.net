using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alexa.Skills.Api
{
    public class AudioPlayer
    {
        public static AudioPlayer FromJObject(JObject obj)
        {
            if (obj != null)
            {
                AudioPlayer audioPlayer = new AudioPlayer();
                audioPlayer.token = obj.Value<string>("token") ?? "";
                audioPlayer.offsetInMilliseconds = obj.Value<long?>("offsetInMilliseconds");
                audioPlayer.playerActivity = obj.Value<string>("playerActivity");
                return audioPlayer;
            }
            else
                return null;
        }

        public string token { get; set; }
        public long? offsetInMilliseconds { get; set; }
        public string playerActivity { get; set; }
    }
}
