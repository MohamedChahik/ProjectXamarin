using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Auth.Server.Model;
using FBGroupingApp.Client.Model;
using FBGroupingApp.Server.Model;
using Firebase.Database;
using Firebase.Storage;
using Xamarin.Forms;

    internal class ViewProvider
    {

    private ObservableCollection<GroupedClientProviderModel> providersItem;
    public ObservableCollection<GroupedClientProviderModel> ProvidersItem
        {
            get { return providersItem; }
            set
            {
                providersItem = value;

            }
        }



        public ViewProvider()
        {
            ProvidersItem = new ObservableCollection<GroupedClientProviderModel>();
            GetProviderInformation();
        }

        private async void GetProviderInformation()
        {
            FirebaseClient fc = new FirebaseClient("https://test-abb0f-default-rtdb.firebaseio.com/");
            FirebaseStorage firebaseStorage = new FirebaseStorage("test-abb0f.appspot.com");
            var GetProvider = (await fc
              .Child("TableProvider")
              .OnceAsync<TableProvider>()).Select(item => new TableProvider
              {
                  ProviderDateTime = item.Object.ProviderDateTime,
                  Username = item.Object.Username,
                  PhoneNumber = item.Object.PhoneNumber,
                  Address = item.Object.Address,
                  Description = item.Object.Description,
                  Email = item.Object.Email,
                  IDentifier = item.Object.IDentifier
              }).ToList().OrderBy(i => i.ProviderDateTime);

            var headergroup = GetProvider.Select(x => x.ProviderDateTime).Distinct().ToList();

            foreach (var item in headergroup)
            {
                var providerGroup = new GroupedClientProviderModel() { ProviderDateTime = item };

                var contents = GetProvider.Where(i => i.ProviderDateTime == item).ToList();

                if (contents.Count != 0)
                {
                    foreach (var groupitems in contents)
                    {
                        var filepath = await firebaseStorage
                            .Child("Provider")
                            
                            .Child(groupitems.IDentifier + ".png").GetDownloadUrlAsync();


                        providerGroup.Add(new ProviderModel() { Username = groupitems.Username, ProviderImagePath = filepath, Email = groupitems.Email, PhoneNumber = groupitems.PhoneNumber, Address = groupitems.Address, Description = groupitems.Description });
                    }

                    ProvidersItem.Add(providerGroup);
                }
            }
        }
    }

