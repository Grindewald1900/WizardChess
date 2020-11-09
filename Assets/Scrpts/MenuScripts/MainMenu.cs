using System.Collections;
using System.Collections.Generic;
using Scrpts.ToolScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GotoSettings()
    {
        Debug.Log("Setting");
        GameObject.Find("MainMenu").gameObject.SetActive(false);
        GameObject.Find("SettingMenu").gameObject.SetActive(true);

    }
    
    public void GotoMainMenu()
    {
        Debug.Log("Main");
        GameObject.Find("MainMenu").gameObject.SetActive(true);
        GameObject.Find("SettingMenu").gameObject.SetActive(false);
    }

    public void OnToggleChanged()
    {
        Debug.Log(GameObject.Find("Toggle").GetComponent<Toggle>().isOn);
        InitConfig.DUAL_AI = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
    }

    public void OnDropDownChanged()
    {
        Debug.Log(GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        switch (GameObject.Find("Dropdown").GetComponent<Dropdown>().value)
        {
            case 0:
                InitConfig.AI_TYPE = InitConfig.AI_MINIMAX_LOOP;
                break;
            case 1:
                InitConfig.AI_TYPE = InitConfig.AI_MINIMAX_ALPHA_BETA;
                break;
            case 2:
                InitConfig.AI_TYPE = InitConfig.AI_RANDOM;
                break;
        }
    }
}
