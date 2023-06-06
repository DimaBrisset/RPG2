using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _playButton;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _loadSceneName;

    #endregion


    #region LifeCycle

    private void Start()
    {
        _playButton.onClick.AddListener(PlayButtonClicked);
    }

    #endregion


    #region Private Methods

    private void PlayButtonClicked()
    {
        _sceneLoader.LoadScene(_loadSceneName);
    }

    #endregion
}