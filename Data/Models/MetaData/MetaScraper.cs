﻿using HtmlAgilityPack;

namespace PersonalManager.Data.Models.MetaData
{
    public static class MetaScraper
    {
        /// <summary>
        /// Uses HtmlAgilityPack to get the meta information from a url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Models.MetaData.MetaInformation GetMetaDataFromUrl(string url)
        {
            // Get the URL specified
            var webGet = new HtmlWeb();
            var document = webGet.Load(url);
            var metaTags = document.DocumentNode.SelectNodes("//meta");
            Models.MetaData.MetaInformation metaInfo = new Models.MetaData.MetaInformation(url);
            if (metaTags != null)
            {
                int matchCount = 0;
                foreach (var tag in metaTags)
                {
                    var tagName = tag.Attributes["name"];
                    var tagContent = tag.Attributes["content"];
                    var tagProperty = tag.Attributes["property"];
                    if (tagName != null && tagContent != null)
                    {
                        switch (tagName.Value.ToLower())
                        {
                            case "title":
                                metaInfo.Title = HtmlEntity.DeEntitize(tagContent.Value);
                                matchCount++;
                                break;
                            case "description":
                                metaInfo.Description = HtmlEntity.DeEntitize(tagContent.Value);
                                matchCount++;
                                break;
                            case "twitter:title":
                                metaInfo.Title = string.IsNullOrEmpty(metaInfo.Title) ? HtmlEntity.DeEntitize(tagContent.Value) : HtmlEntity.DeEntitize(metaInfo.Title);
                                matchCount++;
                                break;
                            case "twitter:description":
                                metaInfo.Description = string.IsNullOrEmpty(metaInfo.Description) ? HtmlEntity.DeEntitize(tagContent.Value) : HtmlEntity.DeEntitize(metaInfo.Description);
                                matchCount++;
                                break;
                            case "keywords":
                                metaInfo.Keywords = HtmlEntity.DeEntitize(tagContent.Value);
                                matchCount++;
                                break;
                            case "twitter:image":
                                metaInfo.ImageUrl = string.IsNullOrEmpty(metaInfo.ImageUrl) ? tagContent.Value : metaInfo.ImageUrl;
                                matchCount++;
                                break;
                        }
                    }
                    else if (tagProperty != null && tagContent != null)
                    {
                        switch (tagProperty.Value.ToLower())
                        {
                            case "og:title":
                                metaInfo.Title = string.IsNullOrEmpty(metaInfo.Title) ? HtmlEntity.DeEntitize(tagContent.Value) : HtmlEntity.DeEntitize(metaInfo.Title);
                                matchCount++;
                                break;
                            case "og:description":
                                metaInfo.Description = string.IsNullOrEmpty(metaInfo.Description) ? HtmlEntity.DeEntitize(tagContent.Value) : HtmlEntity.DeEntitize(metaInfo.Description);
                                matchCount++;
                                break;
                            case "og:image":
                                metaInfo.ImageUrl = string.IsNullOrEmpty(metaInfo.ImageUrl) ? tagContent.Value : metaInfo.ImageUrl;
                                matchCount++;
                                break;
                        }
                    }
                }
                metaInfo.HasData = matchCount > 0;
            }

            if(string.IsNullOrEmpty(metaInfo.Title)){
              var siteTitle = document.DocumentNode.SelectNodes("//title")[0];
              metaInfo.Title = siteTitle.InnerText;
            }

            return metaInfo;
        }
    }
}
