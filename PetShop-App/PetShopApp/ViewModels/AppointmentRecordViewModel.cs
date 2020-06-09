﻿using PetShopApp.Configuration;
using PetShopApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using PetShopApp.Services.ApiRest;
using System.Threading.Tasks;
using PetShopApp.AuxModels;
using Newtonsoft.Json;

namespace PetShopApp.ViewModels
{
    public class AppointmentRecordViewModel : AppointmentRecordModel
    {
        #region Attributes
        private List<AppointmentRecordModel> appointmentsRecords;
        AppointmentRecordModel appointmentRecordModel;
        #endregion Attributes

        #region Requests
        public RequestPicker<BaseModel> GetAppointments { get; set; }
        #endregion Requests

        //Constructores
        public AppointmentRecordViewModel()
        {
            appointmentRecordModel = new AppointmentRecordModel();

            InitializeRequestAsync();
        }

        #region Getters & Setters
        public List<AppointmentRecordModel> AppointmentsRecords
        {
            get { return appointmentsRecords; }
            set
            {
                appointmentsRecords = value;
                OnPropertyChanged();
            }
        }
        #endregion Getters & Setters

        #region Initialize
        public async Task InitializeRequestAsync()
        {
            string urlAppointmentRecords = EndPoints.ULR_SERVIDOR + EndPoints.GET_APPOINTMENTRECORDS;

            GetAppointments = new RequestPicker<BaseModel>();
            GetAppointments.StrategyPicker("GET", urlAppointmentRecords);

            AppointmentsRecords = await SelectAppointments();
            Console.WriteLine("Pene");
        }
        #endregion Initialize

        #region Methods
        public async Task<List<AppointmentRecordModel>> SelectAppointments()
        {
            try
            {
                ParametersRequest parameters = new ParametersRequest();
                parameters.Parameters.Add("3");
                APIResponse response = await GetAppointments.ExecuteStrategy(null);
                if (response.IsSuccess)
                {
                    return JsonConvert.DeserializeObject<List<AppointmentRecordModel>>(response.Response);  
                }
                else
                {
                    return null;
                }                     
                        
            }
            catch(Exception e)
            {
                return null;
            }
        }
        #endregion Methods
    }
}
