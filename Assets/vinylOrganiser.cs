using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using ElRaccoone.Tweens;


public class vinylOrganiser : MonoBehaviour
{
    public GameObject[] vinyls;
    public int centerNum = 0; // 0 - 5, the index of vinyl in the center

    public GameObject incorrectText;
    public GameObject correctText;

    public GameObject fadeController;



    Vector3 leftRootPosition = new Vector3(0.343f, 0.652f, -0.645f);
    Vector3 leftRotation = new Vector3(90f, 180f, 90f);

    Vector3 centerPosition = new Vector3(-0.072f, 0.594f, -0.434f);
    Vector3 centerRotation = new Vector3(39.621f, 0f, 0f);

    Vector3 rightRootPosition = new Vector3(-0.481f, 0.652f, -0.645f);
    Vector3 rightRotation = new Vector3(90f, 180f, 90f);

    Vector3 vinylDisplacement = new Vector3(0.019f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
      incorrectText.SetActive(false);
      correctText.SetActive(false);


      for (int i = 0; i < 6; i++) {
        if (vinyls[i].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum == 0) {
          // vinyls is at left
          vinyls[i].transform.eulerAngles = leftRotation;
          vinyls[i].transform.position = leftRootPosition - (float)i * vinylDisplacement;
        }
        else if (vinyls[i].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum == 1) {
           // center
          vinyls[i].transform.eulerAngles = centerRotation;
          vinyls[i].transform.position = centerPosition;
        }
        else {
          vinyls[i].transform.eulerAngles = rightRotation;
          vinyls[i].transform.position = rightRootPosition + (float)(5-centerNum) * vinylDisplacement;
        }

      }

      moveVinylLeft();
      // moveVinylRight();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void moveVinylLeft() {
      vinyls[centerNum].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum = 2;

      tweenObjectRotation(vinyls[centerNum], rightRotation);
      tweenObjectPosition(vinyls[centerNum], rightRootPosition + (float)(5-centerNum) * vinylDisplacement);

      centerNum -= 1;
      if (centerNum < 0) {
        centerNum = 0;
      }

      tweenObjectRotation(vinyls[centerNum], centerRotation);
      tweenObjectPosition(vinyls[centerNum], centerPosition);
      vinyls[centerNum].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum = 1;

    }

    public void moveVinylRight() { // 0 = click on left, 1 = click on right

      print("moving");

      vinyls[centerNum].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum = 0;

      tweenObjectRotation(vinyls[centerNum], leftRotation);
      tweenObjectPosition(vinyls[centerNum], leftRootPosition - (float)(centerNum) * vinylDisplacement);


      // vinyls[centerNum].transform.eulerAngles = new Vector3(90f, 180f, 90f);
      // vinyls[centerNum].transform.position = new Vector3(0.343f, 0.652f, -0.645f) - (float)centerNum * vinylDisplacement;



      centerNum += 1;
      if (centerNum >= 6) {
        centerNum = 5;
      }

      tweenObjectRotation(vinyls[centerNum], centerRotation);
      tweenObjectPosition(vinyls[centerNum], centerPosition);
      vinyls[centerNum].transform.GetChild(0).transform.GetChild(0).GetComponent<vinyl>().locationNum = 1;


      // vinyls[centerNum].transform.eulerAngles = new Vector3(22f, 0f, 0f);
      // vinyls[centerNum].transform.position = new Vector3(-0.072f, 0.556f, -0.449f);

    }



    private void tweenObjectRotation(GameObject vinylObject, Vector3 rotation) {
      vinylObject.gameObject.TweenRotation(rotation, 0.3f).SetFrom(vinylObject.transform.rotation.ToEulerAngles()).Await();
    }

    private void tweenObjectPosition(GameObject vinylObject, Vector3 position) {
      vinylObject.gameObject.TweenPosition(position, 0.3f).SetFrom(vinylObject.transform.position).Await();
    }

    public void incorrect() {
      incorrectText.SetActive(true);

      Invoke("hideIncorrect", 0.3f);

    }

    public void correct() {
      correctText.SetActive(true);

      Invoke("finishedCorrect", 0.3f);

    }

    void hideIncorrect() {
      incorrectText.SetActive(false);
    }

    void finishedCorrect() {
      fadeController.SendMessage("changeScene", "Ending Captions");

      // SceneManager.LoadScene("Museum");

    }
}
