using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Linq;
using YoutubeExplode.Converter;

namespace Youtube
{
    class YoutubeDownloader
    {
        protected internal async void download(List<string> links)
        {
            int count = 0;
            foreach (string link in links)
            {
                try
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                        await Task.Run(()=> Client.DownloadFileAsync(new Uri("https://www.youtube.com/watch?v=1g5A9WCOBwU" + link), count.ToString() + ".flv"));


                        //var youtube = new YoutubeClient();

                        //var streamManifest = await youtube.Videos.Streams.GetManifestAsync(
                        //    "https://youtu.be/" + link
                        //);
                        //var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                        //var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

                        //// Download the stream to a file
                        //await youtube.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");
                        //var youtuber = new YoutubeClient();
                        //await Task.Run(()=> youtuber.Videos.DownloadAsync("https://www.youtube.com/watch?v=1g5A9WCOBwU", "C:\\Users\\SUDHA\\Desktop\\Personal\\video.mp4"));
                        count++;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                //try
                //{
                //    WebClient webClient = new WebClient();
                //    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                //    webClient.DownloadFileAsync(new Uri(sURL), sFilePath);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex);
                //    return;
                //}
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
