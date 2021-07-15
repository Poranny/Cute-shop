using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscussionController : MonoBehaviour {
   
   public ShopController shopControl;
   
   public GameObject discussion;
   public GameObject firstPanel;
   public GameObject secondPanelA;
   public GameObject secondPanelB;
   
   public GameObject shopPanel;
   
   public bool wasShopOpened;
   
   
   public void ShowFirstDialog () {
      
      wasShopOpened = true;
      
      discussion.SetActive (true);
   }
   
   public void OptionAChosen () {
      
      firstPanel.SetActive (false);
      
      secondPanelA.SetActive (true);
   }
   
   public void OptionBChosen () {
      
      firstPanel.SetActive (false);
      
      secondPanelB.SetActive (true);
   }
   
   public void ExitChosen () {
      
      secondPanelA.SetActive (false);
      secondPanelB.SetActive (false);
      
      discussion.SetActive (false);
   }
   
   public void EnterChosen () {
      
      secondPanelA.SetActive (false);
      secondPanelB.SetActive (false);
      
      discussion.SetActive (false);
      
      shopPanel.SetActive (true);
   }
}