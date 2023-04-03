using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string _playerName;
    public int _score;

    public string _bestPlayerName;
    public int _bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string _bestPlayerName = "Name";
        public int _bestScore = 0;
    }

    public void SaveBestResult()
    {
        if (_score > _bestScore)
        {
            SaveData data = new SaveData();
            data._bestPlayerName = _playerName;
            data._bestScore = _score;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadBestResult()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _bestPlayerName = data._bestPlayerName;
            _bestScore = data._bestScore;
        }
    }
}
