using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{

    public int number;
    public GameObject numberDisplay;

    Vector3 originalLocation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
      originalLocation = transform.parent.gameObject.transform.position;
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

      numberDisplay.SendMessage("inputNumber", number);

      transform.parent.gameObject.transform.position = Vector3.Lerp(transform.parent.gameObject.transform.position, originalLocation + 0.02f * transform.right, 2);

      Invoke("popBackOut", 0.1f);

    }

    void popBackOut() {
      transform.parent.gameObject.transform.position = Vector3.Lerp(transform.parent.gameObject.transform.position, originalLocation, 2);
    }

}
