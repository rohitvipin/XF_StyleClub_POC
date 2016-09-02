﻿using System.Threading.Tasks;
using Xamarin.Forms;
using XF_StyleClub_POC.ViewModels.Interfaces;
using XF_StyleClub_POC.Views.Interfaces;

namespace XF_StyleClub_POC.Views
{
    public partial class DetailVideoView : IDetailVideoView
    {
        private readonly IDetailVideoViewModel _detailVideoViewModel;

        public DetailVideoView(IDetailVideoViewModel detailVideoViewModel)
        {
            InitializeComponent();
            BindingContext = _detailVideoViewModel = detailVideoViewModel;
            BindablePage = this;
        }

        public Page BindablePage { get; }

        public async Task Initialize() => await _detailVideoViewModel.Initialize();

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VideoPlayer.Play();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            VideoPlayer.Pause();
        }
    }
}
