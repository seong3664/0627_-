using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 관련 기능을 사용하겠다. 생략을 명시한다.

public class UImanager : MonoBehaviour   //MoboBehavior <- 선언하지 않으면 컴퍼넌트를 쓸 수가 없다.
                                         //유니티의 기능을 쓸 수 있게함.없애면 C#클래스와 같다.
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScenes");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR     //전처리기(컴파일전 미리 기능이 정해져 있다.) 매크로
     UnityEditor.EditorApplication.isPlaying = false;   //유니티에서 편집중인 상태에서 종료
#else  //필드에서 종료
     Application.Quit();
#endif
    }
}
