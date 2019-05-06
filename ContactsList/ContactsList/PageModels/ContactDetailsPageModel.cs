using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ContactsList.Models;
using ContactsList.Services;
using FluentValidation;


namespace ContactsList.PageModels
{
    class ContactDetailsPageModel : BaseContactPageModel
    {
        public ICommand UpdateContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactDetailsPageModel(IContactRepository contactRepository, IValidator contactValidator) : base(contactRepository, contactValidator)
        {
            _contact = new ContactInfo();

            UpdateContactCommand = new Command(async () => await UpdateContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());


        }

        public override void Init(object initData)
        {
            _contact.Id = (int)initData;

            FetchContactDetails();
        }

        void FetchContactDetails()
        {
            _contact = _contactRepository.GetContactData(_contact.Id);
        }

        async Task UpdateContact()
        {
            var validationResults = _contactValidator.Validate(_contact);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await CoreMethods.DisplayAlert("Contact Details", "Update Contact Details", "OK", "Cancel");
                if (isUserAccept)
                {
                    _contactRepository.UpdateContact(_contact);
                    await CoreMethods.PopPageModel();
                }
            }
            else
            {
                await CoreMethods.DisplayAlert("Add Contact", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task DeleteContact()
        {
            bool isUserAccept = await CoreMethods.DisplayAlert("Contact Details", "Delete Contact Details", "OK", "Cancel");
            if (isUserAccept)
            {
                _contactRepository.DeleteContact(_contact.Id);
                await CoreMethods.PopPageModel();
            }
        }
    }
}
