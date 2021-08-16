using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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
    public Button decisionButton1;
    public Button decisionButton2;
    public Button decisionButton3;
    bool isDecisionHappening;
    bool isActivated;
    List<string> splitScript;
    int index;

    void Start()
    {
        isActivated = false;
        splitScript = script.splitScript;
        index = 0;
        dialogueText = ProcessDialogue(splitScript[index]);
        decisionButton1.interactable = false;
        decisionButton2.interactable = false;
        decisionButton3.interactable = false;
        isDecisionHappening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDecisionHappening == false) {
            if (isActivated == false) {
                isActivated = !isActivated;
                if (!dialogueText.Contains("waitCommand")){
                    dialogue.Show(dialogueText, currentName);
                }
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
                if (dialogue.isAtEnd() == true){
                    isActivated = !isActivated;
                    if (index != splitScript.Count - 1) {
                        index += 1;
                    }
                    else {
                        SceneManager.LoadScene(nextScene);
                    }
                    dialogueText = ProcessDialogue(splitScript[index]);
                    if (!dialogueText.Contains("waitCommand")) {
                        dialogue.Close();
                    }
                }
                else {
                    dialogue.SpeedUp();
                }
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
            if (inputLine.Contains("decisionBranch")) {
                currentDonut.sprite = null;
                List<string> decisions = new List<string>();
                int countDecisions = 0;
                index += 1;
                while (!splitScript[index].Contains("endDecision")) {
                    string tempDecision = splitScript[index];
                    if (tempDecision.Contains("[name]")){
                        tempDecision = tempDecision.Replace("[name]", PlayerPrefs.GetString("playerName"));
                    }
                    decisions.Add(tempDecision);
                    countDecisions += 1;
                    index += 1;
                }
                if (countDecisions == 2) {
                    decisionButton1.GetComponentInChildren<TextMeshProUGUI>().text = decisions[0];
                    decisionButton2.GetComponentInChildren<TextMeshProUGUI>().text = decisions[1];
                    MakeDecision(2);
                    return "waitCommand";
                }
                else {
                    decisionButton1.GetComponentInChildren<TextMeshProUGUI>().text = decisions[0];
                    decisionButton2.GetComponentInChildren<TextMeshProUGUI>().text = decisions[1];
                    decisionButton3.GetComponentInChildren<TextMeshProUGUI>().text = decisions[2];
                    MakeDecision(3);
                    return "waitCommand";
                }
            }
            if (inputLine.Contains("backToMain")) {
                while (!splitScript[index].Contains("mainContinue")) {
                    index += 1;
                }
                index += 1;
                inputLine = splitScript[index];
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
            else if (foundDialogue == true) {
                currentName = "None";
            }
        }
        return inputLine;
    }

    void MakeDecision(int decisionCount) {
        isDecisionHappening = true;
        decisionButton1.interactable = true;
        decisionButton2.interactable = true;
        decisionButton1.onClick.AddListener(delegate {TaskOnClick1(decisionCount); });
        decisionButton2.onClick.AddListener(delegate {TaskOnClick2(decisionCount); });
        if (decisionCount == 3) {
            decisionButton3.interactable = true;
            decisionButton3.onClick.AddListener(delegate {TaskOnClick3(decisionCount); });
        }
    }

    void TaskOnClick1(int decisionCount) {
        isDecisionHappening = false;
        decisionButton1.interactable = false;
        decisionButton2.interactable = false;
        decisionButton1.onClick.RemoveAllListeners();
        decisionButton2.onClick.RemoveAllListeners();
        if (decisionCount == 3) {
            decisionButton3.interactable = false;
            decisionButton3.onClick.RemoveAllListeners();
        }
        while (!splitScript[index].Contains("startBranch1")) {
            index += 1;
        }
        index += 1;
        dialogueText = ProcessDialogue(splitScript[index]); 
    }

    void TaskOnClick2(int decisionCount) {
        isDecisionHappening = false;
        decisionButton1.interactable = false;
        decisionButton2.interactable = false;
        decisionButton1.onClick.RemoveAllListeners();
        decisionButton2.onClick.RemoveAllListeners();
        if (decisionCount == 3) {
            decisionButton3.interactable = false;
            decisionButton3.onClick.RemoveAllListeners();
        }
        while (!splitScript[index].Contains("startBranch2")) {
            index += 1;
        }
        index += 1;
        dialogueText = ProcessDialogue(splitScript[index]);
    }

    void TaskOnClick3(int decisionCount) {
        isDecisionHappening = false;
        decisionButton1.interactable = false;
        decisionButton2.interactable = false;
        decisionButton1.onClick.RemoveAllListeners();
        decisionButton2.onClick.RemoveAllListeners();
        if (decisionCount == 3) {
            decisionButton3.interactable = false;
            decisionButton3.onClick.RemoveAllListeners();
        }
        while (!splitScript[index].Contains("startBranch3")) {
            index += 1;
        }
        index += 1;
        dialogueText = ProcessDialogue(splitScript[index]);
    }
}
