using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Healthbar;
    public GameObject ExitButton;
    public GameObject Background;
    public GameObject Title;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onClickPlay() {
        gameObject.SetActive(false);
        Healthbar.SetActive(true);
        ExitButton.SetActive(false);
        Background.SetActive(false);
        Title.SetActive(false);
        Time.timeScale = 1;
    }
    public void onClickExit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
