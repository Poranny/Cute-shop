using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyController : MonoBehaviour {
   
   public int money;
   
   public TMPro.TextMeshPro moneyText;
   
   
   public void SetMoney (int newAmount) {
      
      money = newAmount;
      
      UpdateMoneyText ();
   }
   
   public void ReduceMoney (int amountToTake) {
      
      money -= amountToTake;
      
      UpdateMoneyText ();
   }
   
   public void UpdateMoneyText () {
      
      string theMoneyTextString = string.Concat ("Money: " + money);
      
      moneyText.text = theMoneyTextString;
   }
}