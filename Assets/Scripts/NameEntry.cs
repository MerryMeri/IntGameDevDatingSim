using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NameEntry : MonoBehaviour
{
    string getName;
    public Button startGame;
    public TMP_InputField textEntry;
    // Start is called before the first frame update
    void Start()
    {
        startGame.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        getName = textEntry.text;
        PlayerPrefs.SetString("playerName", textEntry.text);
        SceneManager.LoadScene(1);
    }
}
