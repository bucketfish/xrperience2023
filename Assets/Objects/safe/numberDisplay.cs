using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class numberDisplay : MonoBehaviour
{
    public TMP_Text showText;
    public GameObject safeDoor;

    int numberCount = 0;
    string[] numbers = {"_", "_", "_", "_"};

    string[] correctPassword = {"3", "8", "1", "4"};
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void inputNumber(int number){
      print(number);
      numbers[numberCount] = number.ToString();
      numberCount += 1;

      if (numberCount == 4) {
        // add the flashing, etc

        if (string.Join("", (string[])numbers) == "3814") {
          showText.text = string.Join("", (string[])numbers);
          showText.color = new Color32(36, 209, 50, 255);

          Invoke("isCorrect", 0.4f);

        }
        else {
          numbers = new string[4] {"_", "_", "_", "_"};
          showText.text = "XX";
          showText.color = new Color32(232, 37, 37, 255);
          numberCount = 0;

          Invoke("wrongPassword", 0.5f);
        }

      }
      else {
        showText.text = string.Join("", (string[])numbers);
      }

    }

    void wrongPassword() {
      showText.color = new Color32(255, 255, 255, 255);
      showText.text = string.Join("", (string[])numbers);

    }

    void isCorrect() {
      // safeDoor.transform.position =
      safeDoor.transform.Rotate(0, 90, 0, Space.Self);
      safeDoor.transform.position = new Vector3(-0.348f, 0.425f, 0.39f);

    }


}
