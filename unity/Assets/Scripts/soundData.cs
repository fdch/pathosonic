using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // to load Json File

public class soundData : MonoBehaviour
{
    public string jsonFileName;
    public SoundInfo soundDataObject;

    private void Start()
    {
        soundDataObject = SoundInfo.CreateFromJSON(LoadJSONData(jsonFileName));
        print(soundDataObject.instances[0]);
    }


    [System.Serializable]
    public class SoundInfo
    {
       public ArrayList instances;
       // public int lives;
       // public float health;

        public static SoundInfo CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<SoundInfo>(jsonString);
        }

        // Given JSON input:
        // {"name":"Dr Charles","lives":3,"health":0.8}
        // this example will return a PlayerInfo object with
        // name == "Dr Charles", lives == 3, and health == 0.8f.
    }

    private string LoadJSONData(string jsonFile)
    {
        // Path.Combine combines strings into a file path
        // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFile);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            return File.ReadAllText(filePath);
        }
        else
        {
            return "-1";
            Debug.LogError("Cannot load BIRD data!");
        }
    }


}
