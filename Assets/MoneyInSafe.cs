using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyInSafe : MonoBehaviour
{

    public string ChangeSceneTo;
    public GameObject fadeController;

    // public
    // Start is called before the first frame update
    void Start()
    {
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
      fadeController.SendMessage("changeScene", ChangeSceneTo);

      // SceneManager.LoadScene(ChangeSceneTo);
    }
}
