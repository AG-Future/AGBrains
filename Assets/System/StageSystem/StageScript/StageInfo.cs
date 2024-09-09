using UnityEngine;

namespace System.StageSystem.StageScript
{
    public class StageInfo : MonoBehaviour
    {
        [Header("게임씬 판별")]
        public bool IsNonPlayable;
        [Header("현재 스테이지의 숫자")]
        public int StageNumber;
        [Header("현재 씬의 stageTag")]
        public int StageTag;
        [Header("현재 씬의 제목")]
        public string StageName;
        [Header("현재 씬의 목표점수")]
        public int TotalPoint;
    }
}

