using Sensus.GUI.WindowModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensus.GUI.Core
{
    
    public class Statistic : BaseNotification
    {
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
            set => SetField(ref _address, value);
        }

        private string? _dopAddress;
        public string? DopAddress
        {
            get => _dopAddress;
            set => SetField(ref _dopAddress, value);
        }

        private string? _fasad;
        public string? Fasad
        {
            get => _fasad;
            set=> SetField(ref _fasad, value);
        }


        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set => SetField(ref _phone, value);
        }

        private string? _type;
        public string? Type
        {
            get => _type;
            set => SetField(ref _type, value);
        }


        private string? _description;
        public string? Description
        {
            get => _description;
            set => SetField(ref _description, value);
        }

        private decimal? _square;
        public decimal? Square
        {
            get => _square;
            set => SetField(ref _square, value);
        }

        private int? _parameters;
        public int? Parameters
        {
            get => _parameters;
            set => SetField(ref _parameters, value);
        }


        private string? _security;
        public string? Security
        {
            get => _security;
            set => SetField(ref _security, value);
        }

    }
}
