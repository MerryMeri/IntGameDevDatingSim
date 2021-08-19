using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour
{
    public TMP_Text displayName;
    public TMP_Text text;
    public Sprite boxWithName;
    public Sprite monologueBox;
    public TMP_FontAsset nonItalics;
    public TMP_FontAsset withItalics;
    AudioSource sound;
    private string currentText;
    float timeBetweenChars = 0.02f;
    Image textbox;
    Color color1 = Color.white;
    Color color2 = Color.white;
    int alphaIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        color2.a = 0f;
        text.color = color2;
        textbox = gameObject.GetComponent<Image>();
        sound = GetComponent<AudioSource>();
    }
    public void Show(string newText, string newName){
        currentText = newText;
        text.color = color1;
        if (newName == "None"){
            displayName.text = "";
            textbox.sprite = monologueBox;
            text.font = withItalics;
        }
        else {
            displayName.text = newName;
            textbox.sprite = boxWithName;
            text.font = nonItalics;
        }
        sound.Play();
        StartCoroutine(displayText());
    }
    public void Close(){
        text.color = color2;
        StopAllCoroutines();
    }
    public bool isAtEnd(){
        sound.Stop();
        int length = currentText.Length;
        if (alphaIndex == length) {
            return true;
        }
        return false;
    }
    public void SpeedUp(){
        alphaIndex = currentText.Length;
    }
    private IEnumerator displayText() {
        text.text = "";

        string originalText = currentText;
        string displayedText = "";
        alphaIndex = 0;

        foreach (char c in currentText.ToCharArray()) {
            if (alphaIndex < currentText.Length) {
                alphaIndex++;
            }
            text.text = originalText;
            displayedText = text.text.Insert(alphaIndex, "<color=#00000000>");
            text.text = displayedText;

            yield return new WaitForSecondsRealtime(timeBetweenChars);
        }
        sound.Stop();
    }
}
