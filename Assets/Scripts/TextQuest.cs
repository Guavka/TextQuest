using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Action
{
    public string Description;
    public byte Index;
    public AudioClip ClickClip;
}

[Serializable]
public class Room
{
    public string Description;
    public Action[] Actions;

    public Texture BG;
    public AudioClip Clip;
}

public class TextQuest : MonoBehaviour
{
    /*
    Bad code!
    
    public TMP_Text RoomDesc;
    public Button[] ActionButtons;
    */

    [SerializeField]
    private TMP_Text _roomDesc;

    [SerializeField]
    private Button[] _actionButtons;

    [SerializeField]
    private TMP_Text[] _actionTexts;

    [SerializeField]
    private RawImage _background;

    [SerializeField]
    private AudioSource _bgAudio;

    [SerializeField]
    private AudioSource _clickAudio;

    /*
     ��������� �������� �������

    ������� = [
        '�������� �������',
        ['��������1', ������_�������],
        ['��������2', ������_�������],
    ]
     */

    [SerializeField]
    private Room[] _roomInfo;

    [SerializeField]
    private byte _currentIndex = 0;


    private void SetRoomInfo()
    {
        var currentRoom = _roomInfo[_currentIndex];
        var currentRoomActions = currentRoom.Actions;

        _roomDesc.text = currentRoom.Description;
        _background.texture = currentRoom.BG;

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }

        for (var i = 0; i < currentRoomActions.Length; i++)
        {
            _actionTexts[i].text = currentRoomActions[i].Description;
            _actionButtons[i].gameObject.SetActive(true);
        }

        _bgAudio.clip = currentRoom.Clip;
        _bgAudio.Play();
    }

    private void EndGame()
    {
        _roomDesc.text = "�� ������ ������ ����� ��������. ����� ����� ����!";

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }
        _actionButtons[0].gameObject.SetActive(true);
        _actionTexts[0].text = "������ ������";

        _actionButtons[0].onClick.RemoveAllListeners();
        _actionButtons[0].onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    private void OnActionButton(byte index)
    {
        var currentAction = _roomInfo[_currentIndex].Actions[index];

        _currentIndex = currentAction.Index;
        _clickAudio.PlayOneShot(currentAction.ClickClip);

        if (_currentIndex >= _roomInfo.Length)
            EndGame();
        else
            SetRoomInfo();
    }

    private void Start()
    {
        SetRoomInfo();

        for (byte i = 0; i < _actionButtons.Length; i++)
        {
            var index = i;
            _actionButtons[i].onClick.AddListener(() => OnActionButton(index));
        }
    }
}
