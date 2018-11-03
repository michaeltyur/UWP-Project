using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardianNewsApp.UWP.Tiles
{
   public class TilesService
    {
        // In a real app, these would be initialized with actual data
        string from = "Jennifer Parker";
        string subject = "Photos from our trip";
        string body = "Check out these awesome photos I took while in New Zealand!";


        // Construct the tile content
        //TileContent content = new TileContent()
        //{
        //    Visual = new TileVisual()
        //    {
        //        TileMedium = new TileBinding()
        //        {
        //            Content = new TileBindingContentAdaptive()
        //            {
        //                Children =
        //        {
        //            new AdaptiveText()
        //            {
        //                Text = from
        //            },

        //            new AdaptiveText()
        //            {
        //                Text = subject,
        //                HintStyle = AdaptiveTextStyle.CaptionSubtle
        //            },

        //            new AdaptiveText()
        //            {
        //                Text = body,
        //                HintStyle = AdaptiveTextStyle.CaptionSubtle
        //            }
        //        }
        //            }
        //        },

        //        TileWide = new TileBinding()
        //        {
        //            Content = new TileBindingContentAdaptive()
        //            {
        //                Children =
        //        {
        //            new AdaptiveText()
        //            {
        //                Text = from,
        //                HintStyle = AdaptiveTextStyle.Subtitle
        //            },

        //            new AdaptiveText()
        //            {
        //                Text = subject,
        //                HintStyle = AdaptiveTextStyle.CaptionSubtle
        //            },

        //            new AdaptiveText()
        //            {
        //                Text = body,
        //                HintStyle = AdaptiveTextStyle.CaptionSubtle
        //            }
        //        }
        //            }
        //        }
        //    }
        //};
    }
}
