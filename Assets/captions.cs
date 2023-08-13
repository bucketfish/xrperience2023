using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class captions : MonoBehaviour
{

    public TMP_Text showText;
    public GameObject fadeController;

    public int whichCaption = 0;

    string[] starting = {"The year is 2150, and humans successfully invented a time machine that you managed to get your hands on.", "You decide to go to the past to collect ancient relics which you can sell in the black market for lots of money."};

    string[] conversationText = {
      "Tengu Long: Thank you Raffles, for saving me from my exile. Is there anything I could do to repay you?",
      "Sir Stamford Raffles: You’re very welcome. I do not wish for any repayment as I did this out of the kindness of my heart.",
      "Tengu Long: But I insist!",
      "Sir Stamford Raffles: Well then, it would help me greatly if you could help grant the British the right to establish a trading post in Singapore.",
      "Sir Stamford Raffles: I understand that this is a lot to ask, but in return, we’ll offer to recognise you as the rightful Sultan of Johor-",
      "Sir Stamford Raffles: -and provide you with a yearly payment of $5000 and $3000 to the Temenggong.",
      "Tengu Long: As you wish.",
      "Sir Stamford Raffles: Great! I have the treaty prepared in the red cabinet in my office, in the bottom drawer."
    };


    string[] ending = {"I’ve learnt so much more about Singapore’s history.", "Our pioneers have been through so many hardships to shape Singapore.", "You know what, maybe it’s not right for me to sell these artefacts.", "I should play my part in preserving Singapore's heritage...", "Maybe I could donate them to the National Museum instead!"};

    int captionNum = 0;
    // Start is called before the first frame update
    void Start()
    {

      if (whichCaption == 0) {
        Invoke("startingCaption", 0.5f);

      }
      else if (whichCaption == 1) {
        Invoke("conversation", 0.5f);
      }
      else {
        Invoke("updateCaption", 0.5f);

      }

    }

    public void startingCaption() {
      if (captionNum < 2) {
        showText.text = starting[captionNum];
        captionNum += 1;
        Invoke("startingCaption", 4);

      }
      else {
        fadeController.SendMessage("changeScene", "Museum");
      }
    }

    public void conversation() {
      if (captionNum < 8) {
        showText.text = conversationText[captionNum];
        if (captionNum == 0 || captionNum == 2 || captionNum == 6) {
          showText.color = new Color32(145, 173, 78, 255);
        }
        else {
          showText.color = new Color32(130, 139, 237, 255);
        }
        captionNum += 1;
        Invoke("conversation", 4);
      }
      else {
      }
    }


    public void updateCaption() {
      if (captionNum < 5) {
        showText.text = ending[captionNum];
        captionNum += 1;
        Invoke("updateCaption", 4);

      }
      else {
        fadeController.SendMessage("changeScene", "Museum New");
      }
    }


}
