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
using System.Threading.Tasks;

namespace Auth.Client.ViewModel
{
    public class ViewSport
    {

        private ObservableCollection<GroupedClientNewsModel> newsItem;
        public ObservableCollection<GroupedClientNewsModel> NewsItem
        {
            get { return newsItem; }
            set
            {
                newsItem = value;
               
            }
        }

      

        public ViewSport()
        {
            NewsItem = new ObservableCollection<GroupedClientNewsModel>();
            GetNewsInformation();
        }

        private async void GetNewsInformation()
        {
            FirebaseClient fc = new FirebaseClient("https://test-abb0f-default-rtdb.firebaseio.com/");
            FirebaseStorage firebaseStorage = new FirebaseStorage("test-abb0f.appspot.com");
            var GetNews = (await fc
              .Child("TableSport")
              .OnceAsync<TableSport>()).Select(item => new TableSport
              {
                  NewsDateTime = item.Object.NewsDateTime,
                  NewsText = item.Object.NewsText,
                  Email = item.Object.Email,
                  IDentifier = item.Object.IDentifier}).ToList().OrderBy(i => i.NewsDateTime);

            var headergroup = GetNews.Select(x => x.NewsDateTime).Distinct().ToList();

            foreach (var item in headergroup)
            {
                var newsGroup = new GroupedClientNewsModel() { NewsDateTime = item };

                var contents = GetNews.Where(i => i.NewsDateTime == item).ToList();

                if (contents.Count != 0)
                {
                    foreach (var groupitems in contents)
                    {
                        var filepath = await firebaseStorage
                            .Child("Sport")
                            .Child(groupitems.IDentifier+ ".png").GetDownloadUrlAsync();


                       newsGroup.Add(new ClientNewsModel() { News = groupitems.NewsText, NewsImagePath = filepath, Email = groupitems.Email });
                    }
                    
                    NewsItem.Add(newsGroup);
                }
            }
        }
    }
}

    
