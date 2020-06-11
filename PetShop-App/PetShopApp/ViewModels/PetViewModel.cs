﻿using PetShopApp.AuxModels;
using PetShopApp.Configuration;
using PetShopApp.Models;
using PetShopApp.Services.APIRest;
using PetShopApp.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PetShopApp.ViewModels
{
    public class PetViewModel:PetModel
    {

        #region Attributes
        private PetModel petmodel;
        private string idPet = "2";
        #endregion Attributes

        #region Requests
        public RequestPicker<PetModel> petDelete { get; set; }
        #endregion Requests

        #region Commands
        public ICommand DeletePetCommand { get; set; }
        #endregion Commands

        //Constructores
        public PetViewModel()
        {
            Petmodel = new PetModel();
            InitializeRequestAsync();
            InitializeCommands();
        }

        #region Getters & Setters
        public PetModel Petmodel
        {
            get { return petmodel; }
            set
            {
                petmodel = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters

        #region Initialize
        private async Task InitializeRequestAsync()
        {
            //string urlDeletePet = EndPoints.SERVER_URL+ EndPoints.DELETE_PET;

            string urlDeletePet = EndPoints.SERVER_URL + EndPoints.DELETE_PET; ;
            petDelete = new RequestPicker<PetModel>();
            petDelete.StrategyPicker("DELETE", urlDeletePet);
        }

        private async Task InitializeCommands()
        {
            DeletePetCommand = new Command(async () => await DeletePet());
        }
        #endregion Initialize

        #region Methods
      
        public async Task DeletePet()
        {
            try
            {
                ParametersRequest parameters = new ParametersRequest();
                parameters.Parameters.Add(idPet);
                APIResponse response = await petDelete.ExecuteStrategy(null, parameters);
                if (response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert("Opreción exitosa", "La mascota ha sido eliminada", "OK");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "La mascota no ha sido eliminada", "OK");

                }

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio una excepción", "OK");

            }

        }

      
        #endregion Methods
    }
}
