using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameTime : MonoBehaviour
{
    public TextMeshProUGUI pointsTime;
    void Start()
    {
        
    }

    
    void Update()
    {
        pointsTime.text = Time.timeSinceLevelLoad.ToString("F0");
    }
}
