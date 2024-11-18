using UnityEngine;

namespace System.Generator
{
    public class CoinGenerator : Generator
    {
        private void Start()
        {
            GeneratePos = new Vector2(0, 0);
            Spawn(preFab);
        }
    }
}
