using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    // Start is called before the first frame update

    public string dialogueText;
    public TextBehavior dialogue;
    bool isActivated;
    void Start()
    {
        isActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (isActivated == false) {
                isActivated = !isActivated;
                dialogue.Show(dialogueText);
            }
            else {
                if (dialogue.isAtEnd() == true){
                    isActivated = !isActivated;
                    dialogue.Close();
                }
                else {
                    dialogue.SpeedUp();
                }
            }
        }
    }
}
