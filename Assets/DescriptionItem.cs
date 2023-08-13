using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class DescriptionItem : MonoBehaviour
{

    public GameObject objectText;
    public string ChangeSceneTo;
    public bool changeScene = false;

    public GameObject highlight;

    public GameObject fadeController;

    // public
    // Start is called before the first frame update
    void Start()
    {
      objectText.SetActive(false);
      if (highlight) {
        highlight.SetActive(false);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnPointerEnter()
    {
      print("test");
      objectText.SetActive(true);

      if (highlight) {
        highlight.SetActive(true);
      }
    }

    public void OnPointerExit()
    {
      objectText.SetActive(false);
      if (highlight) {
        highlight.SetActive(false);
      }
    }

    public void OnPointerClick()
    {
      if (changeScene) {
        fadeController.SendMessage("changeScene", ChangeSceneTo);
        // SceneManager.LoadScene(ChangeSceneTo);
      }

    }
}
