using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    // Start is called before the first frame update
    public void LoadScene() {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    public void ExitApplication() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
