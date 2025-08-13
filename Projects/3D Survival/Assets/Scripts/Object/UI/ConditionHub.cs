using UnityEngine;
using Backend.Object.Character;

namespace Backend.Object.UI
{
    public class ConditionHub : MonoBehaviour
    {
        [Header("Component Settings")]
        [SerializeField] private ConditionViewer health;

        private void Start()
        {
            PlayerCharacterManager.Instance.Component.Condition.Hub = this;
        }

        public ConditionViewer Health => health;

        public float Speed
        {
            get => PlayerCharacterManager.Instance.Component.Controller.speed;
            set => PlayerCharacterManager.Instance.Component.Controller.speed = value;
        }
    }
}
