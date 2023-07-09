
using Sensus.GUI.Core;
using Sensus.GUI.Models;
using Sensus.GUI.WindowModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sensus.GUI.WindowModels
{
    public class MainWindowModel : BaseNotification
    {
        #region Elements

        private int _id;
        public int Id
        {
            get => _id;
            set => SetField(ref _id, value);
        }

        private string? _address;
        public string? Address
        {
            get => _address;
            set
            {
                if (!SetField(ref _address, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _dopAddress;
        public string? DopAddress
        {
            get => _dopAddress;
            set
            {
                if (!SetField(ref _dopAddress, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _fasad;
        public string? Fasad
        {
            get => _fasad;
            set
            {
                if (!SetField(ref _fasad, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _name;
        public string? Name
        {
            get => _name;
            set
            {
                if (!SetField(ref _name, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set
            {
                if (!SetField(ref _phone, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _type;
        public string? Type
        {
            get => _type;
            set
            {
                if (!SetField(ref _type, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _description;
        public string? Description
        {
            get => _description;
            set
            {
                if (!SetField(ref _description, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private decimal? _square;
        public decimal? Square
        {
            get => _square;
            set
            {
                if (!SetField(ref _square, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private int? _parameters;
        public int? Parameters
        {
            get => _parameters;
            set
            {
                if (!SetField(ref _parameters, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string? _security;
        public string? Security
        {
            get => _security;
            set
            {
                if (!SetField(ref _security, value)) return;

                AddStat.RaiseCanExecuteChanged();
                ClearStat.RaiseCanExecuteChanged();
                //DeleteStat.RaiseCanExecuteChanged();
                //UpdateCommand.RaiseCanExecuteChanged();
            }
        }




        #endregion

        #region List

        public ObservableCollection<Statistic> Statistics { get; set; }

        private Statistic _selectedStat;
        public Statistic SelectedStat
        {
            get => _selectedStat;
            set
            {
                if (!SetField(ref _selectedStat, value)) return;

                Address = _selectedStat.Address;
                DopAddress = _selectedStat.DopAddress;
                Fasad= _selectedStat.Fasad;
                Name = _selectedStat.Name;
                Phone = _selectedStat.Phone;
                Type = _selectedStat.Type;
                Description = _selectedStat.Description;
                Square= _selectedStat.Square;
                Parameters = _selectedStat.Parameters;
                Security=_selectedStat.Security;

            }
        }


        //private ICommand deleteCommand;
        //public ICommand DeleteCommand
        //{
        //    get
        //    {
        //        if (deleteCommand == null)
        //        {
        //            deleteCommand = new RelayCommand(DeleteSelectedRecord, CanDeleteSelectedRecord);
        //        }
        //        return deleteCommand;
        //    }
        //}

        //private void DeleteSelectedRecord()
        //{
        //    if (SelectedStat != null)
        //    {
        //        using (var context = new DataBaseContext())
        //        {
        //            context.Statistics.Remove(SelectedStat);
        //            context.SaveChanges();
        //        }
        //    }
        //}

        //private bool CanDeleteSelectedRecord()
        //{
        //    return SelectedStat != null;
        //}






        #endregion

        #region Commands

        public LambdaCommand AddStat { get; set; }
        public LambdaCommand ClearStat { get; set; }
        //public LambdaCommand DeleteStat { get; set; }
        //public LambdaCommand UpdateCommand { get; set; }

        
        
        

        #endregion


        public MainWindowModel()
        {
            var db = new DataBaseContext();

            Statistics = new ObservableCollection<Statistic>(db.Statistics);
            SelectedStat = new Statistic();

            AddStat = new LambdaCommand(
                execute: _ =>
                {
                    var stat = new Statistic
                    {
                        Address=Address,
                        DopAddress=DopAddress,
                        Fasad=Fasad,
                        Name=Name,
                        Phone=Phone,
                        Type=Type,
                        Description=Description,
                        Square= Square,
                        Parameters=Parameters,
                        Security=Security
                    };

                    Statistics.Add(stat);
                    db.Statistics.Add(stat);
                    db.SaveChanges();
                    
                },
                canExecute: _ => !string.IsNullOrWhiteSpace(Address) &&
                                 !string.IsNullOrWhiteSpace(DopAddress) &&
                                 !string.IsNullOrWhiteSpace(Fasad) &&
                                 !string.IsNullOrWhiteSpace(Name) &&
                                 !string.IsNullOrWhiteSpace(Phone) &&
                                 !string.IsNullOrWhiteSpace(Type) &&
                                 !string.IsNullOrWhiteSpace(Description) &&
                                 !string.IsNullOrWhiteSpace(Square.ToString()) &&
                                 !string.IsNullOrWhiteSpace(Parameters.ToString()) &&
                                 !string.IsNullOrWhiteSpace(Security)
            );

            ClearStat = new LambdaCommand(
                execute: _ =>
                {
                    Address="";
                    DopAddress="";
                    Fasad="";
                    Name="";
                    Phone="";
                    Type="";
                    Description="";
                    Square=0;
                    Parameters=0;
                    Security="";
                },
                canExecute: _ => !string.IsNullOrWhiteSpace(Address) &&
                                 !string.IsNullOrWhiteSpace(DopAddress) &&
                                 !string.IsNullOrWhiteSpace(Fasad) &&
                                 !string.IsNullOrWhiteSpace(Name) &&
                                 !string.IsNullOrWhiteSpace(Phone) &&
                                 !string.IsNullOrWhiteSpace(Type) &&
                                 !string.IsNullOrWhiteSpace(Description) &&
                                 !string.IsNullOrWhiteSpace(Square.ToString()) &&
                                 !string.IsNullOrWhiteSpace(Parameters.ToString()) &&
                                 !string.IsNullOrWhiteSpace(Security)
            );

           // DeleteStat = new LambdaCommand(
           //     execute: _ =>
           //     {
           //        if(MessageBox.Show ("Вы точно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
           //        {
           //             var CurrentItem = SelectedStat;
           //             Statistics.Remove(SelectedStat);
           //             db.Statistics.Remove(SelectedStat);
           //             db.SaveChanges();
                        
           //        }

           //     },
           //     canExecute: _ => !string.IsNullOrWhiteSpace(SelectedStat.Id.ToString())
           //                      //!string.IsNullOrWhiteSpace(DopAddress) &&
           //                      //!string.IsNullOrWhiteSpace(Fasad) &&
           //                      //!string.IsNullOrWhiteSpace(Name) &&
           //                      //!string.IsNullOrWhiteSpace(Phone) &&
           //                      //!string.IsNullOrWhiteSpace(Type) &&
           //                      //!string.IsNullOrWhiteSpace(Description) &&
           //                      //!string.IsNullOrWhiteSpace(Square.ToString()) &&
           //                      //!string.IsNullOrWhiteSpace(Parameters.ToString()) &&
           //                      //!string.IsNullOrWhiteSpace(Security)
           // );

           // //редактирование
           // UpdateCommand = new LambdaCommand(
           //    execute: _ =>
           //    {
           //        Statistic CurrentItem = SelectedStat;
           //        Statistics.Remove(CurrentItem);
           //        db.Statistics.Remove(CurrentItem);
           //        var item = new Statistic
           //        {
           //            Id= CurrentItem.Id,
           //            Address=Address,
           //            DopAddress=DopAddress,
           //            Fasad=Fasad,
           //            Name=Name,
           //            Phone=Phone,
           //            Type=Type,
           //            Description=Description,
           //            Square= Square,
           //            Parameters=Parameters,
           //            Security=Security
           //        };
           //            Statistics.Add(item);
           //            db.Statistics.Add(item);
           //            db.SaveChanges();
                      
                  

           //    },
           //    canExecute: _ => string.IsNullOrWhiteSpace(Address)
           //                     //!string.IsNullOrWhiteSpace(DopAddress) &&
           //                     //!string.IsNullOrWhiteSpace(Fasad) &&
           //                     //!string.IsNullOrWhiteSpace(Name) &&
           //                     //!string.IsNullOrWhiteSpace(Phone) &&
           //                     //!string.IsNullOrWhiteSpace(Type) &&
           //                     //!string.IsNullOrWhiteSpace(Description) &&
           //                     //!string.IsNullOrWhiteSpace(Square.ToString()) &&
           //                     //!string.IsNullOrWhiteSpace(Parameters.ToString()) &&
           //                     //!string.IsNullOrWhiteSpace(Security)
           //);
            

          






        }
    }
}




         