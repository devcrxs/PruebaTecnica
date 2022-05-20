public enum ApprovedType
{
    Undefined,
    Approved,
    Reprobate
}

public enum WarningType
{
    AllRight,
    EmptyFields,
    ShouldNotApprove,
    ShouldApprove
}
public abstract class ApprovedManager
{
    public double minimumNote = 3.0;
    public string warningMessage;
    public abstract ApprovedType ApprovedType { get; }
    public abstract void CheckFinalNote(double note, Students student);
    public bool IsAboveAverage(double note) => note >= minimumNote;
}

public class Undefined : ApprovedManager
{
    public override ApprovedType ApprovedType => ApprovedType.Undefined;

    public override void CheckFinalNote(double note,Students student)
    {
        student.warningType = WarningType.EmptyFields;
        warningMessage = "Por favor rellene todos los campos antes de continuar";
    }
}
public class Approved : ApprovedManager
{
    public override ApprovedType ApprovedType => ApprovedType.Approved;

    public override void CheckFinalNote(double note,Students student)
    {
        if (IsAboveAverage(note))
        {
            student.warningType = WarningType.AllRight;
            return;
        }
        student.warningType = WarningType.ShouldNotApprove;
        warningMessage = "algunos estudiantes están siendo aprobados con notas menores al promedio";
    }
}

public class Reprobate : ApprovedManager
{
    public override ApprovedType ApprovedType => ApprovedType.Reprobate;

    public override void CheckFinalNote(double note,Students student)
    {
        if (IsAboveAverage(note))
        {
            student.warningType = WarningType.ShouldApprove;
            warningMessage = "Algunos estudiantes están siendo reprobados con notas mayores o iguales al promedio";
            return;
        }
        student.warningType = WarningType.AllRight;
    }
}
