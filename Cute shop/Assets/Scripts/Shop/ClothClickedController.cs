using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothClickedController : MonoBehaviour {
   
   public ShopController shopControl;
   
   public string theClothName;
   
   private bool mousePressed;
   
   
   void OnMouseDown () {
      
      mousePressed = true;
   }
   
   void OnMouseExit () {
      
      mousePressed = false;
   }
   
	void OnMouseUp () {
      
      if (mousePressed) {
         shopControl.SetSelectedCloth (theClothName);
      }
   }
}