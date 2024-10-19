using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class intro_ui_functions : MonoBehaviour
{
    [SerializeField] Animator anm;
    [SerializeField] TMP_InputField username_inp;
    [SerializeField] TextMeshProUGUI username_tmpro, user_score_tmpro;
    [SerializeField] Transform [] levels_buttons;

    void Start()
    {
       
        Discover_Username();
        float score = PlayerPrefs.GetFloat("score");
        for(int i=0;i<levels_buttons.Length;i++)
        {
            
            levels_buttons[i].GetChild(1).gameObject.SetActive(!(score>=i*1000));
        }
    }
    void Discover_Username()
    {
        bool has_username = PlayerPrefs.GetString("username") != string.Empty;
     
        if(has_username)
        {
            anm.SetTrigger("show_main_panel");
            username_tmpro.text = PlayerPrefs.GetString("username");
            print(PlayerPrefs.GetString("username"));
            user_score_tmpro.text = PlayerPrefs.GetFloat("score").ToString();

        }
        else
        {
            anm.SetTrigger("show_username_panel");

        }
        

    }
    public void Set_Username()
    {
        PlayerPrefs.SetString("username", username_inp.text);
        anm.SetTrigger("hide_username_panel");
        Discover_Username();
    }
    public void Load_Hide_Levels(string to_do)
    {
        anm.SetTrigger($"{to_do}_levels");
    }
    public void Load_Level(int index)
    {
        SceneManager.LoadScene(index);
    }    
    public void Exit()
    {
        Application.Quit();
    }
    public void Load_Main_Panel()
    {
        anm.SetTrigger("show_main_panel");
    }
    public void Realod_Current_Scene()
    {
        var ind = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(ind);
    }
    public void Reset_Score_Username()
    {
        PlayerPrefs.DeleteAll();
        Discover_Username();
    }
}
