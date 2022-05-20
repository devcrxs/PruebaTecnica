using System.Collections.Generic;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject studentDataPrefab;
    [SerializeField] private GameObject studentDataDragDropPrefab;
    [SerializeField] private GameObject studentDataEditPrefab;
    [SerializeField] private List<GameObject> currentStudentsTable;
    [SerializeField] private List<GameObject> currentStudentsDrop;
    [SerializeField] private List<GameObject> currentStudentsEdit;
    [SerializeField] private Transform containerStudents;
    [SerializeField] private Transform containerStudentsDragDrop;
    [SerializeField] private Transform containerStudentsEdit;
    public static DataManager instance;

    public List<GameObject> CurrentStudentsTable
    {
        get => currentStudentsTable;
        set => currentStudentsTable = value;
    }
    public List<GameObject> CurrentStudentsDrop
    {
        get => currentStudentsDrop;
        set => currentStudentsDrop = value;
    }
    
    public List<GameObject> CurrentStudentsEdit
    {
        get => currentStudentsEdit;
        set => currentStudentsEdit = value;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        CreateStudents();
    }

    public void CreateStudents()
    {
        int countStudents = JsonManager.data.datos.Count;
        for (int i = 0; i < countStudents; i++)
        {
            GameObject student;
            GameObject studentDrop;
            GameObject studentEdit;
            student = Instantiate(studentDataPrefab, containerStudents);
            studentDrop = Instantiate(studentDataDragDropPrefab, containerStudentsDragDrop);
            studentEdit = Instantiate(studentDataEditPrefab, containerStudentsEdit);
            currentStudentsTable.Add(student);
            currentStudentsDrop.Add(studentDrop);
            currentStudentsEdit.Add(studentEdit);
            SetDataStudentUI(student,i);
            SetDataStudentDragDrop(studentDrop,i);
            SetDataStudentDragDrop(studentEdit,i);
        }
    }

    private void SetDataStudentUI(GameObject student, int index)
    {
        StudentsData studentData = student.GetComponent<StudentsData>();
        studentData.studentJson = JsonManager.data.datos[index];
        studentData.name.text = JsonManager.data.datos[index].name;
        studentData.lastName.text = JsonManager.data.datos[index].lastName;
        studentData.identificationCode.text = JsonManager.data.datos[index].identificationCode;
        studentData.email.text = JsonManager.data.datos[index].email;
        studentData.finalNote.text = JsonManager.data.datos[index].finalNote;
    }

    private void SetDataStudentDragDrop(GameObject student, int index)
    {
        Students studentsData = student.GetComponent<Students>();
        studentsData.studentJson = JsonManager.data.datos[index];
        studentsData.name.text = JsonManager.data.datos[index].name;
        studentsData.finalNote.text = JsonManager.data.datos[index].finalNote;
    }
    
}
