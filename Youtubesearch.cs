using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Youtube
{
    class Youtubesearch
    {
        [STAThread]
        protected internal async Task Run()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyBqow__RqTUth2ShRN9i9T7AVygzgxvVnQ",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "Call of Duty Mobile"; // Replace with your search term.
            searchListRequest.MaxResults = 10;
            searchListRequest.Type = "Video";
            searchListRequest.Order = SearchResource.ListRequest.OrderEnum.Relevance;
            //searchListRequest.VideoDuration = SearchResource.ListRequest.VideoDurationEnum.Medium;  // Duration issue
            searchListRequest.PublishedAfter = "2022-07-17T21:59:00.000Z";

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();
            List<string> Links = new List<string>();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        Links.Add(searchResult.Id.VideoId);
                        break;
                }
            }
            Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
            //await Task.Run(() =>
            //{ new 
            YoutubeDownloader a = new YoutubeDownloader();
            a.download(Links);
        //}

            //);
        }
    }
}
