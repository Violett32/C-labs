using System.Collections.Generic;
using System.Collections.ObjectModel;
using VetaLab5.Models;

namespace VetaLab5.Repository;

public interface IMyRepository
{
    void SaveToDb(ObservableCollection<Contact> wordModels);
    List<Contact> LoadFromDb();
}
