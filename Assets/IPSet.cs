using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class IPSet : MonoBehaviour
{
    [SerializeField] private TMP_InputField ipSet;
    public void SetIP()
    {
        if (new Regex(@"^(localhost|(\d{1,3}\.){3}\d{1,3})$").IsMatch(ipSet.text ?? "")) Networking.BaseUrl = $"http://{ipSet.text}:8080";
        Debug.Log("Now ip set on "+Networking.BaseUrl);
    }
}
