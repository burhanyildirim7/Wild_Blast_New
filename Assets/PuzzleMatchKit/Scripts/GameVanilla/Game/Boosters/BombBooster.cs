using System.Collections;
using System.Collections.Generic;
using GameVanilla.Core;
using GameVanilla.Game.Common;
using UnityEngine;
//using UnityEngine.Purchasing;

namespace GameVanilla.Game.Scenes
{
    public class BombBooster : MonoBehaviour
    {
        private List<GameObject> tiles = new List<GameObject>();

        private GameScene _board;

        public void Resolve(GameScene scene, TileEntity tile, Level level)
        {
            var hitIdx = scene.tileEntities.FindIndex(x => x == tile.gameObject);

            var a = hitIdx % level.width;
            var b = hitIdx / level.width;

            _board = scene;

            tiles.Clear();
            for (var i = 0; i < scene.level.width; i++)
            {
                var tileIndex = (level.width * b) + i;

                var tileee = scene.tileEntities[tileIndex];

                //var block = scene.tileEntities[tileIndex].GetComponent<Block>();

                if (tileee != null)
                {
                    if (scene.tileEntities[tileIndex].GetComponent<Block>().type == BlockType.Collectable || scene.tileEntities[tileIndex].GetComponent<Block>().type == BlockType.Empty)
                    {
                        //Debug.Log("BURAYA GIRME");
                    }
                    else
                    {
                        tiles.Add(tileee);
                    }
                }
                else
                {

                }

            }

            float degerx = -115f;
            float degery = tile.transform.position.y;

            ArrowScript.instance.ArrowYerineGec(degerx, degery);

            StartCoroutine(Patlat(tile.gameObject));

        }

        private IEnumerator Patlat(GameObject tile)
        {
            yield return new WaitForSeconds(0.5f);

            for (var i = 0; i < tiles.Count; i++)
            {
                if (tiles[i] != null)
                {
                    if (_board.IsBoosterBlock(tile.GetComponent<TileEntity>()))
                    {
                        _board.ColorBombDestroyBooster(tiles[i].GetComponent<TileEntity>());
                    }
                    else
                    {
                        _board.DestroyCekicBooster(tiles[i].GetComponent<TileEntity>());
                    }

                    yield return new WaitForSeconds(0.1f);
                }
            }

            _board.BoosterGravityCalistir();

        }

    }



}
