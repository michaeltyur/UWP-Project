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
        private string _secondTileId = "guardianSecondTile";
        private TileContent _firstTile;

        private async Task CreateSecondaryTileAsync(string category, string content)
        {
            // var tiles = await SecondaryTile.FindAllAsync();
            // Construct a unique tile ID, which you will need to use later for updating the tile
            string tileId = _secondTileId;
            // Use a display name you like
            string displayName = content;


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
            if (!SecondaryTile.Exists(_secondTileId))
            {
                await tile.RequestCreateAsync();
            }
            await tile.UpdateAsync();
        }

        private void CreatFirstTile(string category,string content)
        {
            _firstTile = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.Name,
                    DisplayName = "News",
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "GApp"
                    },
                    new AdaptiveText()
                    {
                        Text = content
                    }
                }
                        }
                    },
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "GY News",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
                    new AdaptiveText()
                    {
                        Text = category,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
                    new AdaptiveText()
                    {
                        Text = content,
                        HintWrap = true
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
                        Text = category,
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
                    new AdaptiveText()
                    {
                        Text = content,
                        HintWrap = true
                    }
                },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = "Assets/Square150x150Logo.scale-100.png"
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Guardian News",
                        HintStyle = AdaptiveTextStyle.Subtitle
                    },
                    new AdaptiveText()
                    {
                        Text = category,
                        HintStyle = AdaptiveTextStyle.CaptionSubtle
                    },
                    new AdaptiveText()
                    {
                        Text = content,
                        HintWrap = true
                    }
                }
                        }
                    }
                }
            };

        }

        public void TileUpdater(string category, string content)
        {
            CreatFirstTile(category, content);
            CreateSecondaryTileAsync(category, content);

            // Create the tile notification
            var tileNotif = new TileNotification(_firstTile.GetXml())
            {
                ExpirationTime = DateTimeOffset.UtcNow.AddMinutes(10)
            };

            // And send the notification to the primary tile
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotif);

            // If the secondary tile is pinned
        //    if (SecondaryTile.Exists(_secondTileId))
        //    {
        //        // Get its updater
        //        var updater = TileUpdateManager.CreateTileUpdaterForSecondaryTile(_secondTileId);

        //        // And send the notification
        //        updater.Update(tileNotif);
        //    }
        }
    }
}
