using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseDay6 : MonoBehaviour
{
    public Button JD;
    public Button Berry;
    public Button Oldie;
    public int JD_Berry_scene;
    public int JD_Oldie_scene;
    public int Berry_JD_scene;
    public int Berry_Oldie_scene;
    public int Oldie_JD_scene;
    public int Oldie_Berry_scene;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("JDAffection"));
        Debug.Log(PlayerPrefs.GetInt("BerryAffection"));
        Debug.Log(PlayerPrefs.GetInt("OldieAffection"));
        JD.onClick.AddListener(delegate {TaskOnClickJD();} );
        Berry.onClick.AddListener(delegate {TaskOnClickBerry();} );
        Oldie.onClick.AddListener(delegate {TaskOnClickOldie();} );
    }

    void TaskOnClickJD() {
        int berryPoints = PlayerPrefs.GetInt("BerryAffection");
        int oldiePoints = PlayerPrefs.GetInt("OldieAffection");
        if (berryPoints > oldiePoints) {
            SceneManager.LoadScene(JD_Berry_scene);
        }
        else if (oldiePoints > berryPoints) {
            SceneManager.LoadScene(JD_Oldie_scene);
        }
        else {
            int randomInt = Random.Range(1,3);
            if (randomInt == 1) {
                SceneManager.LoadScene(JD_Berry_scene);
            }
            else {
                SceneManager.LoadScene(JD_Oldie_scene);
            }
        }
    }

    void TaskOnClickBerry() {
        int JDPoints = PlayerPrefs.GetInt("JDAffection");
        int oldiePoints = PlayerPrefs.GetInt("OldieAffection");
        if (JDPoints > oldiePoints) {
            SceneManager.LoadScene(Berry_JD_scene);
        }
        else if (oldiePoints > JDPoints) {
            SceneManager.LoadScene(Berry_Oldie_scene);
        }
        else {
            int randomInt = Random.Range(1,3);
            if (randomInt == 1) {
                SceneManager.LoadScene(Berry_JD_scene);
            }
            else {
                SceneManager.LoadScene(Berry_Oldie_scene);
            }
        }
    }

    void TaskOnClickOldie() {
        int JDPoints = PlayerPrefs.GetInt("JDAffection");
        int berryPoints = PlayerPrefs.GetInt("BerryAffection");
        if (JDPoints > berryPoints) {
            SceneManager.LoadScene(Oldie_JD_scene);
        }
        else if (berryPoints > JDPoints) {
            SceneManager.LoadScene(Oldie_Berry_scene);
        }
        else {
            int randomInt = Random.Range(1,3);
            if (randomInt == 1) {
                SceneManager.LoadScene(Oldie_JD_scene);
            }
            else {
                SceneManager.LoadScene(Oldie_Berry_scene);
            }
        }
    }
}
