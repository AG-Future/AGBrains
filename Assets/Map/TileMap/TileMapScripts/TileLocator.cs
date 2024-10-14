using System.Generator;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map.TileMap.TileMapScripts
{
    public class TileLocator : MonoBehaviour
    {
        [Header("위치를 저장할 타일맵")]
        [SerializeField] private Tilemap tilemap;

        public static bool WallCheck;
        private void Awake()
        {
            foreach(var pos in tilemap.cellBounds.allPositionsWithin)
            {
                if(!tilemap.HasTile(pos)) continue;
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        var vec2Pos = new Vector2(pos.x + i, pos.y + j);
                        GenerateList.GeneratesList.Add(vec2Pos);
                    }
                }
            }
        }
    }
}


