using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {
   
   public PlayerMovementController playerMoveControl;
   public PlayerMoneyController playerMoneyControl;
   
   
   public GameObject shopDialog;
   
   public GameObject equippedSign;
   
   public GameObject equipButton;
   public GameObject buyButton;
   
   public GameObject basicSelectionShadow;
   public GameObject redSelectionShadow;
   public GameObject greenSelectionShadow;
   
   public GameObject redPriceText;
   public GameObject greenPriceText;
   
   public SpriteRenderer playerDressRenderer;
   
   public Sprite basicDressImg;
   public Sprite redDressImg;
   public Sprite greenDressImg;
   
   
   public Cloth selectedCloth;
   
   public Cloth currentCloth;
   
   public Cloth basicDress;
   public Cloth redDress;
   public Cloth greenDress;
   
   
   void Start () {
      
      basicDress = new Cloth ("Basic", 0, basicDressImg, playerDressRenderer, this, getIsBought: true);
      redDress = new Cloth ("Red", 10, redDressImg, playerDressRenderer, this);
      greenDress = new Cloth ("Green", 10, greenDressImg, playerDressRenderer, this);
      
      basicDress.Equip ();
      SetSelectionShadow (basicSelectionShadow);
   }
   
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
            selectedCloth = basicDress;
            
            basicSelectionShadow.SetActive (true);
            
            SetSelectionShadow (basicSelectionShadow);
         break;
         
         case "Red" :
            selectedCloth = redDress;
            
            redSelectionShadow.SetActive (true);
            
            SetSelectionShadow (redSelectionShadow);
         break;
         
         case "Green" :
            selectedCloth = greenDress;
            
            greenSelectionShadow.SetActive (true);
            
            SetSelectionShadow (greenSelectionShadow);
         break;
      }
      
      if (selectedCloth == currentCloth) {
         equippedSign.SetActive (true);
         
         buyButton.SetActive (false);
         equipButton.SetActive (false);
      }
      
      else {
         if (selectedCloth.isBought) {
            equipButton.SetActive (true);
            buyButton.SetActive (false);
         }
         
         else {
            buyButton.SetActive (true);
            equipButton.SetActive (false);
         }
         
         equippedSign.SetActive (false);
      }
   }
   
   public void SetSelectionShadow (GameObject chosenSelectionShadow) {
      
      basicSelectionShadow.SetActive (false);
      redSelectionShadow.SetActive (false);
      greenSelectionShadow.SetActive (false);
      
      chosenSelectionShadow.SetActive (true);
   }
   
   public void ResetSelection () {
      
      basicSelectionShadow.SetActive (true);
      redSelectionShadow.SetActive (false);
      greenSelectionShadow.SetActive (false);
      
      buyButton.SetActive (false);
      equipButton.SetActive (false);
      equippedSign.SetActive (false);
   }
   
   public void BuySelected () {
      
      selectedCloth.Buy ();
      selectedCloth.Equip ();
   }
   
   public void EquipSelected () {
      
      selectedCloth.Equip ();
   }
   
   public void OnClothBought (Cloth theBoughtCloth) {
      
      equipButton.SetActive (true);
      buyButton.SetActive (false);
      
      switch (theBoughtCloth.name) {
         case "Red" :
            redPriceText.SetActive (false);
         break;
         
         case "Green" :
            greenPriceText.SetActive (false);
         break;
      }
   }
   
   public void OnClothEquipped (Cloth theBoughtCloth) {
      
      equippedSign.SetActive (true);
      
      equipButton.SetActive (false);
      
      switch (theBoughtCloth.name) {
         case "Basic" :
         break;
         
         case "Red" :
         break;
         
         case "Green" :
         break;
      }
   }
}

public class Cloth {
   
   public ShopController shopControl;
   public SpriteRenderer playerDressRenderer;
   
   public string name;
   
   public int price;
   
   public bool isBought;
   
   Sprite img;
   
   public Cloth (string getName, int getPrice, Sprite getImg, SpriteRenderer getPlayerDressRenderer, ShopController getShopControl, bool getIsBought = false) {
      
      name = getName;
      price = getPrice;
      img = getImg;
      
      isBought = getIsBought;
      
      playerDressRenderer = getPlayerDressRenderer;
      
      shopControl = getShopControl;
   }
   
   public void Buy () {
      
      isBought = true;
      
      shopControl.playerMoneyControl.ReduceMoney (price);
      
      shopControl.OnClothBought (this);
   }
   
   public void Equip () {
      
      shopControl.currentCloth = this;
      
      playerDressRenderer.sprite = img;
      
      shopControl.OnClothEquipped (this);
   }
}