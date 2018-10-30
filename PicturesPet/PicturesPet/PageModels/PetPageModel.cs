using DLToolkit.Forms.Controls;
using PicturesPet.Models;
using PicturesPet.Services;
using Refit;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using static PicturesPet.App;

namespace PicturesPet.PageModels
{
    public class PetPageModel : BasePageModel
    {
        private TypePet type;
        private int _page { get; set; }
        
        public FlowObservableCollection<PetModel> Items { get; set; }
        public bool IsLoadingInfinite { get; set; }
        public int TotalRecords { get; set; } = 50;

        public ICommand LoadingCommand => new Command((args) =>
        {
            ++_page;
            LoadData();
        });

        public ICommand ItemTappedCommand => new Command<PetModel>(async (pet) =>
        {
            if (!string.IsNullOrEmpty(pet.Breeds.FirstOrDefault()?.Name))
                await CoreMethods.DisplayAlert("Breeds", string.Join("\n", pet.Breeds.Select(x => x.Name)), "Ok");
            else
                await CoreMethods.DisplayAlert("Oppss!!", "No breeds", "Ok");
        });

        public override void Init(object initData)
        {
            base.Init(initData);

            type = (TypePet)initData;
            Items = new FlowObservableCollection<PetModel>();
            LoadData();
        }

        private async void LoadData()
        {
            var pets = await RestService.For<IPetService>(type == TypePet.Cat ? HttpCat : HttpDog)
                .Search(type == TypePet.Cat
                        ? "8966e230-95eb-433f-bcae-714d50865652"
                        : "fc09b9c3-1b5f-4d50-9af2-16ffb2525af5",
                    page: _page);

            Items.AddRange(pets);
            IsLoadingInfinite = false;
        }
    }
}