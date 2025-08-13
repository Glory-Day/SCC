using UnityEngine;

namespace Backend.Object.Character
{
    public class PlayerCharacterManager : MonoBehaviour
    {
        private static PlayerCharacterManager _instance;

        private void Awake()
        {
            if (_instance is null)
            {
                _instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        public PlayerCharacter Component { get; set; }

        #region STATIC PROPERTIES API

        public static PlayerCharacterManager Instance
        {
            get
            {
                return _instance ??= new GameObject("Player Character Manager").AddComponent<PlayerCharacterManager>();
            }
        }

        #endregion
    }
}
