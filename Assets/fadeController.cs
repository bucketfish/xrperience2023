using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using ElRaccoone.Tweens;


public class fadeController : MonoBehaviour
{

  string changeToSceneName = "";

  public GameObject fadeBall;
    // Start is called before the first frame update
    void Start()
    {
      fadeBall.SetActive(true);
      fadeBall.gameObject.TweenMaterialAlpha(0.0f, 0.3f).SetFrom(1f).SetOnComplete(hideObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeScene(string scenename) {
      changeToSceneName = scenename;
      fadeBall.SetActive(true);
      fadeBall.gameObject.TweenMaterialAlpha(1.0f, 0.3f).SetFrom(0.0f);
      Invoke("changeSceneTo", 0.4f);
    }

    public void hideObject(){
      fadeBall.SetActive(false);
    }
    public void changeSceneTo() {
      SceneManager.LoadScene(changeToSceneName);
    }

}
