using UnityEngine.UI;
public class StudentsData : Students
{
    public Text lastName;
    public Text identificationCode;
    public Text email;
    public void SetApproved()
    {
        approvedType = ApprovedType.Approved;
    }

    public void SetReprobate()
    {
        approvedType = ApprovedType.Reprobate;
    }
}
