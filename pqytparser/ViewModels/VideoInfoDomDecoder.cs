﻿using pqytparser.Interfaces;
using pqytparser.Models;
using pqytparser.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace pqytparser.ViewModels
{
    public class VideoInfoDomDecoder : IVideoInfoDomDecoder
    {
        // Retrieves the available download urls by decoding the video info DOM for the 'contentId' to parse for itags.
        public VideoDownloadInfo GetVideoDownloadInfo(string contentId, string contentTitle, string dom)
        {
            const string _responseError = "&errorcode";
            const string _responseErrorCode = "&errorcode=150";
            const string _responsePurchase = "&requires_purchase";
            const string _https = "https";
            const string _mime = "mime=";
            const string _ytimg = "ytimg";
            const string _url = "url=";

            const string _streamMapPattern = "(?<=url_encoded_fmt_stream_map=).*";


            if (string.IsNullOrEmpty(contentId))
                return new VideoDownloadInfo(null, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content id.") , null);
            if (string.IsNullOrEmpty(contentTitle))
                return new VideoDownloadInfo(contentId, null, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing content title."), null);
            if (string.IsNullOrEmpty(dom))
                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Missing dom."), null);

            // Decode pass 1.
            dom = WebUtility.UrlDecode(dom);

            // Check for errors and specific messages.
            if (dom.Contains(_responseError) || dom.Contains(_responsePurchase))
            {
                string errorMessage = string.Empty;
                VideoAvailabilityEnum errorStatus = VideoAvailabilityEnum.NotAvailable;

                if (dom.Contains(_responseErrorCode))
                {
                    errorMessage = "YouTube video info response contains errorcode 150.";
                    errorStatus = VideoAvailabilityEnum.ErrorCode;
                }
                else if (_responseError.Contains(_responsePurchase))
                {
                    errorMessage = "YouTube content requires purchase.";
                    errorStatus = VideoAvailabilityEnum.RequiresPurchase;
                }
                else
                {
                    errorMessage = "The dom contains an error in the response.";
                    errorStatus = VideoAvailabilityEnum.ErrorCode;
                }

                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(errorStatus, errorMessage), null);
            }

            // Get everything after "url_encoded_fmt_stream_map=".
            dom = Regex.Match(dom, _streamMapPattern).Value;

            // Decode pass 2.
            dom = WebUtility.UrlDecode(dom);

            // Split.
            string[] responseUrls = Regex.Split(dom, _url);

            // Clean up the URLs.
            var urls = new List<string>(responseUrls.Count());
            foreach (var response in responseUrls)
            {
                if (string.IsNullOrEmpty(response) || !response.Contains(_https) || !response.Contains(_mime) || response.Contains(_ytimg))
                    continue;

                string url = RemoveQueryParameters(response);

                // Check the results.
                if (string.IsNullOrEmpty(url) || !url.Contains(_https) || !response.Contains(_mime))
                    continue;

                // TODO:    Final clean up.

                // Gather the metadata for the url.
                if (!MediaQualityEnumHelpers.TryParseUrlForItag(url, out string itag))
                    continue;
                if (!MediaQualityEnumHelpers.TryMapItagToEnum(itag, out MediaQualityEnum quality))
                    continue;

            }

            // Check if there are urls.
            if (urls.Count < 1)
                return new VideoDownloadInfo(contentId, contentTitle, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, "Download urls are not available."), null);

            return new VideoDownloadInfo(null, null, new VideoAvailability(VideoAvailabilityEnum.NotAvailable, null), null);
        }


        // Retrieves the DOM for the given 'contentId' using YouTube's video info query api.
        public async Task<string> GetVideoInfoDomAsync(string contentId)
        {
            const string _videoInfoBaseUrl = "https://www.youtube.com/get_video_info?video_id=";

            Uri videoInfoUri = new Uri(_videoInfoBaseUrl + contentId, UriKind.Absolute);
            string response = string.Empty;
            using (HttpClient client = new HttpClient())
                response = await client.GetStringAsync(videoInfoUri);
            return response;
        }


        // Cleans up a URL by removing unnecessary query parameters.
        // <see cref="https://stackoverflow.com/questions/73883/string-vs-stringbuilder"/>
        // <see cref="https://support.microsoft.com/en-us/help/306822/how-to-improve-string-concatenation-performance-in-visual-c"/>
        string RemoveQueryParameters(string input)
        {
            const string _codecsPattern = "(?<=codecs=\x22.*?\x22).*";
            const string _projectionPattern = "\x26projection_type=.*";
            const string _clenPattern = @"\x26clen=\d*|clen=\d*";
            const string _lmtPattern = @"\x26lmt=\d*|lmt=\d*";
            const string _fallbackHostPattern = "fallback_host=.*\x26|fallback_Host=.*\x2C";
            const string _itagPattern = @"\x26itag=\d{1,3}|itag=\d{1,3}";
            const string _typePattern1 = "(?<=.*)type=.*\x22";
            const string _typePattern2 = "\x26type=.*\x22";


            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Decode and use 'Text.StringBuilder'.  By the time 'input' gets here, this should be pass 3.
            StringBuilder sbuilder = new StringBuilder(WebUtility.UrlDecode(input));

            // Remove everything after the "codecs" parameter.
            Match mcodecsp = Regex.Match(sbuilder.ToString(), _codecsPattern);
            if (mcodecsp.Success)
                sbuilder.Remove(mcodecsp.Index, mcodecsp.Length);

            // Remove "projection_type" parameter and everything after it.
            Match mprojectionp = Regex.Match(sbuilder.ToString(), _projectionPattern);
            if (mprojectionp.Success)
                sbuilder.Remove(mprojectionp.Index, mprojectionp.Length);

            // Remove the trailing "clen" parameter.
            MatchCollection mclenp = Regex.Matches(sbuilder.ToString(), _clenPattern, RegexOptions.RightToLeft);
            if (mclenp.Count > 1)
                sbuilder.Remove(mclenp[0].Index, mclenp[0].Length);

            // Remove the trailing "lmt" pattern.
            MatchCollection mlmtp = Regex.Matches(sbuilder.ToString(), _lmtPattern, RegexOptions.RightToLeft);
            if (mlmtp.Count > 1)
                sbuilder.Remove(mlmtp[0].Index, mlmtp[0].Length);

            // Remove "fallback_host" parameter.
            Match mfallbackhostp = Regex.Match(sbuilder.ToString(), _fallbackHostPattern);
            if (mfallbackhostp.Success)
                sbuilder.Remove(mfallbackhostp.Index, mfallbackhostp.Length);

            // Remove trailing "itag" parameter.  Sometimes there's multiple itags within a url -- there can only be one.
            MatchCollection mitagp = Regex.Matches(sbuilder.ToString(), _itagPattern, RegexOptions.RightToLeft);
            if (mitagp.Count > 1)
                sbuilder.Remove(mitagp[0].Index, mitagp[0].Length);

            // Sometimes the "&" infront of the "type" parameter is no longer there and it must be manually re-added.
            Match mtypep1 = Regex.Match(sbuilder.ToString(), _typePattern1);
            if (mtypep1.Success)
            {
                Match mtypep2 = Regex.Match(sbuilder.ToString(), _typePattern2);
                if (!mtypep2.Success)
                {
                    // Remove the match first.
                    sbuilder.Remove(mtypep1.Index, mtypep1.Length);
                    // Append an "&" followed by the "type" parameter from the match.
                    sbuilder.Insert(mtypep1.Index, '\x26' + mtypep1.Value);
                }
            }

            return sbuilder.ToString();
        }
    }
}
