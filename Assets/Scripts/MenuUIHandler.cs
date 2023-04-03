using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField _playerNameInputField;
    [SerializeField] private TextMeshProUGUI _bestPlayerText;

    private void Start()
    {
        DataManager.Instance.LoadBestResult();
        _bestPlayerText.text = $"Best Score: {DataManager.Instance._bestPlayerName}: {DataManager.Instance._bestScore}";
    }

    public void StartGame()
    {
        DataManager.Instance._playerName = _playerNameInputField.text;
        SceneManager.LoadScene(1);
    }
}
