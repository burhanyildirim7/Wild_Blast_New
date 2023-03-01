// Copyright (C) 2017-2022 gamevanilla. All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement,
// a copy of which is available at http://unity3d.com/company/legal/as_terms.

using GameVanilla.Game.Common;
using UnityEngine;

namespace GameVanilla.Game.Scenes
{
    /// <summary>
    /// The class that represents the lollipop booster.
    /// </summary>
    public class LollipopBooster : MonoBehaviour
    {
        /// <summary>
        /// Resolves this booster.
        /// </summary>
        /// <param name="board">The game board.</param>
        /// <param name="tile">The tile in which to apply the booster.</param>
		public void Resolve(GameScene scene, TileEntity tile)
        {
            //board.CekicIlePatlat(tile);
            //board.BoosterModdanCik();
            /*
            if (tile.GetComponent<ColorBomb>() != null)
            {
                scene.ColorBombPatlat(tile);
            }
            else
            {
                scene.CekicIlePatlat(tile);
                scene.ApplyGravity();
            }
            */
            var blockIdx = scene.tileEntities.FindIndex(x => x == tile.gameObject);

            if (scene.IsBoosterBlock(tile))
            {
                //scene.DestroyBooster(tile);
            }
            else
            {
                //Debug.Log("BURAYA");
                scene.DestroyCekicBooster(tile);
                scene.BoosterGravityCalistir();
                //Debug.Log("BURAYA GIRDI");
            }
        }
    }
}
