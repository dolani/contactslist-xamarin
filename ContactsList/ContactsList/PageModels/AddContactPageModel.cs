using ContactsList.Models;
using ContactsList.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsList.PageModels
{
    public class AddContactPageModel : BaseContactPageModel
    {
        public ICommand AddContactCommand { get; private set; }
        public ICommand ViewAllContactsCommand { get; private set; }

        public AddContactPageModel(IContactRepository contactRepository, IValidator contactValidator) : base(contactRepository, contactValidator)
        {
            _contact = new ContactInfo();

            AddContactCommand = new Command(async () => await AddContact());
            ViewAllContactsCommand = new Command(async () => await ShowContactList());
        }

        async Task AddContact()
        {
            var validationResults = _contactValidator.Validate(_contact);

            if (validationResults.IsValid)
            {
                bool isUserAccept = await CoreMethods.DisplayAlert("Add Contact", "Do you want to save Contact details?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _contactRepository.InsertContact(_contact);
                    await CoreMethods.PushPageModel<ContactListPageModel>();
                }
            }
            else
            {
                await CoreMethods.DisplayAlert("Add Contact", validationResults.Errors[0].ErrorMessage, "Ok");
            }
        }

        async Task ShowContactList()
        {
            await CoreMethods.PushPageModel<ContactListPageModel>();
        }

        public bool IsViewAll => _contactRepository.GetAllContactsData().Count > 0 ? true : false;

    }
}
