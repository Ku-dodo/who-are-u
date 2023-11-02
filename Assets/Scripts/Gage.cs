using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gage : MonoBehaviour
{
    GameObject speak;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speak = transform.Find("Speak").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        StartCoroutine(ISpeak());
    }

    IEnumerator ISpeak()
    {
        speak.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        speak.SetActive(false);
    }
}
