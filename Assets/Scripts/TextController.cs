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
    public Sprite Mystery;
    public int nextScene;
    string dialogueText;
    string currentName;
    public TextBehavior dialogue;
    public TextImport script;
    public GameObject decisionButton1;
    public GameObject decisionButton2;
    public GameObject decisionButton3;
    bool isDecisionHappening;
    bool isActivated;
    List<string> splitScript;
    int index;
    int depth;
    List<int> choiceTree;
    void Start()
    {
        isActivated = false;
        splitScript = script.splitScript;
        index = 0;
        dialogueText = ProcessDialogue(splitScript[index]);
        decisionButton1.SetActive(false);
        decisionButton2.SetActive(false);
        decisionButton3.SetActive(false);
        isDecisionHappening = false;
        depth = 0;
        choiceTree = new List<int>();
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
                depth = 0;
                choiceTree = new List<int>();
                while (!splitScript[index].Contains("mainContinue")) {
                    index += 1;
                }
                index += 1;
                inputLine = splitScript[index];
            }
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
                else if (currentName == "???") {
                    currentDonut.sprite = Mystery;
                }
                else if (currentName != PlayerPrefs.GetString("playerName")) {
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
        decisionButton1.SetActive(true);
        decisionButton2.SetActive(true);
        decisionButton1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {TaskOnClick(decisionCount, 1); });
        decisionButton2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {TaskOnClick(decisionCount, 2); });
        if (decisionCount == 3) {
            decisionButton3.SetActive(true);
            decisionButton3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {TaskOnClick(decisionCount, 3); });
        }
    }

    void TaskOnClick(int decisionCount, int choice) {
        isDecisionHappening = false;
        decisionButton1.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        decisionButton2.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
        decisionButton1.SetActive(false);
        decisionButton2.SetActive(false);
        if (decisionCount == 3) {
            decisionButton3.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            decisionButton3.SetActive(false);
        }
        depth += 1;
        if (choice == 1) {
            choiceTree.Add(1);
        } 
        else if (choice == 2) {
            choiceTree.Add(2);
        }
        else {
            choiceTree.Add(3);
        }
        bool branchFound = false;
        while (branchFound == false) {
            index += 1;
            string currLine = splitScript[index];
            if (currLine.Contains("startBranch")) {
                currLine = currLine.Replace("startBranch", "");
                List<string> fullBranch = new List<string>();
                fullBranch.AddRange(currLine.Split("."[0]));
                int countInt = 0;
                foreach (string c in fullBranch) {
                    countInt += 1;
                }
                if (depth == countInt){
                    bool isCorrect = true;
                    countInt = 0;
                    foreach (string c in fullBranch) {
                        int tempInt = int.Parse(c);
                        if (tempInt != choiceTree[countInt]) {
                            isCorrect = false;
                        }
                        countInt++;
                    }
                    if (isCorrect == true) {
                        branchFound = true;
                    }
                }
            } 
        }
        index += 1;
        dialogueText = ProcessDialogue(splitScript[index]); 
    }
}
