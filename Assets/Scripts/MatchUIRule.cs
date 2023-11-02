using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchUIRule : MonoBehaviour
{
    public Text innerTxt;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "MatchCanvas(Clone)")
        {
            innerTxt.text = GameManager.I.ownerName;
        }
    }

    // Update is called once per frame
    void Update()
    {


        Destroy(gameObject, 1.0f);
    }
}
