using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
   
   public PlayerMovementController playerMoveControl;
   public EquipmentController equipControl;
   
   public GameObject shopDialog;
   
   public GameObject equippedSign;
   
   public GameObject equipButton;
   public GameObject buyButton;
   public GameObject sellButton;
   
   public GameObject basicSelectionShadow;
   public GameObject redSelectionShadow;
   public GameObject greenSelectionShadow;
   public GameObject silverSelectionShadow;
   public GameObject goldenSelectionShadow;
   
   public GameObject redPriceText;
   public GameObject greenPriceText;
   public GameObject silverPriceText;
   public GameObject goldenPriceText;
   
   public GameObject basicEquippedTick;
   public GameObject redEquippedTick;
   public GameObject greenEquippedTick;
   public GameObject silverEquippedTick;
   public GameObject goldenEquippedTick;
   
   
   public Cloth selectedCloth;
   
   
   public void OpenTheShop () {
      
      shopDialog.SetActive (true);
   }
   
   public void CloseTheShop () {
      
      shopDialog.SetActive (false);
      
      ResetSelection ();
   }
   
   public void SetSelectedCloth (string newClothName) {
      
      switch (newClothName) {
         case "Basic" :
            selectedCloth = equipControl.basicDress;
            
            sellButton.SetActive (false);
            
            SetSelectionShadow (basicSelectionShadow);
         break;
         
         case "Red" :
            selectedCloth = equipControl.redDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (redSelectionShadow);
         break;
         
         case "Green" :
            selectedCloth = equipControl.greenDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (greenSelectionShadow);
         break;
         
         case "Silver" :
            selectedCloth = equipControl.silverDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (silverSelectionShadow);
         break;
         
         case "Golden" :
            selectedCloth = equipControl.goldenDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (goldenSelectionShadow);
         break;
      }
      
      if (selectedCloth == equipControl.currentCloth) {
         equippedSign.SetActive (true);
         
         buyButton.SetActive (false);
         equipButton.SetActive (false);
      }
      
      else {
         if (selectedCloth.isBought) {
            equipButton.SetActive (true);
            buyButton.SetActive (false);
            
            if (selectedCloth.name != "Basic") {
               sellButton.SetActive (true);
            }
         }
         
         else {
            buyButton.SetActive (true);
            equipButton.SetActive (false);
            
            sellButton.SetActive (false);
         }
         
         equippedSign.SetActive (false);
      }
   }
   
   public void SetSelectionShadow (GameObject chosenSelectionShadow) {
      
      basicSelectionShadow.SetActive (false);
      redSelectionShadow.SetActive (false);
      greenSelectionShadow.SetActive (false);
      silverSelectionShadow.SetActive (false);
      goldenSelectionShadow.SetActive (false);
      
      chosenSelectionShadow.SetActive (true);
   }
   
   public void ResetSelection () {
      
      SetSelectedCloth ("Basic");
   }
   
   public void BuySelected () {
      
      selectedCloth.Buy ();
      selectedCloth.Equip ();
   }
   
   public void EquipSelected () {
      
      selectedCloth.Equip ();
   }
   
   public void SellSelected () {
      
      selectedCloth.Sell ();
   }
}