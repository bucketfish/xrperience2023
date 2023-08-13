using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinyl : MonoBehaviour
{
    public int number;
    public bool isCorrect = false;
    public int locationNum = 0; // 0 = left, 1 = center, 2 = right

    Vector3 centerLocation = Vector3.zero;

    public GameObject vinylOrganiser;

    // Start is called before the first frame update
    void Start()
    {

      // originalLocation = transform.parent.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPointerEnter()
    {
    }

    public void OnPointerExit()
    {

    }

    public void OnPointerClick()
    {

      print(locationNum);

      if (locationNum == 0) {
        print("????");
        vinylOrganiser.SendMessage("moveVinylLeft");

      }
      else if (locationNum == 1) {
        // check if vinyl is the correct one
        if (isCorrect) {
          vinylOrganiser.SendMessage("correct");

        }
        else {
          vinylOrganiser.SendMessage("incorrect");
        }

      }
      else {
        vinylOrganiser.SendMessage("moveVinylRight");

      }


    }

    void popBackOut() {
      // transform.parent.gameObject.transform.position = Vector3.Lerp(transform.parent.gameObject.transform.position, originalLocation, 2);
    }

}
