﻿using PetShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PetShopApp.Services.Navigation
{
    class NavigationService
    {
        public async Task PushPage(Page page, object parameter = null)
        {
            if (page != null)
            {
                var navigationPage = App.Current.MainPage;
                var viewModel = page.BindingContext;
                await ((ViewModelBase)viewModel).ConstructorAsync(parameter);
                NavigationPage wrapper = new NavigationPage(page);
                await ((NavigationPage)navigationPage).PushAsync(wrapper);
            }
        }

        public async Task PopPage()
        {
            var navigationPage = App.Current.MainPage;
            await ((NavigationPage)navigationPage).PopAsync();
        }

        public async Task RemovePreviousPage()
        {
            var navigation = App.Current.MainPage.Navigation;
            var navigationStack = navigation.NavigationStack;
            var c = navigationStack.Count;
            var previousPage = navigationStack[navigationStack.Count - 2];
            navigation.RemovePage(previousPage);
        }

        public ViewModelBase PreviousViewModel
        {
            get
            {
                var navigationStack = App.Current.MainPage.Navigation.NavigationStack;
                var previousPage = navigationStack[navigationStack.Count - 2];
                ViewModelBase viewModel = (ViewModelBase)previousPage.BindingContext;
                return viewModel;
            }
        }
    }

}
