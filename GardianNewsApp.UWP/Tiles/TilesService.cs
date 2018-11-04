using GardianNewsApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;

namespace GardianNewsApp.UWP.Tiles
{
   public class TilesService: ITileProvider
    {
        public TilesService()
        {

        }
        public async void CreateSecondaryTileAsync(string articleTitle, string trailText)
        {
            var tiles = await SecondaryTile.FindAllAsync();
            // Construct a unique tile ID, which you will need to use later for updating the tile
            string tileId = "guardianTile";

            // Use a display name you like
            string displayName = articleTitle;

            // Provide all the required info in arguments so that when user
            // clicks your tile, you can navigate them to the correct content
            string arguments = trailText;

            // Initialize the tile with required arguments
            SecondaryTile tile = new SecondaryTile(
                tileId,
                displayName,
                arguments,
                new Uri("ms-appx:///Assets/SecondTile/Square150x150Logo.png"),
                TileSize.Wide310x150);           
            
            tile.VisualElements.ForegroundText=ForegroundText.Dark;

            tile.VisualElements.ShowNameOnSquare150x150Logo = true;
            tile.VisualElements.ShowNameOnWide310x150Logo = true;
            tile.VisualElements.ShowNameOnSquare310x310Logo = true;

      
            if(SecondaryTile.Exists(tileId))
                await tile.UpdateAsync();           
            else await tile.RequestCreateAsync();
            // Initialize a secondary tile with the same tile ID you want removed
            //SecondaryTile toBeDeleted = new SecondaryTile(tileId);

            // And then unpin the tile
            //await toBeDeleted.RequestDeleteAsync();
        }

    }
}
