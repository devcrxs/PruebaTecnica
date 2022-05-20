using System;
using UnityEngine;
public enum ZoneDrop
{
    ApprovedZone,
    ReprobateZone
}
public class ZonesDropManager : StatusStudent
{
    private double minimunNote = 3.0;
    [SerializeField] private Transform zoneApproved;
    [SerializeField] private Transform zoneReprobate;
    [SerializeField] private Transform contentStudents;

    private void Start()
    {
        GameManager.instance.OnCheckZoneDrop += CheckZones;
        InitializeDictionary();
    }
    private void CheckZones()
    {
        if (IsStudentsWellPlaced(zoneApproved,ZoneDrop.ApprovedZone) && IsStudentsWellPlaced(zoneReprobate,ZoneDrop.ReprobateZone))
        {
            UIManager.instance.ActiveWarningNotice("¡Felicidades clasificaste a todos tus alumnos!");
            return;
        }
        UIManager.instance.ActiveWarningNotice("Verifica otra vez tu proceso, ya que hay algo que estas haciendo mal");
    }

    private bool IsStudentsWellPlaced(Transform zone, ZoneDrop zoneDrop)
    {
        int childCount = zone.childCount;
        if (contentStudents.childCount > 0) return false;
        for (int i = 0; i < childCount; i++)
        {
            if (zone.GetChild(i).TryGetComponent(out Students student))
            {
                double note = Double.Parse(student.studentJson.finalNote);
                DefineStudentStatus(student.approvedType,note,student);
                switch (zoneDrop)
                {
                    case ZoneDrop.ApprovedZone:
                        if (note < minimunNote) return false;
                        break;
                    case ZoneDrop.ReprobateZone:
                        if (note >= minimunNote) return false;
                        break;
                }
            }
        }
        return true;
    }
}
