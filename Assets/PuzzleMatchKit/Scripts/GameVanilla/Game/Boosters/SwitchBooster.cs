using System.Collections;
using System.Collections.Generic;
using GameVanilla.Core;
using GameVanilla.Game.Common;
using UnityEngine;
//using UnityEngine.Purchasing;

namespace GameVanilla.Game.Scenes
{
    public class SwitchBooster : MonoBehaviour
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
            for (var i = 0; i < scene.level.height; i++)
            {
                var tileIndex = (level.height * i) + a;

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

            float degerx = tile.transform.position.x;
            float degery = 110f;

            OrsScript.instance.OrsYerineGec(degerx, degery);

            StartCoroutine(Patlat(tile.gameObject));

        }

        private IEnumerator Patlat(GameObject tile)
        {
            yield return new WaitForSeconds(0.5f);

            for (var i = 0; i < tiles.Count; i++)
            {
                if (tiles[i] != null)
                {

                    if (_board.IsBoosterBlock(tiles[i].GetComponent<TileEntity>()))
                    {
                        //Debug.Log("BURAYA GIRDI");
                        _board.ColorBombDestroyBooster(tiles[i].GetComponent<TileEntity>());
                    }
                    else
                    {
                        //Debug.Log("BURAYA GIRMEDI");
                        _board.DestroyCekicBooster(tiles[i].GetComponent<TileEntity>());
                    }

                    yield return new WaitForSeconds(0.1f);
                }
            }

            _board.BoosterGravityCalistir();

        }

    }



}
