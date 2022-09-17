using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PhoneNumber
{
    [SerializeField]
    private string _name = "���������";
    [SerializeField]
    private string _number = "00012134566";

    public string Name {
        get => _name;
        set
        {
            if (value.Length == 0)
                throw new Exception("���� '���' ������!");

            _name = value;
        }
    }
    public string Number
    {
        get => _number;
        set
        {
            if (value.Length == 0)
                throw new Exception("���� '�����' ������!");
            if (value.Length != 10 )
                throw new Exception("���� '�����' ������������!");

            _number = value;
        }
    }

    public PhoneNumber(string name, string number) {
        Name = name;
        Number = number;
    }
}

public class UserData : MonoBehaviour
{
    [SerializeField]
    private string _name = "Guavka";
    [SerializeField]
    private int _age = 28;

    [SerializeField]
    private List<PhoneNumber> _phoneNumbers;

    /*
     phone_numbers = [
        ['home',123465413],
        ['home2',123465413],
    ]
     */

    public string Name
    {
        get => _name;
        set
        {
            if (value.Length == 0)
            {
                Debug.Log("���� '���' ������!");
                return;
            }

            _name = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value <= 0)
            {
                Debug.Log("���� '�������' ������ ���� ������ 0!");
                return;
            }

            _age = value;
        }
    }

    public void PrintUser() => Debug.Log($"Name: {_name}\nAge: {_age}");


    private void Start()
    {
        for (var i = 0; i < _phoneNumbers.Count; i++)
        {
            try
            {
                _phoneNumbers[i].Name = _phoneNumbers[i].Name;
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                _phoneNumbers[i].Name = "Default";
            }
            try
            {
                _phoneNumbers[i].Number = _phoneNumbers[i].Number;
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                _phoneNumbers[i].Number = "000000000";
            }
        }
    }
}
