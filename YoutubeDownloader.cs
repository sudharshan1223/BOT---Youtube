using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using VideoLibrary;
using System.IO;
using System.Linq;

namespace Youtube
{
    class YoutubeDownloader
    {
        protected internal async void download(List<string> links)
        {
            int count = 0;
            foreach (string link in links)
            {
                var youTube = YouTube.Default; // starting point for YouTube actions
                var video = youTube.GetVideo("https://youtu.be/" + link); // gets a Video object with info about the video
                var videoInfos = youTube.GetAllVideosAsync("https://youtu.be/" + link).GetAwaiter().GetResult();
                var maxResolution = videoInfos.First(i => i.Resolution == videoInfos.Max(j => j.Resolution));
                await Task.Run(() => File.WriteAllBytes(@"C:\Users\iw561f\Desktop\output\" + count, maxResolution.GetBytes()));
                count++;
            }
        }
    }
}
