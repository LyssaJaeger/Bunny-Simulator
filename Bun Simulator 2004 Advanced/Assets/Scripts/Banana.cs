using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
   
    private SpriteRenderer spriteR;
    [SerializeField]
    private Sprite flatBanan;
    [SerializeField]
    private Sprite upBanan;
    private bool mouseOver = false;
    private bool beingHeld = false;
    private Vector3 deltaV;
    private Vector3 newPos;
    [SerializeField]
    private Rigidbody2D rb2D;
    [SerializeField]
    private float speedFactor;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) && mouseOver == true)
        {
            beingHeld = true;
        }
        if (Input.GetMouseButton(0) && beingHeld == true)
        {
         
            Vector3 mousePos;

            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0;
            
            mousePos = Input.mousePosition;
           
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            newPos = new Vector3(mousePos.x, mousePos.y, 0);
            deltaV = (newPos - this.gameObject.transform.position);
            
            this.gameObject.transform.position = newPos;
            this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
      
        }  
        if (Input.GetMouseButtonUp(0) && beingHeld == true)
        {
            beingHeld = false;
            rb2D.velocity = deltaV;
        
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        spriteR.sprite = flatBanan;
        beingHeld = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteR.sprite = upBanan;

    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
