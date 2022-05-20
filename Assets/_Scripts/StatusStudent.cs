using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
public class StatusStudent : MonoBehaviour
{
    protected Dictionary<ApprovedType, ApprovedManager> notices = new Dictionary<ApprovedType, ApprovedManager>();
    
    protected void InitializeDictionary()
    {
        notices.Clear();
        var allApprovedType = Assembly.GetAssembly(typeof(ApprovedManager)).GetTypes()
            .Where(t => typeof(ApprovedManager).IsAssignableFrom(t) && t.IsAbstract == false);

        foreach (var approvedType in allApprovedType)
        {
            ApprovedManager approvedManager = Activator.CreateInstance(approvedType) as ApprovedManager;
            if (approvedManager != null) notices.Add(approvedManager.ApprovedType, approvedManager);
        }
    }
    
    protected void DefineStudentStatus(ApprovedType approvedType, double note, Students student)
    {
        var approved = notices[approvedType];
        approved.CheckFinalNote(note, student);
    }
}
