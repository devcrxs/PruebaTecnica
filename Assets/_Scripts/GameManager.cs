using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public event Action OnCheckNotes;
    public event Action OnCheckZoneDrop;
    public event Action OnAddStudent;
    public event Action OnEditStudent;
    public event Action OnDeletStudent;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    
    public void CheckNotes()
    {
        OnCheckNotes?.Invoke();
    }

    public void CheckZoneDrop()
    {
        OnCheckZoneDrop?.Invoke();
    }

    public void AddStudent()
    {
        OnAddStudent?.Invoke();
    }

    public void EditStudent()
    {
        OnEditStudent?.Invoke();
    }

    public void DeletStudent()
    {
        OnDeletStudent?.Invoke();
    }
}
