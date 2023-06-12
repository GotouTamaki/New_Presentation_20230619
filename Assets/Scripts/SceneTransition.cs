using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Image[] _images = new Image[2];
    [SerializeField] Color _selectColor = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  GameOver(string stage)
    {
        SceneManager.LoadScene(stage);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleScene()
    {
        //Debug.Log("TitleScene");
        SceneManager.LoadScene("TitleScene");
    }

    public void StageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void StageTutorial()
    {
        SceneManager.LoadScene("Stage_Tutorial");
    }
}
