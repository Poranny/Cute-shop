using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
   
   public ShopController shopControl;
   
   public Transform camTransform;
   public Transform playerTransform;
   
   public Animator playerAnimator;
   
   public Camera cam;
   
   public float speed;
   
   private bool isGoing;
   
   
   void Update () {
      
      if (Input.GetMouseButton (0)) {
         RaycastHit hit;
         
         Vector3 theMousePos = cam.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
         
         if (Physics.Raycast (theMousePos, Vector3.forward, out hit)) {
            if (!isGoing) {
               if (hit.collider.gameObject.CompareTag ("Collision shop")) {
                  shopControl.OpenTheShop ();
                  
                  StartCoroutine (GoTo (new Vector3 (0, -2, 0)));
                  
                  isGoing = true;
                  
                  playerAnimator.SetBool ("Is going", isGoing);
               }
               
               else if (hit.collider.gameObject.CompareTag ("Collision floor")) {
                  StartCoroutine (GoTo (new Vector3 (theMousePos.x, theMousePos.y, 0)));
                  
                  isGoing = true;
                  
                  playerAnimator.SetBool ("Is going", isGoing);
               }
            }
         }
      }
   }
   
   public IEnumerator GoTo (Vector3 destination) {
      
      Vector3 dir = (destination - playerTransform.position).normalized;
      
      playerTransform.Translate (dir * Time.deltaTime * speed);
      
      yield return 0;
      
      if (Vector3.Distance (playerTransform.position, destination) < Time.deltaTime * speed) {
         playerTransform.position = destination;
         
         isGoing = false;
      
         playerAnimator.SetBool ("Is going", isGoing);
      }
      
      else {
         StartCoroutine (GoTo (destination));
      }
   }
}