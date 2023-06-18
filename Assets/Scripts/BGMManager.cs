using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    [SerializeField]
    AudioClip _BGM_Title;
    [SerializeField]
    AudioClip _BGM_Tutorial;
    [SerializeField]
    AudioClip _BGM_Stage;

    private AudioSource source;
    private string beforeScene = "StageSelectScene";
    static private BGMManager _instance = null;

        // Start is called before the first frame update
        void Start()
    {
        //BGMが既にあるかを判定する
        if (_instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        _instance = this;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //最初のBGM再生
        source.clip = _BGM_Title;
        source.Play();
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        //ステージ選択からチュートリアルへ
        if (beforeScene == "StageSelectScene" && nextScene.name == "Stage_Tutorial")
        {
            source.Stop();
            source.clip = _BGM_Tutorial; //流すクリップを切り替える
            source.Play();
        }

        //ステージ選択からステージへ
        if (beforeScene == "StageSelectScene" && (nextScene.name == "Stage_1" || nextScene.name == "Stage_2"))
        {
            source.Stop();
            source.clip = _BGM_Stage;    //流すクリップを切り替える
            source.Play();
        }

        //ステージからタイトル、ステージ選択へ
        if ((beforeScene == "Stage_Tutorial" || beforeScene == "Stage_1" || beforeScene == "Stage_2") && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            source.Stop();
            source.clip = _BGM_Title;    //流すクリップを切り替える
            source.Play();
        }

        //ステージからクリア画面へ
        if ((beforeScene == "Stage_Tutorial" || beforeScene == "Stage_1" || beforeScene == "Stage_2") && nextScene.name == "ClearScene")
        {
            source.Stop();
        }

        //クリア画面からタイトル、ステージ選択へ
        if (beforeScene == "ClearScene" && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            source.clip = _BGM_Title; //流すクリップを切り替える
            source.Play();
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
}
