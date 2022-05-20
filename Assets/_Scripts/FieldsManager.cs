using System;
using UnityEngine;
public class FieldsManager : StatusStudent
{
    public Transform canvasDrop;
    private void Start()
    {
        GameManager.instance.OnCheckNotes += CheckFields;
        InitializeDictionary();
    }

    private void CheckFields()
    {
        ComprobateNotesStudents();
        canvasDrop.gameObject.SetActive(IsActiveDragDropCanvas());
    }

    private void ComprobateNotesStudents()
    {
        for (int i = 0; i < DataManager.instance.CurrentStudentsTable.Count; i++)
        {
            StudentsData student = DataManager.instance.CurrentStudentsTable[i].GetComponent<StudentsData>();
            double note = Double.Parse(student.studentJson.finalNote);
            DefineStudentStatus(student.approvedType,note, student);
        }
    }

    private bool IsActiveDragDropCanvas()
    {
        for (int i = 0; i < DataManager.instance.CurrentStudentsTable.Count; i++)
        {
            StudentsData student = DataManager.instance.CurrentStudentsTable[i].GetComponent<StudentsData>();
            if (student.warningType != WarningType.AllRight)
            {
                UIManager.instance.ActiveWarningNotice(notices[student.approvedType].warningMessage);
                return false;
            }
        }
        return true;
    }
  
}
