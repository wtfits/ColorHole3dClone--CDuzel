using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    #region Singleton class: UIManager

    public static UIManager Instance;

    void Awake() {
        
        if(Instance == null) {
            Instance = this;
        }
    }

    #endregion

    [Header ("Level Progress UI")]

    int sceneOffset = 1;
    [SerializeField] TMP_Text nextLevelText;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] Image progressFillImage;
    [Space]

    float progress1;
    float progress2;

    void Start()
    {
        progressFillImage.fillAmount = 0f;
        SetLevelProgressText();
    }

    void SetLevelProgressText (){
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        currentLevelText.text = level.ToString();
        nextLevelText.text = (level + 1).ToString();
    }

    public void UpdateLevelProgress () {

        progress1 = ((float)(Level.Instance.objectsInScene1) / (Level.Instance.totalObjects1));
        progress2 = ((float)(Level.Instance.objectsInScene2) / (Level.Instance.totalObjects2));

        float val = 1f - (progress1 /2 + progress2 /2);
        progressFillImage.fillAmount = val;


    }


}
