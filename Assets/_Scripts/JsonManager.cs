using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class JsonManager : MonoBehaviour
{
    public static Data data;
    public static JsonManager instance;
    public StudentJson dataAddStudent;
    public StudentJson dataEditStudent;
    private string pathJson;
    public string PathJson => pathJson;

    private void Awake()
    {
        if (instance == null) instance = this;
        pathJson = Application.dataPath + @"\StreamingAssets" + @"\estudiantes.json";
        UpdateJson();
    }

    public void UpdateJson()
    {
        using (StreamReader stream  = new StreamReader(pathJson))
        {
            string json = stream.ReadToEnd();
            data = JsonUtility.FromJson<Data>(json);
        }
    }

    public void AddStudent()
    {
        if (!data.datos.Contains(dataAddStudent))
        {
            data.datos.Add(dataAddStudent);
            WriteJson();
            UpdateJson();
            DestroyStudents();
            DataManager.instance.CreateStudents();
        }
    }

    public void EditStudent(string newEmail, string newNote)
    {
        var index = data.datos.IndexOf(dataEditStudent);
        dataEditStudent.email = newEmail;
        dataEditStudent.finalNote = newNote;
        data.datos[index] = dataEditStudent;
        WriteJson();
        UpdateJson();
        DestroyStudents();
        DataManager.instance.CreateStudents();
        
    }

    public void DeletStudent()
    {
        var index = data.datos.IndexOf(dataEditStudent);
        data.datos.RemoveAt(index);
        WriteJson();
        UpdateJson();
        DestroyStudents();
        DataManager.instance.CreateStudents();
    }

    private void DestroyStudents()
    {
        for (int i = 0; i < DataManager.instance.CurrentStudentsTable.Count; i++)
        {
            Destroy(DataManager.instance.CurrentStudentsTable[i]);
            Destroy(DataManager.instance.CurrentStudentsDrop[i]);
            Destroy(DataManager.instance.CurrentStudentsEdit[i]);
        }

        DataManager.instance.CurrentStudentsDrop = new List<GameObject>();
        DataManager.instance.CurrentStudentsTable = new List<GameObject>();
        DataManager.instance.CurrentStudentsEdit = new List<GameObject>();
    }

    private string GetStringJson()
    {
        string strOutput = JsonUtility.ToJson(data,true);
        return strOutput;
    }

    private void WriteJson()
    {
        File.WriteAllText(pathJson,GetStringJson());
    }
}
