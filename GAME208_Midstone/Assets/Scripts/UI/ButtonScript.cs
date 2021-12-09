using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject Healthbar;
    public GameObject ExitButton;
    public GameObject Background;
    public GameObject Title;
    public GameObject PlayButton;
    public GameObject TitleDeath;
    public GameObject TitleWin;
    public GameObject Credits;
    public GameObject ReturnButton;

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

        TitleWin.SetActive(false);
        Credits.SetActive(false);

        Time.timeScale = 1;
    }
    public void onClickReturn()
    {
        gameObject.SetActive(true);
        Healthbar.SetActive(false);
        ExitButton.SetActive(true);
        Background.SetActive(true);
        PlayButton.SetActive(true);
        Title.SetActive(true);
        TitleDeath.SetActive(false);
        ReturnButton.SetActive(false);

        TitleWin.SetActive(false);
        Credits.SetActive(false);

        Time.timeScale = 0;
        SceneManager.LoadScene("SampleScene");
    }
    public void toggleDeath()
    {
        gameObject.SetActive(true);
        Healthbar.SetActive(false);
        ExitButton.SetActive(false);
        Background.SetActive(true);
        PlayButton.SetActive(false);
        Title.SetActive(false);
        TitleDeath.SetActive(true);
        ReturnButton.SetActive(true);

        TitleWin.SetActive(false);
        Credits.SetActive(false);

        Time.timeScale = 0;
    }
    public void toggleWin()
    {
        gameObject.SetActive(true);
        Healthbar.SetActive(false);
        ExitButton.SetActive(false);
        Background.SetActive(true);
        PlayButton.SetActive(false);
        Title.SetActive(false);
        TitleDeath.SetActive(false);
        ReturnButton.SetActive(true);

        TitleWin.SetActive(true);
        Credits.SetActive(true);

        Time.timeScale = 0;
    }
    public void onClickExit()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
