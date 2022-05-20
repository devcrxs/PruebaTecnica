using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private Transform canvasWarningsNotices;
    [SerializeField] private Transform canvasLogin;
    [SerializeField] private InputField inputNameLogin;
    [SerializeField] private Text textNameMainMenu;
    [Header("Add Inputs")] 
    [SerializeField] private InputField nameStudent;
    [SerializeField] private InputField lastNameStudent;
    [SerializeField] private InputField identificationCode;
    [SerializeField] private InputField emailStudent;
    [SerializeField] private InputField noteStudent;
    [Header("Edit Inputs")]
    public InputField nameStudentEdit;
    public InputField lastNameStudentEdit;
    public InputField identificationCodeEdit;
    public InputField emailStudentEdit;
    public InputField noteStudentEdit;
    [Header("Buttons")] 
    public Button buttonDeletStudent;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        GameManager.instance.OnAddStudent += GetDataInputField;
        GameManager.instance.OnEditStudent += EditStudent;
        GameManager.instance.OnDeletStudent += DeletStudent;
        Application.targetFrameRate = 60;
    }

    public void ActiveWarningNotice(string textShow)
    {
        canvasWarningsNotices.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = textShow;
        canvasWarningsNotices.gameObject.SetActive(true);
    }

    private void DeletStudent()
    {
        if (JsonManager.instance.dataEditStudent.name == null) return;
        JsonManager.instance.DeletStudent();
    }

    private void EditStudent()
    {
        if (emailStudentEdit.text.Length <= 0 && noteStudentEdit.text.Length <= 0) return;
        JsonManager.instance.EditStudent(emailStudentEdit.text,noteStudentEdit.text);
    }

    private void GetDataInputField()
    {
        if (!IsCompletForm()) return;
        JsonManager.instance.dataAddStudent.name = nameStudent.text;
        JsonManager.instance.dataAddStudent.lastName = lastNameStudent.text;
        JsonManager.instance.dataAddStudent.identificationCode = identificationCode.text;
        JsonManager.instance.dataAddStudent.email = emailStudent.text;
        JsonManager.instance.dataAddStudent.finalNote = noteStudent.text;
        JsonManager.instance.AddStudent();
    }

    private bool IsCompletForm()
    {
        return nameStudent.text.Length > 0 && lastNameStudent.text.Length > 0 
                                           && identificationCode.text.Length > 0 && emailStudent.text.Length > 0 
                                           && noteStudent.text.Length > 0;
    }

    public void Login()
    {
        if (inputNameLogin.text.Length <= 0) return;
        textNameMainMenu.text = inputNameLogin.text;
        canvasLogin.gameObject.SetActive(false);
    }
}
