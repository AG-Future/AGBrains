using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map.TileMap.TileMapScripts
{
    public class TileLocator : MonoBehaviour
    {
        [Header("위치를 저장할 타일맵")]
        [SerializeField] private Tilemap tilemap;
        private void Start()
        {
            foreach(Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
            {
                if(!tilemap.HasTile(pos)) continue;
                var vec2Pos = new Vector2(pos.x, pos.y);
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        vec2Pos = new Vector2(pos.x + i, pos.y + j);
                        GenerateList.generateList.Add(vec2Pos);
                    }

                }
                
                
            }
            
        }
        
    }
}


