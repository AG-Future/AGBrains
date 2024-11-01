using System.Collections;
using System.Collections.Generic;
using System.StageSystem.StageScript;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private StageManager _stageManager;
    private void Start()
    {
        _stageManager = FindObjectOfType<StageManager>();
        _stageManager.StageSet();
    }
}
