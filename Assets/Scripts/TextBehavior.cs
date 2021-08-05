using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBehavior : MonoBehaviour
{
    public TMP_Text text;
    private string currentText;
    float timeBetweenChars = 0.02f;
    Color color1 = Color.white;
    Color color2 = Color.white;
    int alphaIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        color2.a = 0f;
        text.color = color2;
    }
    public void Show(string newText){
        currentText = newText;
        text.color = color1;
        StartCoroutine(displayText());
    }
    public void Close(){
        text.color = color2;
        StopAllCoroutines();
    }
    public bool isAtEnd(){
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
    }
}
