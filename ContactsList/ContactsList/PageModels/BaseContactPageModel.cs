using ContactsList.Models;
using ContactsList.Services;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsList.PageModels
{
    public class BaseContactPageModel : FreshBasePageModel
    {
        public ContactInfo _contact;

        public IValidator _contactValidator;
        public IContactRepository _contactRepository;

        public BaseContactPageModel(IContactRepository contactRepository, IValidator contactValidator)
        {
            _contactRepository = contactRepository;
            _contactValidator = contactValidator;
        }

        public string Name
        {
            get => _contact.Name;
            set
            {
                _contact.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string MobileNumber
        {
            get => _contact.MobileNumber;
            set
            {
                _contact.MobileNumber = value;
                RaisePropertyChanged("MobileNumber");
            }
        }

        public string Age
        {
            get => _contact.Age;
            set
            {
                _contact.Age = value;
                RaisePropertyChanged("Age");
            }
        }

        public string Gender
        {
            get => _contact.Gender;
            set
            {
                _contact.Gender = value;
                RaisePropertyChanged("Gender");
            }
        }

        public DateTime DOB
        {
            get => _contact.DOB;
            set
            {
                _contact.DOB = value;
                RaisePropertyChanged("DOB");
            }
        }

        public string Address
        {
            get => _contact.Address;
            set
            {
                _contact.Address = value;
                RaisePropertyChanged("Address");
            }
        }

        List<ContactInfo> _contactList;
        public List<ContactInfo> ContactList
        {
            get => _contactList;
            set
            {
                _contactList = value;
                RaisePropertyChanged("ContactList");
            }
        }
    }
}
