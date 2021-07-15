using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipButtonController : MonoBehaviour {
   
   public ShopController shopControl;
   
   private bool mousePressed;
   
   
   void OnMouseDown () {
      
      mousePressed = true;
   }
   
   void OnMouseExit () {
      
      mousePressed = false;
   }
   
	void OnMouseUp () {
      
      if (mousePressed) {
         shopControl.EquipSelected ();
      }
   }
}