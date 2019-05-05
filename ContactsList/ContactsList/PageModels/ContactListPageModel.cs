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
    public class ContactListPageModel : BaseContactPageModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllContactsCommand { get; private set; }

        public ContactListPageModel(IContactRepository contactRepository, IValidator contactValidator) : base(contactRepository, contactValidator)
        {

            AddCommand = new Command(async () => await ShowAddContact());
            DeleteAllContactsCommand = new Command(async () => await DeleteAllContacts());
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            FetchContacts();
        }

        void FetchContacts()
        {
            ContactList = _contactRepository.GetAllContactsData();
        }

        async Task ShowAddContact()
        {
            await CoreMethods.PushPageModel<AddContactPageModel>();
        }

        async Task DeleteAllContacts()
        {
            bool isUserAccept = await CoreMethods.DisplayAlert("Contact List", "Delete All Contacts Details ?", "OK", "Cancel");
            if (isUserAccept)
            {
                _contactRepository.DeleteAllContacts();
                await CoreMethods.PushPageModel<AddContactPageModel>();
            }
        }

        async void ShowContactDetails(int selectedContactID)
        {
            await CoreMethods.PushPageModel<ContactDetailsPageModel>(selectedContactID);
        }

        ContactInfo _selectedContactItem;
        public ContactInfo SelectedContactItem
        {
            get => _selectedContactItem;
            set
            {
                if (value != null)
                {
                    _selectedContactItem = value;
                    RaisePropertyChanged("SelectedContactItem");
                    ShowContactDetails(value.Id);
                }
            }
        }
    }
}
