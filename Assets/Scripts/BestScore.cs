// Date : 2023. 11. 01
// Person : ¹ÚÁØ¿í

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        bestScoreText = transform.Find("BestScoreText").GetComponent<Text>();
        bestScoreText.text = GameManager.I.GetBestScore().ToString();
    }
}
