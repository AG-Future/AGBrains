using UnityEngine;

namespace System
{
    public class GoalGenerator : Generator
    {
        private void Start()
        {
            generatePos = new Vector2(0, 0);
            Spawn(preFab);
        }
    
    }
}
