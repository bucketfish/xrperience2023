using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawerBoxes : MonoBehaviour
{

    public GameObject objectText;

    public bool isCorrect = false;

    public GameObject answer = null;
    public string changeSceneTo = "";
    public GameObject fadeController;

    // public string ChangeSceneTo;

    int count = 0;
    bool go = false;
    int speed = 5;

    bool goBackwards = false;
    bool isOpen = false;

    Vector3 originalLocation = Vector3.zero;

    Vector3 newLocation = Vector3.zero;



    Vector3 closedPosition = Vector3.zero;
    Vector3 openPosition = Vector3.zero;
    // public
    // Start is called before the first frame update
    void Start()
    {

      originalLocation = transform.parent.gameObject.transform.position;
      newLocation = originalLocation + 0.15f * transform.forward;

      // OnPointerClick();
    }

    // Update is called once per frame
    void Update()
    {
      if (go) {



        count += 1;

        if (!goBackwards) {
          transform.parent.gameObject.transform.position = Vector3.Lerp(transform.parent.gameObject.transform.position, newLocation, 2);

          if (transform.parent.gameObject.transform.position == newLocation){
            go = false;
          }
        }
        else {
          transform.parent.gameObject.transform.position = Vector3.Lerp(transform.parent.gameObject.transform.position, originalLocation, 2);

          if (transform.parent.gameObject.transform.position == originalLocation) {
            go = false;
          }
        }



      }
    }


    public void OnPointerEnter()
    {
      objectText.transform.LookAt(Camera.main.transform);

      objectText.SetActive(true);
    }

    public void OnPointerExit()
    {
      objectText.SetActive(false);
    }

    public void OnPointerClick()
    {

      if (isOpen == false) {
        isOpen = true;
        goBackwards = false;
      }
      else if (isOpen == true && isCorrect == false) {
        isOpen = false;
        goBackwards = true;
      }
      else {

      }

      go = true;
      count = 0;

      if (isCorrect && !isOpen){
        print("a");
        answer.transform.position = answer.transform.position + (0.15f * Vector3.up);
      }
      else if (isCorrect && isOpen) {
        fadeController.SendMessage("changeScene", changeSceneTo);

        // SceneManager.LoadScene(changeSceneTo);
      }

    }
}
