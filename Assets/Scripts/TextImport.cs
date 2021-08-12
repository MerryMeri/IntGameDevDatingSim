using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImport : MonoBehaviour
{
    public TextAsset script;
    string scriptString;
    public List<string> splitScript;
    // Start is called before the first frame update
    void Start()
    {
        scriptString = script.text;
        splitScript = new List<string>();
        splitScript.AddRange(scriptString.Split("\n"[0]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
