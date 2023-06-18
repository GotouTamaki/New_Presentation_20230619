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
        //BGM�����ɂ��邩�𔻒肷��
        if (_instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        _instance = this;
        source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        //�ŏ���BGM�Đ�
        source.clip = _BGM_Title;
        source.Play();
        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���

        //�X�e�[�W�I������`���[�g���A����
        if (beforeScene == "StageSelectScene" && nextScene.name == "Stage_Tutorial")
        {
            source.Stop();
            source.clip = _BGM_Tutorial; //�����N���b�v��؂�ւ���
            source.Play();
        }

        //�X�e�[�W�I������X�e�[�W��
        if (beforeScene == "StageSelectScene" && (nextScene.name == "Stage_1" || nextScene.name == "Stage_2"))
        {
            source.Stop();
            source.clip = _BGM_Stage;    //�����N���b�v��؂�ւ���
            source.Play();
        }

        //�X�e�[�W����^�C�g���A�X�e�[�W�I����
        if ((beforeScene == "Stage_Tutorial" || beforeScene == "Stage_1" || beforeScene == "Stage_2") && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            source.Stop();
            source.clip = _BGM_Title;    //�����N���b�v��؂�ւ���
            source.Play();
        }

        //�X�e�[�W����N���A��ʂ�
        if ((beforeScene == "Stage_Tutorial" || beforeScene == "Stage_1" || beforeScene == "Stage_2") && nextScene.name == "ClearScene")
        {
            source.Stop();
        }

        //�N���A��ʂ���^�C�g���A�X�e�[�W�I����
        if (beforeScene == "ClearScene" && (nextScene.name == "TitleScene" || nextScene.name == "StageSelectScene"))
        {
            source.clip = _BGM_Title; //�����N���b�v��؂�ւ���
            source.Play();
        }

        //�J�ڌ�̃V�[�������u�P�O�̃V�[�����v�Ƃ��ĕێ�
        beforeScene = nextScene.name;
    }
}
