using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Treat : Item, IDraggable
{
    public TreatType treatType;
    private Rigidbody2D rB2D;
    private SpriteRenderer spriteR;
    private Sprite up;
    private Sprite down;
    private float speedFactor;
    private Vector3 deltaV;
    private bool beingHeld;
    private bool mouseOver;
  
    void FixedUpdate()
    {
        PickUp();
        DragWithMouse();
        PutDown();
    }

   public Treat(string name, int id) : base(name, id)
    {
        this.name = name;
        this.id = id;
    }

    public void PickUp()
    {
        if (mouseOver == true && Input.GetMouseButtonDown(0))
        {
            beingHeld = true;
            rB2D.velocity = Vector3.zero;
            rB2D.angularVelocity = 0;
        }


    }
    public void DragWithMouse()
    {
         if (beingHeld = true && Input.GetMouseButton(0))
                {
                    Vector3 mousePos;
                    Vector3 newPos;
                    mousePos = Input.mousePosition;
                    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                    newPos = new Vector3(mousePos.x, mousePos.y, 0);
                    deltaV = ((newPos - this.gameObject.transform.position)) * speedFactor;

                    this.gameObject.transform.position = newPos;
                    this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                }
    }
    public void PutDown()
    {
        if (Input.GetMouseButtonUp(0) && beingHeld == true)
        {
            beingHeld = false;
            rB2D.AddForce(deltaV);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        spriteR.sprite = down;
        beingHeld = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteR.sprite = up;

    }

    void OnMouseEnter()
    {
        mouseOver = true;
    }
    void OnMouseExit()
    {
        mouseOver = false;
    }

}
