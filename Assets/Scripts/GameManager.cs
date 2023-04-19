using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;

    private GameObject _level;
    private void Start()
    {
        CreateLevel();
    }

    public void CreateLevel()
    {
        _level = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
    }
}
