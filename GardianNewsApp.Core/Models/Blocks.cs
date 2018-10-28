using System;
using System.Collections.Generic;
using System.Text;

namespace GardianNewsApp.Core.Models
{
   
        public class Blocks
        {
            public int totalBodyBlocks { get; set; }
            public Requestedbodyblocks requestedBodyBlocks { get; set; }
        }

        public class Requestedbodyblocks
        {
            public BodyLatest10[] bodylatest10 { get; set; }
        }

        public class BodyLatest10
        {
            public string id { get; set; }
            public string bodyHtml { get; set; }
            public string bodyTextSummary { get; set; }
            public Attributes attributes { get; set; }
            public bool published { get; set; }
            public Createddate createdDate { get; set; }
            public Firstpublisheddate firstPublishedDate { get; set; }
            public Publisheddate publishedDate { get; set; }
            public Lastmodifieddate lastModifiedDate { get; set; }
            public object[] contributors { get; set; }
            public Element[] elements { get; set; }
            public string title { get; set; }
        }

        public class Attributes
        {
            public bool pinned { get; set; }
            public bool keyEvent { get; set; }
            public string title { get; set; }
        }

        public class Createddate
        {
            public long dateTime { get; set; }
            public DateTime iso8601 { get; set; }
        }

        public class Firstpublisheddate
        {
            public long dateTime { get; set; }
            public DateTime iso8601 { get; set; }
        }

        public class Publisheddate
        {
            public long dateTime { get; set; }
            public DateTime iso8601 { get; set; }
        }

        public class Lastmodifieddate
        {
            public long dateTime { get; set; }
            public DateTime iso8601 { get; set; }
        }

        public class Element
        {
            public string type { get; set; }
            public Asset[] assets { get; set; }
            public Texttypedata textTypeData { get; set; }
            public Imagetypedata imageTypeData { get; set; }
            public Videotypedata videoTypeData { get; set; }
            public Richlinktypedata richLinkTypeData { get; set; }
            public Pullquotetypedata pullquoteTypeData { get; set; }
        }

        public class Texttypedata
        {
            public string html { get; set; }
        }

        public class Imagetypedata
        {
            public string caption { get; set; }
            public bool displayCredit { get; set; }
            public string credit { get; set; }
            public string source { get; set; }
            public string photographer { get; set; }
            public string alt { get; set; }
            public string mediaId { get; set; }
            public string mediaApiUri { get; set; }
            public string suppliersReference { get; set; }
            public string imageType { get; set; }
            public string copyright { get; set; }
            public string role { get; set; }
        }

        public class Videotypedata
        {
            public string url { get; set; }
            public string description { get; set; }
            public string title { get; set; }
            public string html { get; set; }
            public string source { get; set; }
            public string credit { get; set; }
            public string caption { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string originalUrl { get; set; }
        }

        public class Richlinktypedata
        {
            public string url { get; set; }
            public string originalUrl { get; set; }
            public string linkText { get; set; }
            public string linkPrefix { get; set; }
            public string role { get; set; }
        }

        public class Pullquotetypedata
        {
            public string html { get; set; }
        }

        public class Asset
        {
            public string type { get; set; }
            public string mimeType { get; set; }
            public string file { get; set; }
            public Typedata typeData { get; set; }
        }

        public class Typedata
        {
            public string aspectRatio { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool isMaster { get; set; }
        }

    
}
