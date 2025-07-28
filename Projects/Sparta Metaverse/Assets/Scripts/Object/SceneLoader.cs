using UnityEngine;
using UnityEngine.SceneManagement;

namespace Backend.Object
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}