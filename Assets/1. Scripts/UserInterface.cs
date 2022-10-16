using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private TextMeshProUGUI _soundText;
    [SerializeField] private TextMeshProUGUI _endText;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private CellCreator _gameZone;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _barier;

    private void Start()
    {
        EventManager.Loose += LoseScreen;
        EventManager.Win += WinScreen;
        _soundText.text = $"ЗВУК: {Mathf.Ceil(_soundManager._soundSlider.value * 100)}%";
    }

    public void OpenOrCloseMenu()
    {
        _menu.SetActive(!_menu.activeSelf);
        _backButton.SetActive(!_backButton.activeSelf);
        _barier.SetActive(!_barier.activeSelf);
        _gameZone.gameObject.SetActive(_gameZone.gameObject.activeSelf);
    }

    public void PrintSliderValue(float value)
    {
        _soundText.text = $"ЗВУК: {Mathf.Ceil(value * 100)}%";
    }

    public void StartGame()
    {
        _gameZone.gameObject.SetActive(true);
        _startButton.SetActive(false);
        EventManager.OnStart();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoseScreen()
    {
        End();
        _endText.text = "Поражение";
    }

    private void WinScreen()
    {
        End();
        _endText.text = "Победа!";
    }

    private void End()
    {
        _endScreen.SetActive(true);
        EventManager.Loose -= LoseScreen;
        EventManager.Win -= WinScreen;
    }
}
