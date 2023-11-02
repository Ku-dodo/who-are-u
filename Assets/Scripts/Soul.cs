using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SearchService;

public class Soul : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject destination;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;

    public Color[] pallete;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(destination)
        {
            dir = destination.transform.position - transform.position;
            rb.velocity += dir * Time.deltaTime * 5f;
        }
    }

    public void Init(string ownerName)
    {
        switch(ownerName)
        {
            case "¹ÚÁØ¿í":
                destination = GameObject.Find("Character0").gameObject;
                GetComponent<SpriteRenderer>().color = pallete[0];
                GetComponent<TrailRenderer>().startColor = pallete[0];
                break;

            case "ÇÏ½Â±Ç":
                destination = GameObject.Find("Character1").gameObject;
                GetComponent<SpriteRenderer>().color = pallete[1];
                GetComponent<TrailRenderer>().startColor = pallete[1];
                break;

            case "À±Èñ¼º":
                destination = GameObject.Find("Character2").gameObject;
                GetComponent<SpriteRenderer>().color = pallete[2];
                GetComponent<TrailRenderer>().startColor = pallete[2];
                break;

            case "±¸µµÇö":
                destination = GameObject.Find("Character3").gameObject;
                GetComponent<SpriteRenderer>().color = pallete[3];
                GetComponent<TrailRenderer>().startColor = pallete[3];
                break;
        }
    }

}
