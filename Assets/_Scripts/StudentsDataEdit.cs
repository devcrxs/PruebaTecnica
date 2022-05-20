using UnityEngine.EventSystems;
public class StudentsDataEdit : Students,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        JsonManager.instance.dataEditStudent = studentJson;
        UIManager.instance.buttonDeletStudent.interactable = true;
        UIManager.instance.nameStudentEdit.text = studentJson.name;
        UIManager.instance.lastNameStudentEdit.text = studentJson.lastName;
        UIManager.instance.identificationCodeEdit.text = studentJson.identificationCode;
        UIManager.instance.emailStudentEdit.text = studentJson.email;
        UIManager.instance.noteStudentEdit.text = studentJson.finalNote;
    }
}
