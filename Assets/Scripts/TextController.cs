using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update

    string dialogueText;
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
        dialogueText = splitScript[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated == false) {
                isActivated = !isActivated;
                dialogue.Show(dialogueText);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")){
            if (dialogue.isAtEnd() == true){
                isActivated = !isActivated;
                dialogue.Close();
                if (index != splitScript.Count - 1) {
                    index += 1;
                    dialogueText = splitScript[index];
                }
                else {
                    dialogueText = "The End.";
                }
            }
            else {
                dialogue.SpeedUp();
            }
        }
    }
}
