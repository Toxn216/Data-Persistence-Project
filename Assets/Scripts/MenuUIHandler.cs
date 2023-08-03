using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text PlayerNameInput;
    public GameObject enterNamePlz;

    private bool m_enterNamePlz = false;

    public void StartGame()
    {
        string playerNameIn = PlayerNameInput.text;
        if (!string.IsNullOrEmpty(playerNameIn))
        {
            SceneManager.LoadScene(1);
            m_enterNamePlz = false;
            enterNamePlz.SetActive(false);
        }
        else
        {
            Debug.Log("¬ведите им€");
            m_enterNamePlz = true;
            enterNamePlz.SetActive(true);
        }
    }
    public void SetPlayerName()
    {
        PlayerDataHandle.Instance.PlayerName = PlayerNameInput.text;
    }
    public void ResetData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("‘айл JSON был удален.");
        }
    }

    public void Exit()
    {
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
