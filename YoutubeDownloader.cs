using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace Youtube
{
    class YoutubeDownloader
    {
        protected internal void download(List<string> links)
        {
            int count = 0;
            foreach (string link in links)
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("https://youtu.be/" + link, count.ToString() + ".mp4");
                    count++;
                }
            }
        }
    }
}
