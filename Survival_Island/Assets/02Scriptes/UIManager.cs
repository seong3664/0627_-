using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�� ���� ����� ����ϰڴ�. ������ ����Ѵ�.

public class UImanager : MonoBehaviour   //MoboBehavior <- �������� ������ ���۳�Ʈ�� �� ���� ����.
                                         //����Ƽ�� ����� �� �� �ְ���.���ָ� C#Ŭ������ ����.
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScenes");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR     //��ó����(�������� �̸� ����� ������ �ִ�.) ��ũ��
     UnityEditor.EditorApplication.isPlaying = false;   //����Ƽ���� �������� ���¿��� ����
#else  //�ʵ忡�� ����
     Application.Quit();
#endif
    }
}
