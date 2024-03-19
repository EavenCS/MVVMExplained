using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MVVMExplane.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        private Model.SimplePerson person;

        public Model.SimplePerson Person
        {
            get { return person; }
            set { SetProperty(ref person, value); }
        }

        public ICommand ClearName { get; }
        public ICommand DeleteChildName { get; }
        public ICommand ResetData { get; }

        public MainViewModel()
        {
            person          = new Model.SimplePerson();
            ClearName       = new RelayCommand(ClearNameOfPerson);
            DeleteChildName = new RelayCommand<IList>(DeleteNameOfChildFromList);
            ResetData       = new RelayCommand(GenerateSampleData);

            GenerateSampleData();
        }

        private void GenerateSampleData()
        {
            Person.SureName = "Otto";
            Person.LastName = "Bismark";
            Person.Childs = new System.Collections.ObjectModel.ObservableCollection<string> {"Marie","Wilhelm","Herbert"};
        }

        private void DeleteNameOfChildFromList(IList list)
        {

        }

        private void ClearNameOfPerson()
        {
            person.LastName = string.Empty;
            person.SureName = string.Empty;
        }
    }
}
