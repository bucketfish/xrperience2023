using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxText : MonoBehaviour
{

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false);
      transform.LookAt(Camera.main.transform);

    }

    // Update is called once per frame
    void Update()
    {

      if (gameObject.active)
      {
      transform.LookAt(Camera.main.transform);
      }
    }
    //
    // public void ShowText() {
    //   print("AAAA");
    //   transform.LookAt(Camera.main.transform);
    //   gameObject.SetActive(true);
    //
    // }
    //
    // public void HideText() {
    //   gameObject.SetActive(false);
    //
    // }


    public void showOpenText() {
      // text.text = "???";
    }
}
