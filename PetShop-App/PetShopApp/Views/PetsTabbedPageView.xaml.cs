﻿using PetShopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetsTabbedPageView : TabbedPage
    {
        TabbedPageViewModel context = new TabbedPageViewModel();
        public PetsTabbedPageView()
        {
            InitializeComponent();
            BindingContext = context;
        }
    }
}