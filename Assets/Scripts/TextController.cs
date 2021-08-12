using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update

    public SpriteRenderer currentDonut;
    public Sprite JD;
    public Sprite Oldie;
    public Sprite Berry;
    public Sprite Glazed;
    public int nextScene;
    string dialogueText;
    string currentName;
    public TextBehavior dialogue;
    public TextImport script;
    bool isActivated;
    List<string> splitScript;
    int index;

    void Start()
    {
        isActivated = false;
        splitScript = script.splitScript;
        index = 0;
        dialogueText = ProcessDialogue(splitScript[index]);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated == false) {
                isActivated = !isActivated;
                dialogue.Show(dialogueText, currentName);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
            if (dialogue.isAtEnd() == true){
                isActivated = !isActivated;
                dialogue.Close();
                if (index != splitScript.Count - 1) {
                    index += 1;
                    dialogueText = ProcessDialogue(splitScript[index]);
                }
                else {
                    SceneManager.LoadScene(nextScene);
                }
            }
            else {
                dialogue.SpeedUp();
            }
        }
    }

    string ProcessDialogue(string inputLine) {
        bool foundDialogue = false;
        while (foundDialogue == false) {
            foundDialogue = true;
            if (inputLine.Contains("[name]")){
                inputLine = inputLine.Replace("[name]", PlayerPrefs.GetString("playerName"));
            }
            if (inputLine.Contains(":")){
                List<string> splitLine = new List<string>();
                splitLine.AddRange(inputLine.Split(":"[0]));
                currentName = splitLine[0];
                inputLine = splitLine[1];
                if (currentName == "JD") {
                    currentDonut.sprite = JD;
                }
                else if (currentName == "Oldie") {
                    currentDonut.sprite = Oldie;
                }
                else if (currentName == "Berry") {
                    currentDonut.sprite = Berry;
                }
                else if (currentName == "Glazed") {
                    currentDonut.sprite = Glazed;
                }
                else {
                    currentDonut.sprite = null;
                }
            }
            else {
                currentName = "None";
                currentDonut.sprite = null;
            }
        }
        return inputLine;
    }
}
