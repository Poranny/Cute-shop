using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour {
   
   public ShopController shopControl;
   public PlayerMoneyController playerMoneyControl;
   
   public SpriteRenderer playerDressRenderer;
   
   public Sprite basicDressImg;
   public Sprite redDressImg;
   public Sprite greenDressImg;
   public Sprite silverDressImg;
   public Sprite goldenDressImg;
   
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
      shopControl.SetSelectedCloth ("Basic");
   }
   
   public void OnClothBought (Cloth theBoughtCloth) {
      
      shopControl.equipButton.SetActive (true);
      shopControl.buyButton.SetActive (false);
      
      switch (theBoughtCloth.name) {
         case "Red" :
            shopControl.redPriceText.SetActive (false);
         break;
         
         case "Green" :
            shopControl.greenPriceText.SetActive (false);
         break;
         
         case "Silver" :
            shopControl.silverPriceText.SetActive (false);
         break;
         
         case "Golden" :
            shopControl.goldenPriceText.SetActive (false);
         break;
      }
      
      shopControl.sellButton.SetActive (true);
   }
   
   public void OnClothEquipped (Cloth theBoughtCloth) {
      
      shopControl.equippedSign.SetActive (true);
      
      shopControl.equipButton.SetActive (false);
      
      shopControl.basicEquippedTick.SetActive (false);
      shopControl.redEquippedTick.SetActive (false);
      shopControl.greenEquippedTick.SetActive (false);
      shopControl.silverEquippedTick.SetActive (false);
      shopControl.goldenEquippedTick.SetActive (false);
      
      switch (theBoughtCloth.name) {
         case "Basic" :
            shopControl.basicEquippedTick.SetActive (true);
         break;
         
         case "Red" :
            shopControl.redEquippedTick.SetActive (true);
         break;
         
         case "Green" :
            shopControl.greenEquippedTick.SetActive (true);
         break;
         
         case "Silver" :
            shopControl.silverEquippedTick.SetActive (true);
         break;
         
         case "Golden" :
            shopControl.goldenEquippedTick.SetActive (true);
         break;
      }
   }
   
   public void OnClothSold (Cloth theSoldCloth) {
      
      shopControl.equipButton.SetActive (false);
      shopControl.buyButton.SetActive (true);
      
      if (currentCloth == theSoldCloth) {
         basicDress.Equip ();
      }
      
      switch (theSoldCloth.name) {
         case "Red" :
            shopControl.redPriceText.SetActive (true);
         break;
         
         case "Green" :
            shopControl.greenPriceText.SetActive (true);
         break;
         
         case "Silver" :
            shopControl.silverPriceText.SetActive (true);
         break;
         
         case "Golden" :
            shopControl.goldenPriceText.SetActive (true);
         break;
      }
      
      shopControl.SetSelectedCloth (theSoldCloth.name);
   }
}

public class Cloth {
   
   public EquipmentController equipControl;
   public SpriteRenderer playerDressRenderer;
   
   public string name;
   
   public int price;
   
   public bool isBought;
   
   Sprite img;
   
   public Cloth (string getName, int getPrice, Sprite getImg, SpriteRenderer getPlayerDressRenderer, EquipmentController getEquipControl, bool getIsBought = false) {
      
      name = getName;
      price = getPrice;
      img = getImg;
      
      isBought = getIsBought;
      
      playerDressRenderer = getPlayerDressRenderer;
      
      equipControl = getEquipControl;
   }
   
   public void Buy () {
      
      isBought = true;
      
      equipControl.playerMoneyControl.ReduceMoney (price);
      
      equipControl.OnClothBought (this);
   }
   
   public void Equip () {
      
      equipControl.currentCloth = this;
      
      playerDressRenderer.sprite = img;
      
      equipControl.OnClothEquipped (this);
   }
   
   public void Sell () {
      
      isBought = false;
      
      equipControl.playerMoneyControl.IncreaseMoney (price);
      
      equipControl.OnClothSold (this);
   }
}