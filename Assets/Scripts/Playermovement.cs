using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
   public float moveSpeed = 5f;

   public float runSpeed = 8f;

   public Rigidbody2D rb;

   bool Sprint = true;

   public Camera cam;

   Vector2 movement;
   Vector2 mousePos;

   void Update()
   {
         // Input
         movement.x = Input.GetAxisRaw("Horizontal");
         movement.y = Input.GetAxisRaw("Vertical");

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

         if(Input.GetKey(KeyCode.LeftShift))
            {
                Sprint = true;
            }
      else
            {
                 Sprint = false;
            }
   }

   void FixedUpdate()
   {
        // Movement

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if(Sprint == true)
        {
            rb.MovePosition(rb.position + movement.normalized * runSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        }
   }
}
