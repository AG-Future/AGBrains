using UnityEngine;
using UnityEngine.Serialization;

namespace System.StageSystem.StageScript
{
    public class StageInfo : MonoBehaviour
    {
        [FormerlySerializedAs("IsNonPlayable")] [Header("게임씬 판별")]
        public bool isNonPlayable;
        [FormerlySerializedAs("StageNumber")] [Header("현재 스테이지의 숫자")]
        public int stageNumber;
        [FormerlySerializedAs("StageTag")] [Header("현재 씬의 stageTag")]
        public int stageTag;
        [FormerlySerializedAs("StageName")] [Header("현재 씬의 제목")]
        public string stageName;
        [FormerlySerializedAs("TotalPoint")] [Header("현재 씬의 목표점수")]
        public int totalPoint;
    }
}
