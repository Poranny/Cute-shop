using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
   
   public ShopController shopControl;
   public DiscussionController discussControl;
   
   public Transform camTransform;
   public Transform playerTransform;
   
   public Transform thePlantTransform;
   
   public AudioSource footstepsSound;
   public AudioSource breakSound;
   
   public Animator playerAnimator;
   
   public Camera cam;
   
   public float speed;
   
   private bool isGoing;
   
   private bool isPlantBroken;
   
   
   void Update () {
      
      if (Input.GetMouseButton (0)) {
         RaycastHit hit;
         
         Vector3 theMousePos = cam.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, Input.mousePosition.y));
         
         if (Physics.Raycast (theMousePos, Vector3.forward, out hit)) {
            if (!isGoing) {
               if (hit.collider.gameObject.CompareTag ("Collision shop")) {
                  if (discussControl.wasShopOpened) {
                     shopControl.OpenTheShop ();
                  }
                  
                  else {
                     discussControl.ShowFirstDialog ();
                  }
                  
                  StartCoroutine (GoTo (new Vector3 (0, -2, 0)));
                  
                  isGoing = true;
                  
                  playerAnimator.SetBool ("Is going", isGoing);
               }
               
               else if (hit.collider.gameObject.CompareTag ("Collision floor")) {
                  StartCoroutine (GoTo (new Vector3 (theMousePos.x, theMousePos.y, 0)));
                  
                  isGoing = true;
                  
                  playerAnimator.SetBool ("Is going", isGoing);
                  
                  footstepsSound.Play ();
               }
               
               else if (hit.collider.gameObject.CompareTag ("Collision plant")) {
                  if (isPlantBroken) {
                     StartCoroutine (GoTo (new Vector3 (theMousePos.x, theMousePos.y, 0)));
                  }
                  
                  else {
                     isPlantBroken = true;
                     
                     StartCoroutine (GoTo (new Vector3 (theMousePos.x, theMousePos.y, 0), isPlant: true)); // I know it goes a bit messy with passing that bool over and over until the end but I simply thought that given the plant is single there won't be a problem to implement it in this quicker but less clear way. I've come up with this easter egg almost in the end of everything so it was easier to implement this way.
                  }
                  
                  isGoing = true;
                  
                  playerAnimator.SetBool ("Is going", isGoing);
                  
                  footstepsSound.Play ();
               }
            }
         }
      }
   }
   
   public IEnumerator GoTo (Vector3 destination, bool isPlant = false) {
      
      Vector3 dir = (destination - playerTransform.position).normalized;
      
      playerTransform.Translate (dir * Time.deltaTime * speed);
      
      yield return 0;
      
      if (Vector3.Distance (playerTransform.position, destination) < Time.deltaTime * speed) {
         playerTransform.position = destination;
         
         isGoing = false;
      
         playerAnimator.SetBool ("Is going", isGoing);
         
         footstepsSound.Stop ();
         
         if (isPlant) {
            breakSound.Play ();
            
            thePlantTransform.eulerAngles = new Vector3 (0, 0, 90);
            thePlantTransform.position += new Vector3 (-0.1f, 0, 0);
         }
      }
      
      else {
         StartCoroutine (GoTo (destination, isPlant));
      }
   }
}