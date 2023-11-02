using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InstantTouch : MonoBehaviour
{
    public Transform canvas;
    public GameObject touchEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(touchEffect, canvas);
        }
    }
}
