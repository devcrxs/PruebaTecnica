using System.Collections.Generic;

[System.Serializable]
public struct StudentJson
{
    public string name;
    public string lastName;
    public string identificationCode;
    public string email;
    public string finalNote;
}
[System.Serializable]
public class Data
{
    public List<StudentJson> datos;
}

