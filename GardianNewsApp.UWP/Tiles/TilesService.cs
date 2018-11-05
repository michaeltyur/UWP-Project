using GardianNewsApp.Core.Interfaces;
using GardianNewsApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;

namespace GardianNewsApp.UWP.Tiles
{
    public class TilesService : ITileProvider
    {
        public TilesService()
        {
            CreatFirstTile();
        }
        public async void CreateSecondaryTileAsync(string secondTile)
        {
            var tiles = await SecondaryTile.FindAllAsync();
            // Construct a unique tile ID, which you will need to use later for updating the tile
            string tileId = "guardianTile";
            // Use a display name you like
            string displayName = secondTile;


            // Provide all the required info in arguments so that when user
            // clicks your tile, you can navigate them to the correct content
            string arguments = "arguments";

            // Initialize the tile with required arguments
            SecondaryTile tile = new SecondaryTile(
                tileId,
                displayName,
                arguments,
                new Uri("ms-appx:///Assets/SecondTile/Square150x150Logo.png"),
                TileSize.Wide310x150);
            tile.VisualElements.Wide310x150Logo = new Uri("ms-appx:///Assets/SecondTile/Square150x150Logo.png");
            tile.VisualElements.ForegroundText = ForegroundText.Dark;

            tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            tile.VisualElements.ShowNameOnWide310x150Logo = true;
            tile.VisualElements.ShowNameOnSquare310x310Logo = true;


            if (SecondaryTile.Exists(tileId))
                await tile.UpdateAsync();
            else await tile.RequestCreateAsync();
            // Initialize a secondary tile with the same tile ID you want removed
            //SecondaryTile toBeDeleted = new SecondaryTile(tileId);

            // And then unpin the tile
            //await toBeDeleted.RequestDeleteAsync();
        }

        public void CreatFirstTile()
        {
            // In a real app, these would be initialized with actual data
            string from = "Jennifer Parker";
            string subject = "Photos from our trip";
            string body = "Check out these awesome photos I took while in New Zealand!";


            // Construct the tile content
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = from
                    },

                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                }
                        }
                    },

                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                                      {
                    new AdaptiveText()
                    {
                        Text = from,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },

                    new AdaptiveText()
                    {
                        Text = subject,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },

                    new AdaptiveText()
                    {
                        Text = body,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    }
                         }
                        }
                    }
                }
            };
        }
    }
}
