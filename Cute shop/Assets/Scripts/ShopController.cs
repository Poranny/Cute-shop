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
   
   public SpriteRenderer playerDressRenderer;
   
   public Sprite basicDressImg;
   public Sprite redDressImg;
   public Sprite greenDressImg;
   public Sprite silverDressImg;
   public Sprite goldenDressImg;
   
   
   public Cloth selectedCloth;
   
   public Cloth currentCloth;
   
   public Cloth basicDress;
   public Cloth redDress;
   public Cloth greenDress;
   public Cloth silverDress;
   public Cloth goldenDress;
   
   
   void Start () {
      
      basicDress = new Cloth ("Basic", 0, basicDressImg, playerDressRenderer, this, getIsBought: true);
      redDress = new Cloth ("Red", 10, redDressImg, playerDressRenderer, this);
      greenDress = new Cloth ("Green", 10, greenDressImg, playerDressRenderer, this);
      silverDress = new Cloth ("Silver", 30, silverDressImg, playerDressRenderer, this);
      goldenDress = new Cloth ("Golden", 50, goldenDressImg, playerDressRenderer, this);
      
      basicDress.Equip ();
      SetSelectedCloth ("Basic");
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
            
            sellButton.SetActive (false);
            
            SetSelectionShadow (basicSelectionShadow);
         break;
         
         case "Red" :
            selectedCloth = redDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (redSelectionShadow);
         break;
         
         case "Green" :
            selectedCloth = greenDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (greenSelectionShadow);
         break;
         
         case "Silver" :
            selectedCloth = silverDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (silverSelectionShadow);
         break;
         
         case "Golden" :
            selectedCloth = goldenDress;
            
            sellButton.SetActive (true);
            
            SetSelectionShadow (goldenSelectionShadow);
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
         
         case "Silver" :
            silverPriceText.SetActive (false);
         break;
         
         case "Golden" :
            goldenPriceText.SetActive (false);
         break;
      }
      
      sellButton.SetActive (true);
   }
   
   public void OnClothEquipped (Cloth theBoughtCloth) {
      
      equippedSign.SetActive (true);
      
      equipButton.SetActive (false);
      
      basicEquippedTick.SetActive (false);
      redEquippedTick.SetActive (false);
      greenEquippedTick.SetActive (false);
      silverEquippedTick.SetActive (false);
      goldenEquippedTick.SetActive (false);
      
      switch (theBoughtCloth.name) {
         case "Basic" :
            basicEquippedTick.SetActive (true);
         break;
         
         case "Red" :
            redEquippedTick.SetActive (true);
         break;
         
         case "Green" :
            greenEquippedTick.SetActive (true);
         break;
         
         case "Silver" :
            silverEquippedTick.SetActive (true);
         break;
         
         case "Golden" :
            goldenEquippedTick.SetActive (true);
         break;
      }
   }
   
   public void OnClothSold (Cloth theSoldCloth) {
      
      equipButton.SetActive (false);
      buyButton.SetActive (true);
      
      if (currentCloth == theSoldCloth) {
         basicDress.Equip ();
      }
      
      switch (theSoldCloth.name) {
         case "Red" :
            redPriceText.SetActive (true);
         break;
         
         case "Green" :
            greenPriceText.SetActive (true);
         break;
         
         case "Silver" :
            silverPriceText.SetActive (true);
         break;
         
         case "Golden" :
            goldenPriceText.SetActive (true);
         break;
      }
      
      SetSelectedCloth (theSoldCloth.name);
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
   
   public void Sell () {
      
      isBought = false;
      
      shopControl.playerMoneyControl.IncreaseMoney (price);
      
      shopControl.OnClothSold (this);
   }
}