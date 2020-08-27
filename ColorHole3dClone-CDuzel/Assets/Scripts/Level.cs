using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class Level : MonoBehaviour
{

    #region Singleton class: Level

    public static Level Instance;

    void Awake() {

        if (Instance == null) {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] ParticleSystem winFx;


    [Space]
    public int objectsInScene1;
    public int objectsInScene2;
    public int totalObjects1;
    public int totalObjects2;

    [SerializeField] Transform objectsParent1;
    [SerializeField] Transform objectsParent2;

    [Space]
    [SerializeField] Material groundMaterial;
    [SerializeField] Material edgeMaterial;
    [SerializeField] Material BGMaterial;

    [Space]
    [Header("Level Color")]
    [Header("Ground")]

    [SerializeField] Color groundColor;
    [SerializeField] Color edgeColor;
    [SerializeField] Color BGColor;

    void Start() {

        CountObjects();
        UpdateLevelColors();
    }

    void CountObjects() {

        //Seperate objects for 2 stages
        totalObjects1 = objectsParent1.childCount;
        objectsInScene1 = totalObjects1;

        totalObjects2 = objectsParent2.childCount;
        objectsInScene2 = totalObjects2;
    }

    public void PlayWinFx() {
        winFx.Play();
    }
    public void LoadNextLevel() {

        if(SceneManager.GetActiveScene().buildIndex == 2) {

            AppHelper.Quit();

        } else {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Game.isGameover = false;


    }


    void UpdateLevelColors() {

        groundMaterial.color = groundColor;
        edgeMaterial.color = edgeColor;
        BGMaterial.color = BGColor;


        void OnValidate() {

            UpdateLevelColors();
        }

    }



    
#if UNITY_EDITOR
    public static class AppHelper
    {

        public static void Quit() {
            EditorApplication.isPlaying = false;

        }
    }
#else
public static class AppHelper
{

    public static void Quit() {
        Application.Quit();

    }
}
#endif
    

}


