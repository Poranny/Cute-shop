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
   
   public AudioSource howAreYouSound;
   public AudioSource ohSound;
   public AudioSource greatSound;
   
   public Animator sellerAnimator;
   
   public bool wasShopOpened;
   
   
   public void ShowFirstDialog () {
      
      wasShopOpened = true;
      
      discussion.SetActive (true);
      
      howAreYouSound.Play ();
      
      sellerAnimator.SetTrigger ("Start talking");
   }
   
   public void OptionAChosen () {
      
      firstPanel.SetActive (false);
      
      secondPanelA.SetActive (true);
      
      ohSound.Play ();
      
      sellerAnimator.SetTrigger ("Start talking");
   }
   
   public void OptionBChosen () {
      
      firstPanel.SetActive (false);
      
      secondPanelB.SetActive (true);
      
      greatSound.Play ();
      
      sellerAnimator.SetTrigger ("Start talking");
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