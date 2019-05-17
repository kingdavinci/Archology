using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveMyPosition : MonoBehaviour
{
    public string map;
    string savePath;
    SaveData data;

    void Start()
    {
        savePath = Application.persistentDataPath + "/" + gameObject.name + "mysave.dat";
        Debug.Log(savePath);
    }

    void Update()
    {
      
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        //if file does not exist create it
        if(!File.Exists(savePath))
        {
            file = File.Create(savePath);
        }
        //if file does exist open it
        else
        {
            file = File.Open(savePath, FileMode.Open);
        }
        data = new SaveData(transform.position, SceneManager.GetActiveScene().name);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log(savePath);
    }
    public void Load()
    {
        if(File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            data = (SaveData)bf.Deserialize(file);
            file.Close();
            SceneManager.LoadScene(data.scene);
            transform.position = data.GetVector3();
            PlayerPrefs.SetInt("ShouldLoadPosition", 1);
            PlayerPrefs.SetFloat("x", data.x);
            PlayerPrefs.SetFloat("y", data.y);
            PlayerPrefs.SetFloat("z", data.z);

        }
    }
}

[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;
    public string scene;


    public SaveData(Vector3 postion, string scene)
    {
        x = postion.x;
        y = postion.y;
        z = postion.z;
        this.scene = scene;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }
}
