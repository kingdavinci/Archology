using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveMyPosition : MonoBehaviour
{
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
        data = new SaveData(transform.position);
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
            transform.position = data.GetVector3();
        }
    }
}
[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;

    public SaveData(Vector3 postion)
    {
        x = postion.x;
        y = postion.y;
        z = postion.z;
    }
    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }
}
