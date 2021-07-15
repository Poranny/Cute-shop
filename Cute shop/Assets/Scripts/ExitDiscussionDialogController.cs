using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDiscussionDialogController : MonoBehaviour {
   
   public DiscussionController discussControl;
   
   private bool mousePressed;
   
   
   void OnMouseDown () {
      
      mousePressed = true;
   }
   
   void OnMouseExit () {
      
      mousePressed = false;
   }
   
	void OnMouseUp () {
      
      if (mousePressed) {
         discussControl.ExitChosen ();
      }
   }
}