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
}

[Serializable]
public class Room
{
    public string Description;
    public Action[] Actions;

    public Texture BG;
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

    /*
     Структура описания комнаты

    комната = [
        'Описание комнаты',
        ['Действие1', индекс_комнаты],
        ['Действие2', индекс_комнаты],
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
    }

    private void EndGame()
    {
        _roomDesc.text = "На данный момент сюжет завершен. Ждите новых глав!";

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }
        _actionButtons[0].gameObject.SetActive(true);
        _actionTexts[0].text = "Начать заново";

        _actionButtons[0].onClick.RemoveAllListeners();
        _actionButtons[0].onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    private void OnActionButton(byte index)
    {
        _currentIndex = _roomInfo[_currentIndex].Actions[index].Index;

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
