using UnityEngine;
using UnityEngine.SceneManagement;

public class restartApp : MonoBehaviour {
    public void RestartApp() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}