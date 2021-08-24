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
    public bool worthPoints;
    // Start is called before the first frame update
    void Start()
    {
        JD.onClick.AddListener(delegate {TaskOnClick(JD_scene);} );
        Berry.onClick.AddListener(delegate {TaskOnClick(Berry_scene);} );
        Oldie.onClick.AddListener(delegate {TaskOnClick(Oldie_scene);} );
    }

    void TaskOnClick(int sceneNumber) {
        if (sceneNumber == JD_scene && worthPoints) {
            PlayerPrefs.SetInt("JDAffection", PlayerPrefs.GetInt("JDAffection") + 2);
        }
        else if (sceneNumber == Berry_scene && worthPoints) {
            PlayerPrefs.SetInt("BerryAffection", PlayerPrefs.GetInt("BerryAffection") + 2);
        }
        else if (sceneNumber == Oldie_scene && worthPoints) {
            PlayerPrefs.SetInt("OldieAffection", PlayerPrefs.GetInt("OldieAffection") + 2);
        }
        SceneManager.LoadScene(sceneNumber);
    }
}
