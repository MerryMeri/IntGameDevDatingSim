using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseScenario : MonoBehaviour
{
    public Button JD;
    public Button Berry;
    public Button Oldie;
    public int JD_scene;
    public int Berry_scene;
    public int Oldie_scene;
    // Start is called before the first frame update
    void Start()
    {
        JD.onClick.AddListener(delegate {TaskOnClick(JD_scene);} );
        Berry.onClick.AddListener(delegate {TaskOnClick(Berry_scene);} );
        Oldie.onClick.AddListener(delegate {TaskOnClick(Oldie_scene);} );
        Debug.Log("test");
    }

    void TaskOnClick(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }
}
