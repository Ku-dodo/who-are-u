using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 0.18f);
    }
}
