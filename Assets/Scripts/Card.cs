// Date : 2023. 10. 30
// Person : ¹ÚÁØ¿í

using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using static UnityEditor.PlayerSettings;

public class Card : MonoBehaviour
{
    public Color[] backgroundCardColor;
    public float cardCloseSpeed = 1.0f;
    SpriteRenderer spriteRenderer;
    Animator animator;
    bool isOpen = false;
    public float speed = 1.0f;
    Vector3 dir;
    Vector3 placePos;
    bool isPlace = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = backgroundCardColor[0];
        placePos = transform.position;
        animator = GetComponent<Animator>();

        //CloseCard();
    }

    private void Update()
    {
        if (isPlace) return;

        if(Vector3.Distance(placePos, transform.position) > 0.2f)
        {   
            transform.Translate(dir * speed * Time.deltaTime);
        }
        else
        {
            transform.position = placePos;
            isPlace = true;
        }
    }

    private void OnMouseDown()
    {
        OpenCard();
    }

    public void Show()
    {
        transform.rotation = Quaternion.identity;
        animator.SetBool("IsOpen", true);
        StartCoroutine(IOpenCard());        
    }

    public void OpenCard()
    {
        isOpen = true;
        transform.rotation = Quaternion.identity;
        animator.SetBool("IsOpen", true);
        StartCoroutine(IOpenCard());

        // Do) Play Open Sound

        // Do) Send to MatchedClass me(gameObject)
    }

    IEnumerator IOpenCard()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.Find("Front").gameObject.SetActive(true);
        gameObject.transform.Find("Back").gameObject.SetActive(false);
    }

    public void CloseCard()
    {
        StartCoroutine(ICloseCard());
    }

    IEnumerator ICloseCard()
    {
        yield return new WaitForSeconds(cardCloseSpeed);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        gameObject.transform.Find("Front").gameObject.SetActive(false);
        gameObject.transform.Find("Back").gameObject.SetActive(true);
        if(isOpen) spriteRenderer.color = backgroundCardColor[1];
        animator.SetBool("IsOpen", false);
    }

    public void DestroyCard()
    {
        StartCoroutine(IDestroyCard());
    }

    IEnumerator IDestroyCard()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

    public void SetCardImage(Sprite sprite)
    {
        transform.Find("Front").GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void Place(Vector3 pos)
    {
        placePos = pos;
        isPlace = false;
        dir = placePos - transform.position;
    }
}
