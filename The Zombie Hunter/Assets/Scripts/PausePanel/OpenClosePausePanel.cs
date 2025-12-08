using UnityEngine;

public class OpenClosePausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private InputData inputData;

    private void Start()
    {
        inputData = GetComponent<InputData>();
    }

    private void Update()
    {
        _pausePanel.SetActive(inputData.isPause);
    }
}
