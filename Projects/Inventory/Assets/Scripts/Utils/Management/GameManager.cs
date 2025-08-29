using Backend.Object;

namespace Backend.Utils.Management
{
    public class GameManager : Singleton<GameManager>
    {
        private void OnEnable()
        {
            UIManager.Instance.MainMenuPresenter.IDText = Character.ID;
            UIManager.Instance.MainMenuPresenter.LevelText = $"{Character.Level}";
            UIManager.Instance.MainMenuPresenter.GoldText = $"{Character.Gold}";
        }

        public Character Character { get; private set; } = new Character();
    }
}


